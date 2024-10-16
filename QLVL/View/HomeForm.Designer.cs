namespace QLVL.View
{
    partial class HomeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dkhome = new System.Windows.Forms.Button();
            this.btn_dnhome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(84, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng đến với hệ thống quản lý vật liệu của chúng tôi";
            // 
            // btn_dkhome
            // 
            this.btn_dkhome.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_dkhome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dkhome.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_dkhome.Location = new System.Drawing.Point(321, 151);
            this.btn_dkhome.Name = "btn_dkhome";
            this.btn_dkhome.Size = new System.Drawing.Size(162, 56);
            this.btn_dkhome.TabIndex = 1;
            this.btn_dkhome.Text = "ĐĂNG KÝ";
            this.btn_dkhome.UseVisualStyleBackColor = false;
            this.btn_dkhome.Click += new System.EventHandler(this.btn_dkhome_Click);
            // 
            // btn_dnhome
            // 
            this.btn_dnhome.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_dnhome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dnhome.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_dnhome.Location = new System.Drawing.Point(321, 243);
            this.btn_dnhome.Name = "btn_dnhome";
            this.btn_dnhome.Size = new System.Drawing.Size(162, 57);
            this.btn_dnhome.TabIndex = 2;
            this.btn_dnhome.Text = "ĐĂNG NHẬP";
            this.btn_dnhome.UseVisualStyleBackColor = false;
            this.btn_dnhome.Click += new System.EventHandler(this.btn_dnhome_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_dnhome);
            this.Controls.Add(this.btn_dkhome);
            this.Controls.Add(this.label1);
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dkhome;
        private System.Windows.Forms.Button btn_dnhome;
    }
}