namespace UpdateServer
{
    partial class Form1
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
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.FileButton = new System.Windows.Forms.Button();
            this.CommandTextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BeginTextBox = new System.Windows.Forms.TextBox();
            this.EndTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.Updatebutton = new System.Windows.Forms.Button();
            this.PortTextbox2 = new System.Windows.Forms.TextBox();
            this.NumLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(32, 35);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(208, 21);
            this.fileTextBox.TabIndex = 0;
            this.fileTextBox.TextChanged += new System.EventHandler(this.fileTextBox_TextChanged);
            // 
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(246, 35);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(75, 23);
            this.FileButton.TabIndex = 1;
            this.FileButton.Text = "浏览";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // CommandTextBox
            // 
            this.CommandTextBox.Location = new System.Drawing.Point(32, 69);
            this.CommandTextBox.Multiline = true;
            this.CommandTextBox.Name = "CommandTextBox";
            this.CommandTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CommandTextBox.Size = new System.Drawing.Size(289, 168);
            this.CommandTextBox.TabIndex = 2;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(339, 35);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ResultTextBox.Size = new System.Drawing.Size(266, 372);
            this.ResultTextBox.TabIndex = 3;
            this.ResultTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP段";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(68, 247);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(253, 21);
            this.IPTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "范围";
            // 
            // BeginTextBox
            // 
            this.BeginTextBox.Location = new System.Drawing.Point(68, 276);
            this.BeginTextBox.Name = "BeginTextBox";
            this.BeginTextBox.Size = new System.Drawing.Size(33, 21);
            this.BeginTextBox.TabIndex = 7;
            // 
            // EndTextBox
            // 
            this.EndTextBox.Location = new System.Drawing.Point(121, 276);
            this.EndTextBox.Name = "EndTextBox";
            this.EndTextBox.Size = new System.Drawing.Size(33, 21);
            this.EndTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "~";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "端口";
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(207, 276);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(46, 21);
            this.PortTextbox.TabIndex = 11;
            // 
            // Updatebutton
            // 
            this.Updatebutton.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Updatebutton.Location = new System.Drawing.Point(32, 306);
            this.Updatebutton.Name = "Updatebutton";
            this.Updatebutton.Size = new System.Drawing.Size(289, 101);
            this.Updatebutton.TabIndex = 12;
            this.Updatebutton.Text = "升级";
            this.Updatebutton.UseVisualStyleBackColor = true;
            this.Updatebutton.Click += new System.EventHandler(this.Updatebutton_Click);
            // 
            // PortTextbox2
            // 
            this.PortTextbox2.Location = new System.Drawing.Point(272, 276);
            this.PortTextbox2.Name = "PortTextbox2";
            this.PortTextbox2.Size = new System.Drawing.Size(49, 21);
            this.PortTextbox2.TabIndex = 13;
            // 
            // NumLable
            // 
            this.NumLable.AutoSize = true;
            this.NumLable.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumLable.Location = new System.Drawing.Point(611, 392);
            this.NumLable.Name = "NumLable";
            this.NumLable.Size = new System.Drawing.Size(14, 13);
            this.NumLable.TabIndex = 14;
            this.NumLable.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 419);
            this.Controls.Add(this.NumLable);
            this.Controls.Add(this.PortTextbox2);
            this.Controls.Add(this.Updatebutton);
            this.Controls.Add(this.PortTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EndTextBox);
            this.Controls.Add(this.BeginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.CommandTextBox);
            this.Controls.Add(this.FileButton);
            this.Controls.Add(this.fileTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.TextBox CommandTextBox;
        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BeginTextBox;
        private System.Windows.Forms.TextBox EndTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.Button Updatebutton;
        private System.Windows.Forms.TextBox PortTextbox2;
        private System.Windows.Forms.Label NumLable;

    }
}

