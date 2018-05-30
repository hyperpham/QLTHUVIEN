namespace QLTHUVIEN.form
{
    partial class TKSach
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoTg = new System.Windows.Forms.RadioButton();
            this.rdoNn = new System.Windows.Forms.RadioButton();
            this.rdoNxb = new System.Windows.Forms.RadioButton();
            this.rdoVt = new System.Windows.Forms.RadioButton();
            this.rdoTl = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoTg);
            this.groupBox1.Controls.Add(this.rdoNn);
            this.groupBox1.Controls.Add(this.rdoNxb);
            this.groupBox1.Controls.Add(this.rdoVt);
            this.groupBox1.Controls.Add(this.rdoTl);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tiêu chí";
            // 
            // rdoTg
            // 
            this.rdoTg.AutoSize = true;
            this.rdoTg.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTg.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoTg.Location = new System.Drawing.Point(269, 59);
            this.rdoTg.Name = "rdoTg";
            this.rdoTg.Size = new System.Drawing.Size(75, 24);
            this.rdoTg.TabIndex = 12;
            this.rdoTg.TabStop = true;
            this.rdoTg.Text = "Tác giả";
            this.rdoTg.UseVisualStyleBackColor = true;
            this.rdoTg.CheckedChanged += new System.EventHandler(this.rdoTg_CheckedChanged);
            // 
            // rdoNn
            // 
            this.rdoNn.AutoSize = true;
            this.rdoNn.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNn.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoNn.Location = new System.Drawing.Point(526, 59);
            this.rdoNn.Name = "rdoNn";
            this.rdoNn.Size = new System.Drawing.Size(91, 24);
            this.rdoNn.TabIndex = 11;
            this.rdoNn.TabStop = true;
            this.rdoNn.Text = "Ngôn ngữ";
            this.rdoNn.UseVisualStyleBackColor = true;
            this.rdoNn.CheckedChanged += new System.EventHandler(this.rdoNn_CheckedChanged);
            // 
            // rdoNxb
            // 
            this.rdoNxb.AutoSize = true;
            this.rdoNxb.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNxb.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoNxb.Location = new System.Drawing.Point(384, 59);
            this.rdoNxb.Name = "rdoNxb";
            this.rdoNxb.Size = new System.Drawing.Size(117, 24);
            this.rdoNxb.TabIndex = 10;
            this.rdoNxb.TabStop = true;
            this.rdoNxb.Text = "Nhà xuất bản";
            this.rdoNxb.UseVisualStyleBackColor = true;
            this.rdoNxb.CheckedChanged += new System.EventHandler(this.rdoNxb_CheckedChanged);
            // 
            // rdoVt
            // 
            this.rdoVt.AutoSize = true;
            this.rdoVt.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoVt.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoVt.Location = new System.Drawing.Point(148, 59);
            this.rdoVt.Name = "rdoVt";
            this.rdoVt.Size = new System.Drawing.Size(61, 24);
            this.rdoVt.TabIndex = 9;
            this.rdoVt.TabStop = true;
            this.rdoVt.Text = "Vị trí";
            this.rdoVt.UseVisualStyleBackColor = true;
            this.rdoVt.CheckedChanged += new System.EventHandler(this.rdoVt_CheckedChanged);
            // 
            // rdoTl
            // 
            this.rdoTl.AutoSize = true;
            this.rdoTl.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTl.ForeColor = System.Drawing.Color.MidnightBlue;
            this.rdoTl.Location = new System.Drawing.Point(16, 59);
            this.rdoTl.Name = "rdoTl";
            this.rdoTl.Size = new System.Drawing.Size(79, 24);
            this.rdoTl.TabIndex = 8;
            this.rdoTl.TabStop = true;
            this.rdoTl.Text = "Thể loại";
            this.rdoTl.UseVisualStyleBackColor = true;
            this.rdoTl.CheckedChanged += new System.EventHandler(this.rdoTl_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(15, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Thống kê theo các chuẩn :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 315);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(6, 19);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.Size = new System.Drawing.Size(623, 290);
            this.DataGridView1.TabIndex = 0;
            // 
            // TKSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(659, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TKSach";
            this.Text = "Thống kê số lượng sách";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.RadioButton rdoTl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdoTg;
        private System.Windows.Forms.RadioButton rdoNn;
        private System.Windows.Forms.RadioButton rdoNxb;
        private System.Windows.Forms.RadioButton rdoVt;
    }
}