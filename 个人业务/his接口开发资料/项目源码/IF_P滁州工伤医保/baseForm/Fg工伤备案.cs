using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IF_P工伤医保.baseComm;
using IF_P工伤医保.baseData;
using IF_P工伤医保.baseForm;
using IF_P工伤医保.MyCode;
namespace IF_P工伤医保.baseForm
{
    public partial class Fg工伤备案 : Form
    {
        public Fg工伤备案()
        {
            InitializeComponent();
        }

        private void bt读卡2_Click(object sender, EventArgs e)
        {
           
        }

        private void bt备案_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception oE)
            {
                basComm.MsgError(oE.Message);
            }
        }

        private void chk结束日期_CheckedChanged(object sender, EventArgs e)
        {
            dt结束日期.Enabled = chk结束日期.Checked;
        }

        private void chk出生日期_CheckedChanged(object sender, EventArgs e)
        {
            dt出生日期.Enabled = chk出生日期.Checked;
        }

        private void chk入院日期_CheckedChanged(object sender, EventArgs e)
        {
            dt入院日期.Enabled = chk入院日期.Checked;
        }

        private void chk受伤日期_CheckedChanged(object sender, EventArgs e)
        {
            dt受伤日期.Enabled = chk受伤日期.Checked;
        }

        private void Fg意外伤害备案_Load(object sender, EventArgs e)
        {
           
        }
    }
}
