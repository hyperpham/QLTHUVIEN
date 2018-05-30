using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN.form
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            Class.Functions.Connect();
            InitializeComponent();
        }

        private void mnitSach_Click(object sender, EventArgs e)
        {
            form.DMSach dmsach = new form.DMSach();
            dmsach.ShowDialog();
        }

        private void mnitTheloai_Click(object sender, EventArgs e)
        {
            form.DMTheloai dmtheloai = new form.DMTheloai();
            dmtheloai.ShowDialog();
        }

        private void mnitTacgia_Click(object sender, EventArgs e)
        {
            form.DMTacgia dmtacgia = new form.DMTacgia();
            dmtacgia.ShowDialog();
        }

        private void vịTríToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DMVitri dmvitri = new DMVitri();
            dmvitri.ShowDialog();
        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DMNhaxuatban dmnxb = new DMNhaxuatban();
            dmnxb.ShowDialog();
        }

        private void Mainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ngônNgữToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DMNgonngu dmnn = new DMNgonngu();
            dmnn.ShowDialog();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.TKSach tksach = new TKSach();
            tksach.ShowDialog();
        }

        private void hóaĐơnMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.HDMuon hdm = new HDMuon();
            hdm.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DMDocgia docgia = new DMDocgia();
            docgia.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form.DMNhanvien nhanvien = new DMNhanvien();
            nhanvien.Show();
        }
    }
}
