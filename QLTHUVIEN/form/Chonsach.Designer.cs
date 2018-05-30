namespace QLTHUVIEN.form
{
    partial class Chonsach
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDm = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDc = new System.Windows.Forms.DataGridView();
            this.lbMpm = new System.Windows.Forms.Label();
            this.lbSosach = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDm)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDm);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 426);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh mục";
            // 
            // dgvDm
            // 
            this.dgvDm.AllowUserToAddRows = false;
            this.dgvDm.AllowUserToDeleteRows = false;
            this.dgvDm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDm.Location = new System.Drawing.Point(6, 19);
            this.dgvDm.Name = "dgvDm";
            this.dgvDm.ReadOnly = true;
            this.dgvDm.Size = new System.Drawing.Size(449, 401);
            this.dgvDm.TabIndex = 0;
            this.dgvDm.Click += new System.EventHandler(this.dgvDm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.lbSosach);
            this.groupBox1.Controls.Add(this.lbMpm);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 92);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Số sách đã chọn :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã phiếu mượn :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvDc);
            this.groupBox3.Location = new System.Drawing.Point(482, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(441, 426);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đã chọn";
            // 
            // dgvDc
            // 
            this.dgvDc.AllowUserToAddRows = false;
            this.dgvDc.AllowUserToDeleteRows = false;
            this.dgvDc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDc.Location = new System.Drawing.Point(6, 19);
            this.dgvDc.Name = "dgvDc";
            this.dgvDc.ReadOnly = true;
            this.dgvDc.Size = new System.Drawing.Size(427, 401);
            this.dgvDc.TabIndex = 0;
            this.dgvDc.Click += new System.EventHandler(this.dgvDc_Click);
            // 
            // lbMpm
            // 
            this.lbMpm.AutoSize = true;
            this.lbMpm.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMpm.ForeColor = System.Drawing.Color.Red;
            this.lbMpm.Location = new System.Drawing.Point(146, 18);
            this.lbMpm.Name = "lbMpm";
            this.lbMpm.Size = new System.Drawing.Size(0, 19);
            this.lbMpm.TabIndex = 17;
            // 
            // lbSosach
            // 
            this.lbSosach.AutoSize = true;
            this.lbSosach.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSosach.ForeColor = System.Drawing.Color.Red;
            this.lbSosach.Location = new System.Drawing.Point(142, 56);
            this.lbSosach.Name = "lbSosach";
            this.lbSosach.Size = new System.Drawing.Size(17, 19);
            this.lbSosach.TabIndex = 18;
            this.lbSosach.Text = "0";
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnDong.Image = global::QLTHUVIEN.Properties.Resources.sign_check_icon;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(814, 29);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(89, 37);
            this.btnDong.TabIndex = 19;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Chonsach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(927, 548);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Chonsach";
            this.Text = "Chọn sách để mượn";
            this.Load += new System.EventHandler(this.Chonsach_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDm)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDc;
        private System.Windows.Forms.Label lbMpm;
        private System.Windows.Forms.Label lbSosach;
        private System.Windows.Forms.Button btnDong;
    }
}