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

namespace app\admin\model;


use app\common\model\TimeModel;

class CwSalary extends TimeModel
{

    protected $table = "";

    protected $deleteTime = 'delete_time';

//    public function cate()
//    {
//        return $this->belongsTo('app\admin\model\ArticleCate', 'cate_id', 'id');
//    }

}