namespace RoleGen
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
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnCreateScript = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrlRole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkVietin = new System.Windows.Forms.CheckBox();
            this.chkMXV = new System.Windows.Forms.CheckBox();
            this.chkTech = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.cb_RoleGroup = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(12, 120);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(954, 317);
            this.txtDisplay.TabIndex = 54;
            // 
            // btnCreateScript
            // 
            this.btnCreateScript.Location = new System.Drawing.Point(12, 12);
            this.btnCreateScript.Name = "btnCreateScript";
            this.btnCreateScript.Size = new System.Drawing.Size(75, 23);
            this.btnCreateScript.TabIndex = 55;
            this.btnCreateScript.Text = "Tạo script";
            this.btnCreateScript.UseVisualStyleBackColor = true;
            this.btnCreateScript.Click += new System.EventHandler(this.btnCreateScript_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(891, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textUrl
            // 
            this.textUrl.Location = new System.Drawing.Point(566, 61);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(390, 20);
            this.textUrl.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(387, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Nếu cần thay thế RoleKey cũ bằng RoleKey mới thì nhập được dẫn đến terminal";
            // 
            // txtUrlRole
            // 
            this.txtUrlRole.Location = new System.Drawing.Point(502, 35);
            this.txtUrlRole.Name = "txtUrlRole";
            this.txtUrlRole.Size = new System.Drawing.Size(390, 20);
            this.txtUrlRole.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Nhập đường dẫn đến ma trận phân quyền";
            // 
            // chkVietin
            // 
            this.chkVietin.AutoSize = true;
            this.chkVietin.Location = new System.Drawing.Point(184, 16);
            this.chkVietin.Name = "chkVietin";
            this.chkVietin.Size = new System.Drawing.Size(76, 17);
            this.chkVietin.TabIndex = 63;
            this.chkVietin.Text = "Vietinbank";
            this.chkVietin.UseVisualStyleBackColor = true;
            this.chkVietin.CheckedChanged += new System.EventHandler(this.chkVietin_CheckedChanged);
            // 
            // chkMXV
            // 
            this.chkMXV.AutoSize = true;
            this.chkMXV.Location = new System.Drawing.Point(129, 16);
            this.chkMXV.Name = "chkMXV";
            this.chkMXV.Size = new System.Drawing.Size(49, 17);
            this.chkMXV.TabIndex = 64;
            this.chkMXV.Text = "MXV";
            this.chkMXV.UseVisualStyleBackColor = true;
            this.chkMXV.CheckedChanged += new System.EventHandler(this.chkMXV_CheckedChanged);
            // 
            // chkTech
            // 
            this.chkTech.AutoSize = true;
            this.chkTech.Location = new System.Drawing.Point(266, 16);
            this.chkTech.Name = "chkTech";
            this.chkTech.Size = new System.Drawing.Size(95, 17);
            this.chkTech.TabIndex = 65;
            this.chkTech.Text = "Techcombank";
            this.chkTech.UseVisualStyleBackColor = true;
            this.chkTech.CheckedChanged += new System.EventHandler(this.chkTech_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Nhập tên Sheet:";
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(103, 97);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(278, 20);
            this.txtSheetName.TabIndex = 67;
            // 
            // cb_RoleGroup
            // 
            this.cb_RoleGroup.AutoSize = true;
            this.cb_RoleGroup.Enabled = false;
            this.cb_RoleGroup.ForeColor = System.Drawing.Color.Red;
            this.cb_RoleGroup.Location = new System.Drawing.Point(15, 64);
            this.cb_RoleGroup.Name = "cb_RoleGroup";
            this.cb_RoleGroup.Size = new System.Drawing.Size(140, 17);
            this.cb_RoleGroup.TabIndex = 68;
            this.cb_RoleGroup.Text = "Có Gen lại Nhóm Quyền";
            this.cb_RoleGroup.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 69;
            this.label4.Text = "Made By: KingKong";
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(897, 33);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(28, 23);
            this.btn_open.TabIndex = 70;
            this.btn_open.Text = "...";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.Btn_open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 484);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_RoleGroup);
            this.Controls.Add(this.txtSheetName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTech);
            this.Controls.Add(this.chkMXV);
            this.Controls.Add(this.chkVietin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUrlRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateScript);
            this.Controls.Add(this.txtDisplay);
            this.Name = "Form1";
            this.Text = "RoleGen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnCreateScript;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrlRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkVietin;
        private System.Windows.Forms.CheckBox chkMXV;
        private System.Windows.Forms.CheckBox chkTech;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSheetName;
        private System.Windows.Forms.CheckBox cb_RoleGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_open;
    }
}

