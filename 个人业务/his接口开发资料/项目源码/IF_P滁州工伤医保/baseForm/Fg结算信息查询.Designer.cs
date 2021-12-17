namespace IF_P工伤医保.baseForm
{
    partial class Fg结算信息查询
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.aButton1 = new ACtrllist.AButton();
            this.btn查询 = new ACtrllist.AButton();
            this.txbx姓名 = new ACtrllist.ATextBox();
            this.grid就诊信息 = new ACtrllist.AGridList();
            this.btn导出Excel = new ACtrllist.AButton();
            this.btn显示单据费用明细 = new ACtrllist.AButton();
            this.grid费用明细 = new ACtrllist.AGridList();
            this.txbx身份证 = new ACtrllist.ATextBox();
            this.dt开始日期 = new ACtrllist.ADateInput();
            this.dt终止日期 = new ACtrllist.ADateInput();
            this.lb时间 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aButton1
            // 
            this.aButton1.asPerCode = "";
            this.aButton1.BackColor = System.Drawing.SystemColors.Control;
            this.aButton1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.aButton1.Location = new System.Drawing.Point(988, 22);
            this.aButton1.Name = "aButton1";
            this.aButton1.Size = new System.Drawing.Size(81, 24);
            this.aButton1.TabIndex = 49;
            this.aButton1.Text = "导出Excel";
            this.aButton1.UseVisualStyleBackColor = true;
            // 
            // btn查询
            // 
            this.btn查询.asPerCode = "";
            this.btn查询.BackColor = System.Drawing.SystemColors.Control;
            this.btn查询.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn查询.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.btn查询.Location = new System.Drawing.Point(932, 22);
            this.btn查询.Name = "btn查询";
            this.btn查询.Size = new System.Drawing.Size(50, 24);
            this.btn查询.TabIndex = 47;
            this.btn查询.Text = "查询";
            this.btn查询.UseVisualStyleBackColor = true;
            this.btn查询.Click += new System.EventHandler(this.btn查询_Click);
            // 
            // txbx姓名
            // 
            this.txbx姓名.abEnterTab = true;
            this.txbx姓名.abLockInput = false;
            this.txbx姓名.abMoneyModel = false;
            this.txbx姓名.abMultiline = false;
            this.txbx姓名.abNvarchar = true;
            this.txbx姓名.abReplaceSign = true;
            this.txbx姓名.abSaveId = false;
            this.txbx姓名.abUnDoFlag = false;
            this.txbx姓名.abViewModel = false;
            this.txbx姓名.abWordWarp = true;
            this.txbx姓名.acLabelColor = System.Drawing.Color.Black;
            this.txbx姓名.acPasswordChar = '\0';
            this.txbx姓名.acTextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbx姓名.acTextForeColor = System.Drawing.Color.Black;
            this.txbx姓名.aeDataRule = ACtrllist.EDataRule.忽略;
            this.txbx姓名.aeDataType = ACtrllist.EDataType.String;
            this.txbx姓名.aeLableAlign = ACtrllist.ATextBox.LableAlign.Top;
            this.txbx姓名.aeScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbx姓名.aeTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbx姓名.aeTextBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbx姓名.afLabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbx姓名.afTextFont = new System.Drawing.Font("宋体", 10.5F);
            this.txbx姓名.aiMaxLength = 32767;
            this.txbx姓名.aiMoneyLenth = ACtrllist.ATextBox.aeMoneyLenth.两位;
            this.txbx姓名.aiNumberLength = ACtrllist.ATextBox.aeNumberLenth.四位;
            this.txbx姓名.aiSelectionLength = 0;
            this.txbx姓名.aiSelectionStart = 0;
            this.txbx姓名.asCaption = "姓名：";
            this.txbx姓名.asDataBounds = "";
            this.txbx姓名.asFieldName = "";
            this.txbx姓名.asFieldTableName = "";
            this.txbx姓名.asId = "";
            this.txbx姓名.asSearchTips = "";
            this.txbx姓名.asSelectionText = "";
            this.txbx姓名.asText = "";
            this.txbx姓名.BackColor = System.Drawing.Color.Transparent;
            this.txbx姓名.Location = new System.Drawing.Point(506, 22);
            this.txbx姓名.Name = "txbx姓名";
            this.txbx姓名.Size = new System.Drawing.Size(134, 26);
            this.txbx姓名.TabIndex = 46;
            this.txbx姓名.Tag = "";
            // 
            // grid就诊信息
            // 
            this.grid就诊信息.abAllowCtrlF = true;
            this.grid就诊信息.abAllowCtrlS = true;
            this.grid就诊信息.abAllowEditBT = false;
            this.grid就诊信息.abAllowEditing = false;
            this.grid就诊信息.abAllowFiltering = false;
            this.grid就诊信息.abAutoSizeRows = false;
            this.grid就诊信息.abHaveAddButton = false;
            this.grid就诊信息.abHaveDelButton = false;
            this.grid就诊信息.abHaveEditButton = false;
            this.grid就诊信息.abLTable = true;
            this.grid就诊信息.abPaging = true;
            this.grid就诊信息.abPublic = false;
            this.grid就诊信息.abReadOnly = true;
            this.grid就诊信息.abReport = false;
            this.grid就诊信息.abWordWrap = true;
            this.grid就诊信息.acFocusedBackColor = System.Drawing.SystemColors.Window;
            this.grid就诊信息.aeAllowDrop = ACtrllist.EAllowDropMode.无;
            this.grid就诊信息.aeCtrlBorderStyle = ACtrllist.ECtrlBorderStyle.None;
            this.grid就诊信息.aeGridBorderStyle = ACtrllist.EGridBorderStyle.None;
            this.grid就诊信息.aeSaveSubTableMode = ACtrllist.ESaveSubTableMode.EDIT;
            this.grid就诊信息.aeScrollBars = ACtrllist.EScrollBars.Both;
            this.grid就诊信息.aeSelectMode = ACtrllist.ESelectionMode.单选行;
            this.grid就诊信息.aeTableStyle = ACtrllist.ETableStyle.默认风格;
            this.grid就诊信息.aeWordWarp = ACtrllist.EWordWarp.无;
            this.grid就诊信息.aiCol = 1;
            this.grid就诊信息.aiCols = 10;
            this.grid就诊信息.aiColSel = 1;
            this.grid就诊信息.aiFixedCols = 1;
            this.grid就诊信息.aiFixedRows = 1;
            this.grid就诊信息.aiFrozenCols = 0;
            this.grid就诊信息.aiRow = 1;
            this.grid就诊信息.aiRows = 50;
            this.grid就诊信息.aiRowSel = 1;
            this.grid就诊信息.aiTopRow = 1;
            this.grid就诊信息.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid就诊信息.asSaveTable = "";
            this.grid就诊信息.asSaveTableKey = "";
            this.grid就诊信息.asTitle = "就诊信息";
            this.grid就诊信息.asViewTable = "";
            this.grid就诊信息.atFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid就诊信息.atTitleFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid就诊信息.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.grid就诊信息.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid就诊信息.Location = new System.Drawing.Point(12, 53);
            this.grid就诊信息.Margin = new System.Windows.Forms.Padding(2);
            this.grid就诊信息.Name = "grid就诊信息";
            this.grid就诊信息.Size = new System.Drawing.Size(1085, 201);
            this.grid就诊信息.TabIndex = 50;
            this.grid就诊信息.TabStop = false;
            // 
            // btn导出Excel
            // 
            this.btn导出Excel.asPerCode = "";
            this.btn导出Excel.BackColor = System.Drawing.SystemColors.Control;
            this.btn导出Excel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn导出Excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.btn导出Excel.Location = new System.Drawing.Point(122, 259);
            this.btn导出Excel.Name = "btn导出Excel";
            this.btn导出Excel.Size = new System.Drawing.Size(81, 24);
            this.btn导出Excel.TabIndex = 54;
            this.btn导出Excel.Text = "导出Excel";
            this.btn导出Excel.UseVisualStyleBackColor = true;
            this.btn导出Excel.Click += new System.EventHandler(this.btn导出Excel_Click);
            // 
            // btn显示单据费用明细
            // 
            this.btn显示单据费用明细.asPerCode = "";
            this.btn显示单据费用明细.BackColor = System.Drawing.SystemColors.Control;
            this.btn显示单据费用明细.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn显示单据费用明细.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(157)))), ((int)(((byte)(217)))));
            this.btn显示单据费用明细.Location = new System.Drawing.Point(10, 259);
            this.btn显示单据费用明细.Name = "btn显示单据费用明细";
            this.btn显示单据费用明细.Size = new System.Drawing.Size(106, 24);
            this.btn显示单据费用明细.TabIndex = 51;
            this.btn显示单据费用明细.Text = "显示单据费用明细";
            this.btn显示单据费用明细.UseVisualStyleBackColor = true;
            this.btn显示单据费用明细.Click += new System.EventHandler(this.btn显示单据费用明细_Click);
            // 
            // grid费用明细
            // 
            this.grid费用明细.abAllowCtrlF = true;
            this.grid费用明细.abAllowCtrlS = true;
            this.grid费用明细.abAllowEditBT = false;
            this.grid费用明细.abAllowEditing = false;
            this.grid费用明细.abAllowFiltering = false;
            this.grid费用明细.abAutoSizeRows = false;
            this.grid费用明细.abHaveAddButton = false;
            this.grid费用明细.abHaveDelButton = false;
            this.grid费用明细.abHaveEditButton = false;
            this.grid费用明细.abLTable = true;
            this.grid费用明细.abPaging = false;
            this.grid费用明细.abPublic = false;
            this.grid费用明细.abReadOnly = true;
            this.grid费用明细.abReport = false;
            this.grid费用明细.abWordWrap = true;
            this.grid费用明细.acFocusedBackColor = System.Drawing.SystemColors.Window;
            this.grid费用明细.aeAllowDrop = ACtrllist.EAllowDropMode.无;
            this.grid费用明细.aeCtrlBorderStyle = ACtrllist.ECtrlBorderStyle.None;
            this.grid费用明细.aeGridBorderStyle = ACtrllist.EGridBorderStyle.None;
            this.grid费用明细.aeSaveSubTableMode = ACtrllist.ESaveSubTableMode.EDIT;
            this.grid费用明细.aeScrollBars = ACtrllist.EScrollBars.Both;
            this.grid费用明细.aeSelectMode = ACtrllist.ESelectionMode.单选行;
            this.grid费用明细.aeTableStyle = ACtrllist.ETableStyle.默认风格;
            this.grid费用明细.aeWordWarp = ACtrllist.EWordWarp.无;
            this.grid费用明细.aiCol = 1;
            this.grid费用明细.aiCols = 50;
            this.grid费用明细.aiColSel = 1;
            this.grid费用明细.aiFixedCols = 1;
            this.grid费用明细.aiFixedRows = 1;
            this.grid费用明细.aiFrozenCols = 0;
            this.grid费用明细.aiRow = 1;
            this.grid费用明细.aiRows = 50;
            this.grid费用明细.aiRowSel = 1;
            this.grid费用明细.aiTopRow = 1;
            this.grid费用明细.AllowDrop = true;
            this.grid费用明细.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid费用明细.asSaveTable = "";
            this.grid费用明细.asSaveTableKey = "";
            this.grid费用明细.asTitle = "费用明细";
            this.grid费用明细.asViewTable = "";
            this.grid费用明细.atFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid费用明细.atTitleFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid费用明细.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.grid费用明细.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid费用明细.Location = new System.Drawing.Point(11, 290);
            this.grid费用明细.Margin = new System.Windows.Forms.Padding(2);
            this.grid费用明细.Name = "grid费用明细";
            this.grid费用明细.Size = new System.Drawing.Size(1086, 274);
            this.grid费用明细.TabIndex = 59;
            this.grid费用明细.TabStop = false;
            // 
            // txbx身份证
            // 
            this.txbx身份证.abEnterTab = true;
            this.txbx身份证.abLockInput = false;
            this.txbx身份证.abMoneyModel = false;
            this.txbx身份证.abMultiline = false;
            this.txbx身份证.abNvarchar = true;
            this.txbx身份证.abReplaceSign = true;
            this.txbx身份证.abSaveId = false;
            this.txbx身份证.abUnDoFlag = false;
            this.txbx身份证.abViewModel = false;
            this.txbx身份证.abWordWarp = true;
            this.txbx身份证.acLabelColor = System.Drawing.Color.Black;
            this.txbx身份证.acPasswordChar = '\0';
            this.txbx身份证.acTextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txbx身份证.acTextForeColor = System.Drawing.Color.Black;
            this.txbx身份证.aeDataRule = ACtrllist.EDataRule.忽略;
            this.txbx身份证.aeDataType = ACtrllist.EDataType.String;
            this.txbx身份证.aeLableAlign = ACtrllist.ATextBox.LableAlign.Top;
            this.txbx身份证.aeScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbx身份证.aeTextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txbx身份证.aeTextBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbx身份证.afLabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbx身份证.afTextFont = new System.Drawing.Font("宋体", 10.5F);
            this.txbx身份证.aiMaxLength = 32767;
            this.txbx身份证.aiMoneyLenth = ACtrllist.ATextBox.aeMoneyLenth.两位;
            this.txbx身份证.aiNumberLength = ACtrllist.ATextBox.aeNumberLenth.四位;
            this.txbx身份证.aiSelectionLength = 0;
            this.txbx身份证.aiSelectionStart = 0;
            this.txbx身份证.asCaption = "身份证号：";
            this.txbx身份证.asDataBounds = "";
            this.txbx身份证.asFieldName = "";
            this.txbx身份证.asFieldTableName = "";
            this.txbx身份证.asId = "";
            this.txbx身份证.asSearchTips = "";
            this.txbx身份证.asSelectionText = "";
            this.txbx身份证.asText = "";
            this.txbx身份证.BackColor = System.Drawing.Color.Transparent;
            this.txbx身份证.Location = new System.Drawing.Point(646, 22);
            this.txbx身份证.Name = "txbx身份证";
            this.txbx身份证.Size = new System.Drawing.Size(267, 26);
            this.txbx身份证.TabIndex = 60;
            this.txbx身份证.Tag = "";
            // 
            // dt开始日期
            // 
            this.dt开始日期.abDefaultNow = true;
            this.dt开始日期.abEnterTab = true;
            this.dt开始日期.abGetAllFormat = false;
            this.dt开始日期.abLockInput = false;
            this.dt开始日期.abSaveId = false;
            this.dt开始日期.abViewModel = false;
            this.dt开始日期.acBackColor = System.Drawing.Color.Transparent;
            this.dt开始日期.acFontColor = System.Drawing.SystemColors.ControlText;
            this.dt开始日期.acLabelColor = System.Drawing.SystemColors.ControlText;
            this.dt开始日期.aeDataRule = ACtrllist.EDataRule.忽略;
            this.dt开始日期.aeDataType = ACtrllist.EDataType.String;
            this.dt开始日期.aeDateFormt = ACtrllist.EDispFormat.年月日时分秒;
            this.dt开始日期.afFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt开始日期.afLabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt开始日期.asCaption = "";
            this.dt开始日期.asFieldName = "";
            this.dt开始日期.asFieldTableName = "";
            this.dt开始日期.asId = "";
            this.dt开始日期.asText = "";
            this.dt开始日期.BackColor = System.Drawing.Color.Transparent;
            this.dt开始日期.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt开始日期.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dt开始日期.Location = new System.Drawing.Point(106, 20);
            this.dt开始日期.Name = "dt开始日期";
            this.dt开始日期.Size = new System.Drawing.Size(182, 26);
            this.dt开始日期.TabIndex = 61;
            // 
            // dt终止日期
            // 
            this.dt终止日期.abDefaultNow = true;
            this.dt终止日期.abEnterTab = true;
            this.dt终止日期.abGetAllFormat = false;
            this.dt终止日期.abLockInput = false;
            this.dt终止日期.abSaveId = false;
            this.dt终止日期.abViewModel = false;
            this.dt终止日期.acBackColor = System.Drawing.Color.Transparent;
            this.dt终止日期.acFontColor = System.Drawing.SystemColors.ControlText;
            this.dt终止日期.acLabelColor = System.Drawing.SystemColors.ControlText;
            this.dt终止日期.aeDataRule = ACtrllist.EDataRule.忽略;
            this.dt终止日期.aeDataType = ACtrllist.EDataType.String;
            this.dt终止日期.aeDateFormt = ACtrllist.EDispFormat.年月日时分秒;
            this.dt终止日期.afFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt终止日期.afLabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt终止日期.asCaption = "-";
            this.dt终止日期.asFieldName = "";
            this.dt终止日期.asFieldTableName = "";
            this.dt终止日期.asId = "";
            this.dt终止日期.asText = "";
            this.dt终止日期.BackColor = System.Drawing.Color.Transparent;
            this.dt终止日期.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt终止日期.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dt终止日期.Location = new System.Drawing.Point(294, 20);
            this.dt终止日期.Name = "dt终止日期";
            this.dt终止日期.Size = new System.Drawing.Size(197, 26);
            this.dt终止日期.TabIndex = 62;
            // 
            // lb时间
            // 
            this.lb时间.AutoSize = true;
            this.lb时间.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb时间.Location = new System.Drawing.Point(44, 24);
            this.lb时间.Name = "lb时间";
            this.lb时间.Size = new System.Drawing.Size(56, 16);
            this.lb时间.TabIndex = 63;
            this.lb时间.Text = "时间：";
            this.lb时间.Click += new System.EventHandler(this.label1_Click);
            // 
            // Fg结算信息查询
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 565);
            this.Controls.Add(this.lb时间);
            this.Controls.Add(this.dt终止日期);
            this.Controls.Add(this.dt开始日期);
            this.Controls.Add(this.txbx身份证);
            this.Controls.Add(this.grid费用明细);
            this.Controls.Add(this.btn导出Excel);
            this.Controls.Add(this.btn显示单据费用明细);
            this.Controls.Add(this.grid就诊信息);
            this.Controls.Add(this.aButton1);
            this.Controls.Add(this.btn查询);
            this.Controls.Add(this.txbx姓名);
            this.Name = "Fg结算信息查询";
            this.Text = "Fg医疗费用汇总";
            this.Load += new System.EventHandler(this.Fg医疗费用汇总_Load);
            this.Controls.SetChildIndex(this.txbx姓名, 0);
            this.Controls.SetChildIndex(this.btn查询, 0);
            this.Controls.SetChildIndex(this.aButton1, 0);
            this.Controls.SetChildIndex(this.grid就诊信息, 0);
            this.Controls.SetChildIndex(this.btn显示单据费用明细, 0);
            this.Controls.SetChildIndex(this.btn导出Excel, 0);
            this.Controls.SetChildIndex(this.grid费用明细, 0);
            this.Controls.SetChildIndex(this.txbx身份证, 0);
            this.Controls.SetChildIndex(this.dt开始日期, 0);
            this.Controls.SetChildIndex(this.dt终止日期, 0);
            this.Controls.SetChildIndex(this.lb时间, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ACtrllist.AButton aButton1;
        private ACtrllist.AButton btn查询;
        private ACtrllist.ATextBox txbx姓名;
        private ACtrllist.AGridList grid就诊信息;
        private ACtrllist.AButton btn导出Excel;
        private ACtrllist.AButton btn显示单据费用明细;
        private ACtrllist.AGridList grid费用明细;
        private ACtrllist.ATextBox txbx身份证;
        public ACtrllist.ADateInput dt开始日期;
        public ACtrllist.ADateInput dt终止日期;
        private System.Windows.Forms.Label lb时间;
    }
}