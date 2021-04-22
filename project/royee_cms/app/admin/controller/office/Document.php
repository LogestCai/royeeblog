<?php


namespace app\admin\controller\office;


use app\admin\model\OfficeDocument as Model;
use app\admin\traits\Curd;
use app\common\controller\AdminController;
use EasyAdmin\annotation\ControllerAnnotation;
use EasyAdmin\annotation\NodeAnotation;
use think\App;
use think\facade\Filesystem;

/**
 * Class Goods
 * @package app\admin\controller\mall
 * @ControllerAnnotation(title="企业云盘")
 */
class Document extends AdminController
{

    use Curd;

    //protected $relationSerach = true;

    public function __construct(App $app)
    {
        parent::__construct($app);
        $this->model = new Model();
    }

    /**
     * @NodeAnotation(title="列表")
     */
    public function index()
    {
        $type = $this->request->param('type',1);
        $pid = $this->request->param('pid',0);
        $bread = $this->model->getFathersByPid($pid);
        $session = session('admin');
        if ($this->request->isAjax()) {
            if (input('selectFieds')) {
                return $this->selectList();
            }
            list($page, $limit, $where) = $this->buildTableParames();
            //如果是个人文件则判断id
            if($type==2){
                $where[] =['uid','=',$session['id']];
            }
            $where[]=['type','=',$type];
            $where[]=['pid','=',$pid];
            $count = $this->model
                ->where($where)
                ->count();
            $list = $this->model
                ->where($where)
                ->page($page, $limit)
                ->order($this->sort)
                ->select();
            $data = [
                'code'  => 0,
                'msg'   => '',
                'count' => $count,
                'data'  => $list,
            ];
            return json($data);
        }
        $this->assign('type',$type);
        $this->assign('pid',$pid);
        $this->assign('bread',$bread);
        return $this->fetch();
    }

    public function add(){
        $type = $this->request->param('type',1);
        $pid  = $this->request->param('pid',1);
        if($this->request->isPost()){
            $file = $this->request->file('file');
            $session = session('admin');
            $uploadData = [];
            if($file){
                //开始处理逻辑了
                $data = [
                    'upload_type' => $this->request->post('upload_type'),
                    'file'        => $this->request->file('file'),
                ];
                $uploadConfig = sysconfig('upload');
                empty($data['upload_type']) && $data['upload_type'] = $uploadConfig['upload_type'];
                $rule = [
                    'upload_type|指定上传类型有误' => "in:{$uploadConfig['upload_allow_type']}",
                    'file|文件'              => "require|file|fileExt:{$uploadConfig['upload_allow_ext']}|fileSize:{$uploadConfig['upload_allow_size']}",
                ];
                $this->validate($data, $rule);
                try {
                    $fileName = Filesystem::disk('public')->putFile('upload/cloud',$file);
                    $uploadData['title']=trim($file->getOriginalName());
                    $uploadData['content'] = '/'.$fileName;
                    $uploadData['size'] = $file->getSize();
                    $uploadData['type'] = $type;
                    $uploadData['exts'] = $file->getOriginalExtension();
                    $uploadData['uid'] = $session['id'];
                    $uploadData['pid'] = $pid;
                    $uploadData['is_fileorfloder'] = 1;
                    if($this->model->save($uploadData)){
                        return show(1,'添加成功！',$this->model->toArray());
                    }else{
                        return show(0,'上传失败！请重新上传');
                    }

                } catch (\Exception $e) {
                    $this->error($e->getMessage());
                }
            }else{
                try {
                    $uploadData['title'] = $this->request->param('title');
                    $uploadData['type'] = $type;
                    $uploadData['pid'] = $pid;
                    $uploadData['uid'] = $session['id'];
                    $uploadData['is_fileorfloder'] = 2;
                    if($this->model->save($uploadData)){
                        return show(1,'新建文件夹成功！',$this->model->toArray());
                    }else{
                        return show(0,'新建文件夹失败！');
                    }
                } catch(\Exception $e){
                    $this->error($e->getMessage());
                }
            }

        }
        $this->assign('type',$type);
        $this->assign('pid',$pid);
        return $this->fetch();

    }


    /**
     * @NodeAnotation(title="编辑")
     */
    public function edit($id)
    {
        $row = $this->model->find($id);
        $row->isEmpty() && $this->error('数据不存在');
        if ($this->request->isAjax()) {
            $post = $this->request->post();
            $rule = [];
            $this->validate($post, $rule);
            try {
                $save = $row->save($post);
            } catch (\Exception $e) {
                $this->error('保存失败');
            }
            $save ? $this->success('保存成功') : $this->error('保存失败');
        }
        $this->assign('row', $row);
        return $this->fetch();
    }

    /**
     * @NodeAnotation(title="删除")
     */
    public function delete($id)
    {
        $row = $this->model->whereIn('id', $id)->where('uid',session('admin.id'))->select();
        $row->isEmpty() && $this->error('数据不存在或非本人上传的数据！');
        try {
            $save = $row->delete();
        } catch (\Exception $e) {
            $this->error('删除失败');
        }
        $save ? $this->success('删除成功') : $this->error('删除失败');
    }


    /**
     * @NodeAnotation(title="自动保存")
     */
    public function autoSave()
    {
        $post = $this->request->post();//$this->validate($post, $rule);
        if($post['title']!='' && $post['content'] !=''){
            if($post['id'] != ''){
                $id = $post['id'];
                unset($post['id']);
                if($this->model->update($post,['id'=>$id]))
                {
                    $this->success('保存成功',['id'=>$id]);
                }
            }else{
                if($this->model->save($post)){
                    $this->success('保存成功',['id'=>$this->model->id]);
                }
            }
        }
    }
}