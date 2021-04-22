<?php

// +----------------------------------------------------------------------
// | EasyAdmin
// +----------------------------------------------------------------------
// | PHP交流群: 763822524
// +----------------------------------------------------------------------
// | 开源协议  https://mit-license.org 
// +----------------------------------------------------------------------
// | github开源项目：https://github.com/zhongshaofa/EasyAdmin
// +----------------------------------------------------------------------

namespace app\admin\controller;


use app\admin\model\SystemAdmin;
use app\common\controller\AdminController;
use app\common\tool\PhpOci;
use Matrix\Exception;
use think\captcha\facade\Captcha;
use think\facade\Db;
use think\facade\Env;
/**
 * Class Login
 * @package app\admin\controller
 */
class Test extends AdminController
{

    /**
     * 初始化方法
     */
    public function initialize()
    {
        parent::initialize();
        $action = $this->request->action();
//        if (!empty(session('admin')) && !in_array($action, ['out'])) {
//            $adminModuleName = config('app.admin_alias_name');
//            $this->success('已登录，无需再次登录', [], __url("@{$adminModuleName}"));
//        }
    }

    /**
     * 用户登录
     * @return string
     * @throws \Exception
     */
    public function index()
    {
        return json(['message'=>'站点已关闭！']);
        $type = $this->request->get('type','search');
        $captcha = Env::get('easyadmin.captcha', 1);
        if ($this->request->isPost()) {
            $post = $this->request->post();
            $rule = [
                'idcard|身份证号'      => 'require',
                'name|姓名'       => 'require'
            ];
            $captcha == 1 && $rule['captcha|验证码'] = 'require|captcha';
            $this->validate($post, $rule);
            $admin = Db::table('hrp_cw_salary')->where(['name' => $post['name'],'idcard'=>$post['idcard']])->find();
            //var_dump($admin);exit;
            if (empty($admin)) {
                $this->error('未查询到工资信息');
            }
            $data = [
              'code'=>1,
              'msg'=>'查询成功',
              'data'=>$admin
            ];
            return json($data);
        }
        $this->assign('captcha', $captcha);
        $this->assign('demo', $this->isDemo);
        $this->assign('type', $type);
        return $this->fetch();
    }


    /**
     * 用户退出
     * @return mixed
     */
    public function out()
    {
        session('admin', null);
        $this->success('退出登录成功');
    }

    /**
     * 验证码
     * @return \think\Response
     */
    public function captcha()
    {
        return Captcha::create();
    }


    /**
     * 显示首页信息
     * @return mixed
     */
    public function showPage(){
        //return json(['message'=>'showmessage']);
        $row = Db::table('hrp_article')->where(['id' => 192])->find();
        $this->assign('row',$row);
        return $this->fetch();
    }

    public function showYbdata(){
        if($this->request->isAjax()){
            //var_dump($this->request->param());exit;
            $params = $this->request->param();
            $page   = $params['page'];
            $limit  = $params['limit'];
            $where = " where A.隶属机构i='1'";
            if(isset($params['项目类别']) && $params['项目类别']!=''){
                $where .= " and 项目类别='".$params['项目类别']."'";
            }
            if(isset($params['项目名称'])&&$params['项目名称']!=''){
                $where .= " and 项目名称 like '%".$params['项目名称']."%'";
            }
            if(isset($params['项目编码'])&&$params['项目编码']!=''){
                $where .= " and 项目编码 ='".$params['项目编码']."'";
            }
            $db = PhpOci::getInstance();
            $sql_total ="select count(*)  total from INF_TCZSYB_中心药诊材目录 A ".$where;
            $sql = "select t2.* from (select rownum r,t1.* from (select *from ( select rowidtochar(rowid)  id, A.*from INF_TCZSYB_中心药诊材目录 A ".$where." ) T ) t1 where rownum<=".$page*$limit.") t2 where t2.r>".($page-1)*$limit;
            //$sql = "select *from inf_tczsyb_二级代码目录 where 代码类别='剂型'";
            $data = $db->findAll($sql);
            $count = $db->findOne($sql_total);
            //var_dump($sql);exit;
            $rest = [
                'code'=> 0,
                'msg'=> '获取数据成功',
                'count'=> $count['TOTAL'],
                'data'=> $data
            ];
            return $rest;
        }
        return $this->fetch();
    }


    public function ybadd(){
        if($this->request->isPost()){
           // $this->error("shiai");
           $data =  $this->request->post();
           if(strlen($data['项目编码'])!=27){return $this->error('中心项目编码必须为27位');}
          // var_dump($data);exit;
           $data['隶属机构I']=1;
           try{
               $db = PhpOci::getInstance();
               $db->autoInsert($data,'inf_tczsyb_中心药诊材目录');
               $this->success("添加成功！");
           }catch (Exception $exception){
               $this->error($exception->getMessage());
           }
        }
        return $this->fetch();
    }

    public function ybedit(){
        $params = $this->request->param();
        if($this->request->isPost()){
            // $this->error("shiai");
            $data =  $this->request->post();
           // if(strlen($data['项目编码'])!=27){return $this->error('中心项目编码必须为27位');}
            // var_dump($data);exit;
            $data['隶属机构I']=1;
            $dm_data=[];
            $dm_data['中心项目编码']=$data['项目编码'];
            $dm_data['中心项目名称']=$data['项目名称'];
            $dm_data['国家目录编码']=$data['国家目录编码'];
            $dm_data['国家目录名称']=$data['国家目录名称'];
            $dm_data['中心项目类别']=$data['项目类别'];
            $dm_data['中心收费类别']=$data['收费类别'];
            $dm_data['本地项目剂型']=$data['剂型'];
            try{
                $db = PhpOci::getInstance();
                //更新修改的信息
                $db->autoUpdate('inf_tczsyb_中心药诊材目录',$data,'rowid');
                //更新对照信息  //如果中心项目编码不等于空则更新项目对码关系
                if($dm_data['中心项目编码']!=''){
                    $db->autoUpdate('INF_DCZSYB_项目对码目录',$dm_data,'中心项目编码');
                }
                $this->success("修改成功！");
            }catch (\think\Exception $exception){
                $this->error($exception->getMessage());
            }
        }
        $rowid = $params['rowid'];
        if($rowid == ''){
            $this->error('请求错误！请求参数不能为空');
        }
        $db = PhpOci::getInstance();
        $row = $db->findOne("select rowidtochar(rowid) as id,  A.* from INF_TCZSYB_中心药诊材目录 A where rowid='".$rowid."'");
        //var_dump($row);exit;
        $this->assign('row',$row);
        return $this->fetch();
    }


    /**
     * 获取医保二级目录字典
     */
    public function getDic(){
        $params = $this->request->param();
        $type = $params['type'] ? $params['type'] : '收费类别';
        $page   = $params['page'];
        $limit  = $params['limit'];
        $where = "where 类别名称='".$type."'" ;
        if(isset($params['keywords']) && $params['keywords']!= ''){
            $where .=" and 代码名称 like '%".$params['keywords']."%'";
        }
        $sql = "select t2.* from (select rownum r,t1.* from (select *from ( select 代码值,代码名称 from inf_tczsyb_二级代码目录 ".$where." ) T ) t1 where rownum<=".$page*$limit.") t2 where t2.r>".($page-1)*$limit;
        $sql_count = "select count(*)  as TOTAL from inf_tczsyb_二级代码目录  ".$where;
        $db=PhpOci::getInstance();
        $data = $db->findAll($sql);
        $count = $db->findOne($sql_count);
        $rest = [
            'code'=> 0,
            'msg'=> '获取数据成功',
            'count'=> $count['TOTAL'],
            'data'=> $data
        ];
        return $rest;
    }

    public function oracleTest(){
            $data  = Db::connect('oracle')
            ->table('INF_DCZSYB_项目对码目录')->limit(10)->select()->toArray();
            var_dump($data);
    }


    public function sqlsrvTest(){
        $data  = Db::connect('sqlsrv')
            ->table('his_zy..zybrjbxxb')->limit(10)->select()->toArray();
        var_dump($data);
    }

    public function getrs(){
        $sql = "select *from doc_vt员工档案s where 系统序号=201";
        //$sql_count = "select count(*)  as TOTAL from inf_tczsyb_二级代码目录  ".$where;
        $db=PhpOci::getInstance();
        $data = $db->findAll($sql);
        //$count = $db->findOne($sql_count);
        return json($data);
    }
}

