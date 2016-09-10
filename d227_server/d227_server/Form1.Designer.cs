namespace d227_server
{
    partial class CommandLauncher
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ipBegin1TextBox = new System.Windows.Forms.TextBox();
            this.ipBegin2TextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ipEnd2TextBox = new System.Windows.Forms.TextBox();
            this.ipEnd1TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.progressTextBox = new System.Windows.Forms.RichTextBox();
            this.NumberLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "进度窗口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(31, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP范围";
            // 
            // ipBegin1TextBox
            // 
            this.ipBegin1TextBox.Location = new System.Drawing.Point(94, 285);
            this.ipBegin1TextBox.Name = "ipBegin1TextBox";
            this.ipBegin1TextBox.Size = new System.Drawing.Size(135, 21);
            this.ipBegin1TextBox.TabIndex = 5;
            this.ipBegin1TextBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // ipBegin2TextBox
            // 
            this.ipBegin2TextBox.Location = new System.Drawing.Point(235, 285);
            this.ipBegin2TextBox.Name = "ipBegin2TextBox";
            this.ipBegin2TextBox.Size = new System.Drawing.Size(27, 21);
            this.ipBegin2TextBox.TabIndex = 6;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(543, 285);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(168, 21);
            this.PortTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(492, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "端口";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(268, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "~";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(46, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "命令";
            // 
            // commandTextBox
            // 
            this.commandTextBox.Location = new System.Drawing.Point(95, 320);
            this.commandTextBox.Multiline = true;
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commandTextBox.Size = new System.Drawing.Size(367, 90);
            this.commandTextBox.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(496, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 90);
            this.button1.TabIndex = 12;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipEnd2TextBox
            // 
            this.ipEnd2TextBox.Location = new System.Drawing.Point(434, 285);
            this.ipEnd2TextBox.Name = "ipEnd2TextBox";
            this.ipEnd2TextBox.Size = new System.Drawing.Size(27, 21);
            this.ipEnd2TextBox.TabIndex = 14;
            // 
            // ipEnd1TextBox
            // 
            this.ipEnd1TextBox.Location = new System.Drawing.Point(293, 285);
            this.ipEnd1TextBox.Name = "ipEnd1TextBox";
            this.ipEnd1TextBox.ReadOnly = true;
            this.ipEnd1TextBox.Size = new System.Drawing.Size(135, 21);
            this.ipEnd1TextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(388, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "结果窗口";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ResultTextBox.Location = new System.Drawing.Point(392, 35);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ResultTextBox.Size = new System.Drawing.Size(319, 229);
            this.ResultTextBox.TabIndex = 15;
            this.ResultTextBox.Text = "";
            // 
            // progressTextBox
            // 
            this.progressTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressTextBox.Location = new System.Drawing.Point(35, 35);
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.progressTextBox.Size = new System.Drawing.Size(319, 229);
            this.progressTextBox.TabIndex = 16;
            this.progressTextBox.Text = "";
            // 
            // NumberLable
            // 
            this.NumberLable.AutoSize = true;
            this.NumberLable.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumberLable.Location = new System.Drawing.Point(718, 251);
            this.NumberLable.Name = "NumberLable";
            this.NumberLable.Size = new System.Drawing.Size(14, 13);
            this.NumberLable.TabIndex = 17;
            this.NumberLable.Text = "0";
            // 
            // CommandLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 425);
            this.Controls.Add(this.NumberLable);
            this.Controls.Add(this.progressTextBox);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ipEnd2TextBox);
            this.Controls.Add(this.ipEnd1TextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.ipBegin2TextBox);
            this.Controls.Add(this.ipBegin1TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CommandLauncher";
            this.Text = "命令发射器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ipBegin1TextBox;
        private System.Windows.Forms.TextBox ipBegin2TextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ipEnd2TextBox;
        private System.Windows.Forms.TextBox ipEnd1TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.RichTextBox progressTextBox;
        private System.Windows.Forms.Label NumberLable;
    }
}

