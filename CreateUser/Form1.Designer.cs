namespace CreateUser
{
    partial class Form1
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
            this.chk_tsc = new System.Windows.Forms.CheckBox();
            this.chk_cn = new System.Windows.Forms.CheckBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_copy = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.chk_fx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chk_tsc
            // 
            this.chk_tsc.AutoSize = true;
            this.chk_tsc.Location = new System.Drawing.Point(13, 45);
            this.chk_tsc.Name = "chk_tsc";
            this.chk_tsc.Size = new System.Drawing.Size(87, 17);
            this.chk_tsc.TabIndex = 0;
            this.chk_tsc.Text = "Trụ sở chính";
            this.chk_tsc.UseVisualStyleBackColor = true;
            this.chk_tsc.CheckedChanged += new System.EventHandler(this.Chk_tsc_CheckedChanged);
            // 
            // chk_cn
            // 
            this.chk_cn.AutoSize = true;
            this.chk_cn.Location = new System.Drawing.Point(117, 45);
            this.chk_cn.Name = "chk_cn";
            this.chk_cn.Size = new System.Drawing.Size(74, 17);
            this.chk_cn.TabIndex = 1;
            this.chk_cn.Text = "Chi nhánh";
            this.chk_cn.UseVisualStyleBackColor = true;
            this.chk_cn.CheckedChanged += new System.EventHandler(this.Chk_cn_CheckedChanged);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(324, 45);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.Btn_create_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 68);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(111, 20);
            this.txt_name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên người dùng (Viết liền không dấu)";
            // 
            // btn_copy
            // 
            this.btn_copy.BackColor = System.Drawing.Color.Aqua;
            this.btn_copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_copy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_copy.Location = new System.Drawing.Point(596, 375);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(105, 23);
            this.btn_copy.TabIndex = 60;
            this.btn_copy.Text = "Copy To Clipboard";
            this.btn_copy.UseVisualStyleBackColor = false;
            this.btn_copy.Click += new System.EventHandler(this.Btn_copy_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(13, 94);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_result.Size = new System.Drawing.Size(685, 275);
            this.txt_result.TabIndex = 59;
            // 
            // chk_fx
            // 
            this.chk_fx.AutoSize = true;
            this.chk_fx.Location = new System.Drawing.Point(324, 75);
            this.chk_fx.Name = "chk_fx";
            this.chk_fx.Size = new System.Drawing.Size(261, 17);
            this.chk_fx.TabIndex = 62;
            this.chk_fx.Text = "Tài khoản đăng nhập sẽ là \"fx. + tên người dùng\"";
            this.chk_fx.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 450);
            this.Controls.Add(this.chk_fx);
            this.Controls.Add(this.btn_copy);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.chk_cn);
            this.Controls.Add(this.chk_tsc);
            this.Name = "Form1";
            this.Text = "CreateUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_tsc;
        private System.Windows.Forms.CheckBox chk_cn;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.CheckBox chk_fx;
    }
}

