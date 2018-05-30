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
    public partial class DMSach : Form
    {
        public DMSach()
        {
            InitializeComponent();
        }

        DataTable tblSach;

        private void LoadDataGridView()
        {
            txtNgaynhap.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = false;
            string sql;
            sql = "SELECT MASACH,MATL,MAVT,TENSACH,MATG,NGAYNHAP,MANXB FROM SACH";
            tblSach = Class.Functions.GetDataToTable(sql);
            dtgSach.DataSource = tblSach;
            dtgSach.Columns[0].HeaderText = "Mã sách";
            dtgSach.Columns[1].HeaderText = "Mã thể loại";
            dtgSach.Columns[2].HeaderText = "Mã vị trí";
            dtgSach.Columns[3].HeaderText = "Tên sách";
            dtgSach.Columns[4].HeaderText = "Mã tác giả";
            dtgSach.Columns[5].HeaderText = "Ngày nhập kho";
            dtgSach.Columns[6].HeaderText = "Mã nhà xuất bản";

            dtgSach.Columns[0].Width = 50;
            dtgSach.Columns[1].Width = 120;
            dtgSach.Columns[2].Width = 120;
            dtgSach.Columns[3].Width = 135;
            dtgSach.Columns[4].Width = 120;
            dtgSach.Columns[5].Width = 120;
            dtgSach.Columns[6].Width = 120;

            dtgSach.AllowUserToAddRows = false;
            dtgSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValue()
        {
            txtMasach.Text = "";
            txtNgaynhap.Text = "";
            txtTensach.Text = "";
            cmbNxb.Text = "";
            cmbTg.Text = "";
            cmbTl.Text = "";
            cmbVt.Text = "";
        }



        private void DMSach_Load(object sender, EventArgs e)
        {
            txtMasach.Enabled = false;
            txtTensach.Enabled = false;
            txtNgaynhap.Enabled = false;
            cmbNxb.Enabled = false;
            cmbTg.Enabled = false;
            cmbTl.Enabled = false;
            cmbVt.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThem.Enabled = false;
            txtMasach.Enabled = true;
            txtTensach.Enabled = true;
            txtNgaynhap.Enabled = true;
            cmbNxb.Enabled = true;
            cmbTg.Enabled = true;
            cmbTl.Enabled = true;
            cmbVt.Enabled = true;
            ResetValue();
            txtMasach.Enabled = true;
            txtMasach.Focus();
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMasach.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMasach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasach.Focus();
                return;
            }
            if (txtTensach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTensach.Focus();
                return;
            }
            if (cmbTl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTl.Focus();
                return;
            }

            if (cmbVt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbVt.Focus();
                return;
            }

            if (cmbTg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbTg.Focus();
                return;
            }

            if (cmbNxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbNxb.Focus();
                return;
            }

            sql = "SELECT MASACH FROM SACH WHERE MASACH=N'" + txtMasach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã sách này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMasach.Focus();
                return;
            }

            else
            {
                sql = "INSERT INTO SACH(MASACH,MATL,MAVT,TENSACH,MATG,NGAYNHAP,MANXB) VALUES(N'"
                + txtMasach.Text.Trim() + "',N'"
                + cmbTl.SelectedValue.ToString()
                + "',N'" + cmbVt.SelectedValue.ToString() +
                "',N'" + txtTensach.Text.Trim() +
                "',N'" + cmbTg.SelectedValue.ToString() +
                "',N'" + cmbNxb.SelectedValue.ToString() +
                "','" + txtNgaynhap.Text.Trim() +
                "')";



                Functions.RunSql(sql);
                LoadDataGridView();
                btnXoa.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnBoqua.Enabled = false;
                btnLuu.Enabled = false;
                txtMasach.Enabled = false;
            }
        }
    }
}
