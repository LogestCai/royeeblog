<?php
/**
 * Created by PhpStorm.
 * User: Administrator
 * Date: 2021-04-21
 * Time: 13:29
 */

namespace app\admin\controller\show;

use app\common\controller\AdminController;
use think\facade\Db;

class Article extends AdminController{

    public function index(){
        //return json(['message'=>'showmessage']);
        $row = Db::table('hrp_article')->where(['id' => 193])->find();
        $this->assign('row',$row);
        return $this->fetch();
    }
}