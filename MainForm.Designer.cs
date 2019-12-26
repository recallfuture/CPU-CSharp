namespace Computer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxRegisters = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSr = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBoxCode = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBoxBCode = new System.Windows.Forms.ListBox();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonStep = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIr = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxRr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxRd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxLa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxLt = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.listBoxCycle = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxMCode = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxImdr = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxImar = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxRegisters
            // 
            this.listBoxRegisters.FormattingEnabled = true;
            this.listBoxRegisters.ItemHeight = 15;
            this.listBoxRegisters.Location = new System.Drawing.Point(174, 384);
            this.listBoxRegisters.Name = "listBoxRegisters";
            this.listBoxRegisters.Size = new System.Drawing.Size(156, 229);
            this.listBoxRegisters.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(170, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "通用寄存器：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(8, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "SR状态位：";
            // 
            // listBoxSr
            // 
            this.listBoxSr.FormattingEnabled = true;
            this.listBoxSr.ItemHeight = 15;
            this.listBoxSr.Location = new System.Drawing.Point(12, 384);
            this.listBoxSr.Name = "listBoxSr";
            this.listBoxSr.Size = new System.Drawing.Size(156, 229);
            this.listBoxSr.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "PC: 0x";
            // 
            // textBoxPc
            // 
            this.textBoxPc.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPc.Location = new System.Drawing.Point(97, 23);
            this.textBoxPc.Name = "textBoxPc";
            this.textBoxPc.ReadOnly = true;
            this.textBoxPc.Size = new System.Drawing.Size(92, 30);
            this.textBoxPc.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "汇编指令：";
            // 
            // listBoxCode
            // 
            this.listBoxCode.FormattingEnabled = true;
            this.listBoxCode.ItemHeight = 15;
            this.listBoxCode.Location = new System.Drawing.Point(12, 55);
            this.listBoxCode.Name = "listBoxCode";
            this.listBoxCode.Size = new System.Drawing.Size(188, 274);
            this.listBoxCode.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(202, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "机器指令：";
            // 
            // listBoxBCode
            // 
            this.listBoxBCode.FormattingEnabled = true;
            this.listBoxBCode.ItemHeight = 15;
            this.listBoxBCode.Location = new System.Drawing.Point(206, 55);
            this.listBoxBCode.Name = "listBoxBCode";
            this.listBoxBCode.Size = new System.Drawing.Size(256, 274);
            this.listBoxBCode.TabIndex = 8;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(12, 644);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(128, 28);
            this.buttonImport.TabIndex = 10;
            this.buttonImport.Text = "导入汇编";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Location = new System.Drawing.Point(146, 644);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(128, 28);
            this.buttonStep.TabIndex = 11;
            this.buttonStep.Text = "单条执行";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(280, 644);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(128, 28);
            this.buttonRun.TabIndex = 12;
            this.buttonRun.Text = "全部执行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(414, 644);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(128, 28);
            this.buttonReset.TabIndex = 13;
            this.buttonReset.Text = "重置";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "test.data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(11, 683);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(413, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "运行结果保存在当前目录下的output.txt中";
            // 
            // textBoxBus
            // 
            this.textBoxBus.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBus.Location = new System.Drawing.Point(304, 23);
            this.textBoxBus.Name = "textBoxBus";
            this.textBoxBus.ReadOnly = true;
            this.textBoxBus.Size = new System.Drawing.Size(92, 30);
            this.textBoxBus.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(209, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "BUS:  0x";
            // 
            // textBoxIr
            // 
            this.textBoxIr.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIr.Location = new System.Drawing.Point(97, 80);
            this.textBoxIr.Name = "textBoxIr";
            this.textBoxIr.ReadOnly = true;
            this.textBoxIr.Size = new System.Drawing.Size(92, 30);
            this.textBoxIr.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(22, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "IR: 0x";
            // 
            // textBoxRr
            // 
            this.textBoxRr.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRr.Location = new System.Drawing.Point(304, 77);
            this.textBoxRr.Name = "textBoxRr";
            this.textBoxRr.ReadOnly = true;
            this.textBoxRr.Size = new System.Drawing.Size(92, 30);
            this.textBoxRr.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(209, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "RR:   0x";
            // 
            // textBoxRd
            // 
            this.textBoxRd.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRd.Location = new System.Drawing.Point(97, 131);
            this.textBoxRd.Name = "textBoxRd";
            this.textBoxRd.ReadOnly = true;
            this.textBoxRd.Size = new System.Drawing.Size(92, 30);
            this.textBoxRd.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(22, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "RD: 0x";
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTemp.Location = new System.Drawing.Point(304, 131);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.ReadOnly = true;
            this.textBoxTemp.Size = new System.Drawing.Size(92, 30);
            this.textBoxTemp.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(209, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "TEMP: 0x";
            // 
            // textBoxLa
            // 
            this.textBoxLa.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLa.Location = new System.Drawing.Point(97, 185);
            this.textBoxLa.Name = "textBoxLa";
            this.textBoxLa.ReadOnly = true;
            this.textBoxLa.Size = new System.Drawing.Size(92, 30);
            this.textBoxLa.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(22, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "LA: 0x";
            // 
            // textBoxLt
            // 
            this.textBoxLt.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxLt.Location = new System.Drawing.Point(304, 185);
            this.textBoxLt.Name = "textBoxLt";
            this.textBoxLt.ReadOnly = true;
            this.textBoxLt.Size = new System.Drawing.Size(92, 30);
            this.textBoxLt.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(209, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "LT:   0x";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(834, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 24);
            this.label14.TabIndex = 17;
            this.label14.Text = "指令周期：";
            // 
            // listBoxCycle
            // 
            this.listBoxCycle.FormattingEnabled = true;
            this.listBoxCycle.ItemHeight = 15;
            this.listBoxCycle.Location = new System.Drawing.Point(838, 55);
            this.listBoxCycle.Name = "listBoxCycle";
            this.listBoxCycle.Size = new System.Drawing.Size(156, 274);
            this.listBoxCycle.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(464, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 24);
            this.label15.TabIndex = 19;
            this.label15.Text = "微指令：";
            // 
            // listBoxMCode
            // 
            this.listBoxMCode.FormattingEnabled = true;
            this.listBoxMCode.ItemHeight = 15;
            this.listBoxMCode.Location = new System.Drawing.Point(468, 55);
            this.listBoxMCode.Name = "listBoxMCode";
            this.listBoxMCode.Size = new System.Drawing.Size(364, 274);
            this.listBoxMCode.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.textBoxImdr);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.textBoxImar);
            this.panel1.Controls.Add(this.textBoxLt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxPc);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxBus);
            this.panel1.Controls.Add(this.textBoxLa);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxIr);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxRr);
            this.panel1.Controls.Add(this.textBoxTemp);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBoxRd);
            this.panel1.Location = new System.Drawing.Point(336, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 229);
            this.panel1.TabIndex = 20;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(426, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 22;
            this.label18.Text = "IMDR:  0x";
            // 
            // textBoxImdr
            // 
            this.textBoxImdr.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxImdr.Location = new System.Drawing.Point(531, 77);
            this.textBoxImdr.Name = "textBoxImdr";
            this.textBoxImdr.ReadOnly = true;
            this.textBoxImdr.Size = new System.Drawing.Size(92, 30);
            this.textBoxImdr.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(426, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 20);
            this.label17.TabIndex = 20;
            this.label17.Text = "IMAR:  0x";
            // 
            // textBoxImar
            // 
            this.textBoxImar.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxImar.Location = new System.Drawing.Point(531, 23);
            this.textBoxImar.Name = "textBoxImar";
            this.textBoxImar.ReadOnly = true;
            this.textBoxImar.Size = new System.Drawing.Size(92, 30);
            this.textBoxImar.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(332, 348);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 24);
            this.label16.TabIndex = 21;
            this.label16.Text = "私有寄存器：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBoxMCode);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.listBoxCycle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonStep);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBoxBCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxSr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxRegisters);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易CPU模拟器";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRegisters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBoxCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBoxBCode;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxLt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxRd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxRr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxIr;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxBus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox listBoxCycle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxMCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxImdr;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxImar;
    }
}

