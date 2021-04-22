<?php
namespace app\admin\controller\cw;

use app\admin\model\CwSalary;
use app\common\controller\AdminController;
use think\facade\Db;
use EasyAdmin\annotation\ControllerAnnotation;
use EasyAdmin\annotation\NodeAnotation;
use think\App;

/**
* Class Salary
 * @package app\admin\controller\cw
* @ControllerAnnotation(title="工资查询")
*/

class Salary extends AdminController{

    use \app\admin\traits\Curd;

    protected $sort = [
        'sort' => 'desc',
        'id'   => 'desc',
    ];

    public function __construct(App $app)
    {
        parent::__construct($app);
        $this->model = new CwSalary();
    }

    /**
     * @NodeAnotation(title="导入数据")
     */
    public function forImport(){
        return true;
    }

}