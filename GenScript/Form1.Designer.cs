namespace GenScript
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
            this.txb_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_gen = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txb_url
            // 
            this.txb_url.Location = new System.Drawing.Point(12, 46);
            this.txb_url.Name = "txb_url";
            this.txb_url.Size = new System.Drawing.Size(446, 20);
            this.txb_url.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL File:";
            // 
            // btn_gen
            // 
            this.btn_gen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_gen.Location = new System.Drawing.Point(696, 43);
            this.btn_gen.Name = "btn_gen";
            this.btn_gen.Size = new System.Drawing.Size(75, 23);
            this.btn_gen.TabIndex = 2;
            this.btn_gen.Text = "Gen";
            this.btn_gen.UseVisualStyleBackColor = true;
            this.btn_gen.Click += new System.EventHandler(this.btn_Gen_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aqua;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(667, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 23);
            this.button2.TabIndex = 58;
            this.button2.Text = "Copy To Clipboard";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // txtDisplay
            // 
            this.txtDisplay.Location = new System.Drawing.Point(12, 72);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDisplay.Size = new System.Drawing.Size(759, 317);
            this.txtDisplay.TabIndex = 57;
            // 
            // btn_open
            // 
            this.btn_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_open.Location = new System.Drawing.Point(464, 45);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(75, 23);
            this.btn_open.TabIndex = 59;
            this.btn_open.Text = "Open";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.Btn_open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 449);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btn_gen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txb_url);
            this.Name = "Form1";
            this.Text = "GenScript";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_gen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btn_open;
    }
}

