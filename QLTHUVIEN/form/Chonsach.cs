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
    public partial class Chonsach : Form
    {
        public Chonsach()
        {
            InitializeComponent();
        }

        DataTable dmSach, dmchon;

        private void Chonsach_Load(object sender, EventArgs e)
        {
            dgvDm_load(); 
            lbMpm.Text = form.HDMuon.mpm;
            dgvCs_load();
            lbSosach.Text = dmchon.Rows.Count.ToString();
        }

        private void dgvDm_load()
        {
            string sql;
            sql = "SELECT MASACH,TENSACH,TENTG FROM SACH,TACGIA WHERE TACGIA.MATG=SACH.MATG";
            dmSach = Class.Functions.GetDataToTable(sql);
            dgvDm.DataSource = dmSach;
            dgvDm.Columns[0].HeaderText = "Mã sách";
            dgvDm.Columns[1].HeaderText = "Tên sách";
            dgvDm.Columns[2].HeaderText = "Tên tác giả";
            dgvDm.Columns[0].Width = 70;
            dgvDm.Columns[1].Width = 200;
            dgvDm.Columns[2].Width = 150;
        }

        private void dgvDm_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MAPM,MASACH FROM CHITIETMUON WHERE MAPM='" + lbMpm.Text.Trim() + "' AND MASACH ='" + dgvDm.CurrentRow.Cells["MASACH"].Value.ToString() + "'";
            if (Class.Functions.CheckKey(sql))
            {

                return;
            }
            sql = "INSERT INTO CHITIETMUON VALUES ('" + lbMpm.Text.Trim() + "','" + dgvDm.CurrentRow.Cells["MASACH"].Value.ToString() + "')";
            Class.Functions.RunSql(sql);
            dgvCs_load();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            form.HDMuon.soluong = Convert.ToInt32(lbSosach.Text.ToString());
            this.Dispose();
        }

        private void dgvDc_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM CHITIETMUON WHERE MAPM='" + lbMpm.Text.Trim() + "' AND MASACH='" + dgvDc.CurrentRow.Cells["MASACH"].Value.ToString() + "'";
            Class.Functions.RunSqlDel(sql);
            dgvCs_load();
        }

        private void dgvCs_load()
        {
            string sql;
            sql = "SELECT SACH.MASACH,TENSACH,TENTG FROM SACH,TACGIA,CHITIETMUON WHERE TACGIA.MATG=SACH.MATG AND CHITIETMUON.MASACH=SACH.MASACH AND MAPM='" + lbMpm.Text.Trim() + "'";
            dmchon = Class.Functions.GetDataToTable(sql);
            dgvDc.DataSource = dmchon;
            dgvDc.Columns[0].HeaderText = "Mã sách";
            dgvDc.Columns[1].HeaderText = "Tên sách";
            dgvDc.Columns[2].HeaderText = "Tên tác giả";
            dgvDc.Columns[0].Width = 70;
            dgvDc.Columns[1].Width = 200;
            dgvDc.Columns[2].Width = 150;
            lbSosach.Text = dmchon.Rows.Count.ToString();
        }


    }
}
