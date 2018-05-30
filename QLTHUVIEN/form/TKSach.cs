using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTHUVIEN.Class;

namespace QLTHUVIEN.form
{
    public partial class TKSach : Form
    {
        public TKSach()
        {
            InitializeComponent();
        }

        DataTable tblThongke;
        string sql;

        private void rdoTl_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTl.Checked == true)
            {
                rdoVt.Checked = false;
                rdoTg.Checked = false;
                rdoNxb.Checked = false;
                rdoNn.Checked = false;

                sql = "SELECT THELOAI.MATL,TENTL,COUNT(SACH.MATL) FROM SACH,THELOAI WHERE SACH.MATL=THELOAI.MATL GROUP BY THELOAI.MATL,TENTL";
                tblThongke = Functions.GetDataToTable(sql);
                DataGridView1.DataSource = tblThongke;
                DataGridView1.Columns[0].HeaderText = "Mã thể loại";
                DataGridView1.Columns[1].HeaderText = "Tên thể loại";
                DataGridView1.Columns[2].HeaderText = "Số lượng";
                DataGridView1.Columns[0].Width = 200;
                DataGridView1.Columns[1].Width = 200;
                DataGridView1.Columns[2].Width = 150;
                DataGridView1.AllowUserToAddRows = false;
                DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void rdoVt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVt.Checked == true)
            {
                rdoTl.Checked = false;
                rdoTg.Checked = false;
                rdoNxb.Checked = false;
                rdoNn.Checked = false;

                sql = "SELECT VITRI.MAVT,VITRI,COUNT(SACH.MAVT) FROM SACH,VITRI WHERE SACH.MAVT=VITRI.MAVT GROUP BY VITRI.MAVT,VITRI";
                tblThongke = Functions.GetDataToTable(sql);
                DataGridView1.DataSource = tblThongke;
                DataGridView1.Columns[0].HeaderText = "Mã vị trí";
                DataGridView1.Columns[1].HeaderText = "Tên vị trí";
                DataGridView1.Columns[2].HeaderText = "Số lượng";
                DataGridView1.Columns[0].Width = 200;
                DataGridView1.Columns[1].Width = 200;
                DataGridView1.Columns[2].Width = 150;
                DataGridView1.AllowUserToAddRows = false;
                DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void rdoTg_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTg.Checked == true)
            {
                rdoVt.Checked = false;
                rdoTl.Checked = false;
                rdoNxb.Checked = false;
                rdoNn.Checked = false;

                sql = "SELECT TACGIA.MATG,TENTG,COUNT(SACH.MATG) FROM SACH,TACGIA WHERE SACH.MATG=TACGIA.MATG GROUP BY TACGIA.MATG,TENTG";
                tblThongke = Functions.GetDataToTable(sql);
                DataGridView1.DataSource = tblThongke;
                DataGridView1.Columns[0].HeaderText = "Mã tác giả";
                DataGridView1.Columns[1].HeaderText = "Tên tác giả";
                DataGridView1.Columns[2].HeaderText = "Số lượng";
                DataGridView1.Columns[0].Width = 200;
                DataGridView1.Columns[1].Width = 200;
                DataGridView1.Columns[2].Width = 150;
                DataGridView1.AllowUserToAddRows = false;
                DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void rdoNxb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNxb.Checked == true)
            {
                rdoVt.Checked = false;
                rdoTl.Checked = false;
                rdoTg.Checked = false;
                rdoNn.Checked = false;

                sql = "SELECT NHAXUATBAN.MANXB,TENNXB,COUNT(SACH.MANXB) FROM SACH,NHAXUATBAN WHERE SACH.MANXB=NHAXUATBAN.MANXB GROUP BY NHAXUATBAN.MANXB,TENNXB";
                tblThongke = Functions.GetDataToTable(sql);
                DataGridView1.DataSource = tblThongke;
                DataGridView1.Columns[0].HeaderText = "Mã nhà xuất bản";
                DataGridView1.Columns[1].HeaderText = "Tên nhà xuất bản";
                DataGridView1.Columns[2].HeaderText = "Số lượng";
                DataGridView1.Columns[0].Width = 200;
                DataGridView1.Columns[1].Width = 200;
                DataGridView1.Columns[2].Width = 150;
                DataGridView1.AllowUserToAddRows = false;
                DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void rdoNn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNn.Checked == true)
            {
                rdoVt.Checked = false;
                rdoTl.Checked = false;
                rdoNxb.Checked = false;
                rdoTg.Checked = false;

                sql = "SELECT NGONNGU.MANN,NGONNGU,COUNT(SACH.MANN) FROM SACH,NGONNGU WHERE SACH.MANN=NGONNGU.MANN GROUP BY NGONNGU.MANN,NGONNGU";
                tblThongke = Functions.GetDataToTable(sql);
                DataGridView1.DataSource = tblThongke;
                DataGridView1.Columns[0].HeaderText = "Mã ngôn ngữ";
                DataGridView1.Columns[1].HeaderText = "Ngôn ngữ";
                DataGridView1.Columns[2].HeaderText = "Số lượng";
                DataGridView1.Columns[0].Width = 200;
                DataGridView1.Columns[1].Width = 200;
                DataGridView1.Columns[2].Width = 150;
                DataGridView1.AllowUserToAddRows = false;
                DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }
    }
}
