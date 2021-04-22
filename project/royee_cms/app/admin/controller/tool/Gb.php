<?php
namespace app\admin\controller\tool;

use app\admin\model\ToolGb;
use app\common\controller\AdminController;
use think\facade\Db;
use EasyAdmin\annotation\ControllerAnnotation;
use EasyAdmin\annotation\NodeAnotation;
use think\App;

/**
* Class Salary
 * @package app\admin\controller\cw
* @ControllerAnnotation(title="耗材目录")
*/

class Gb extends AdminController{

    use \app\admin\traits\Curd;

    protected $sort = [
        'sort' => 'desc',
        'id'   => 'desc',
    ];

    public function __construct(App $app)
    {
        parent::__construct($app);
        $this->model = new ToolGb();
    }
    public function index(){
        if ($this->request->isAjax()) {
            if (input('selectFieds')) {
                return $this->selectList();
            }
            $count = $this->model->count();
            $list = $this->model->order($this->sort)->where(['id'=>40])->select();
            $data = [
                'code'  => 0,
                'msg'   => '',
                'count' => $count,
                'data'  => $list,
            ];
            return json($data);
        }
        return $this->fetch();
    }

    /**
     * @NodeAnotation(title="导入数据")
     */
    public function forImport(){
        return true;
    }

}