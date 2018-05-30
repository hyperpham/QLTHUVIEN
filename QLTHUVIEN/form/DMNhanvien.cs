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
    public partial class DMNhanvien : Form
    {
        public DMNhanvien()
        {
            InitializeComponent();
        }

        DataTable tblNhanvien;

        private void DMNhanvien_Load(object sender, EventArgs e)
        {
            txtManv.Enabled = false;
            rdoNam.Checked = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM NHANVIEN";
            tblNhanvien = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblNhanvien;
            DataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            DataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            DataGridView1.Columns[2].HeaderText = "Giới tính";
            DataGridView1.Columns[3].HeaderText = "Địa chỉ";
            DataGridView1.Columns[4].HeaderText = "Số điện thoại";


            DataGridView1.Columns[0].Width = 100;
            DataGridView1.Columns[1].Width = 200;
            DataGridView1.Columns[2].Width = 60;
            DataGridView1.Columns[3].Width = 100;
            DataGridView1.Columns[4].Width = 150;


            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtManv.Enabled = true;
            txtTennv.Focus();
            matudong();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennv.Focus();
                return;
            }
            sql = "SELECT MANV FROM NHANVIEN WHERE MANV=N'" + txtManv.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thể loại này đã tồn tại, bạn phải chọn mã thể loại khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (rdoNam.Checked == true)
            {
                sql = "INSERT INTO NHANVIEN VALUES (N'" + txtManv.Text.Trim() + "',N'" + txtTennv.Text.Trim() + "','Nam',N'" + txtDiachi.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "')";
                Functions.RunSql(sql);
                LoadDataGridView();
            }
            if (rdoNu.Checked == true)
            {
                sql = "INSERT INTO NHANVIEN VALUES (N'" + txtManv.Text.Trim() + "',N'" + txtTennv.Text.Trim() + "',N'Nữ',N'" + txtDiachi.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "')";
                Functions.RunSql(sql);
                LoadDataGridView();
            }


            LoadDataGridView();
            ResetValue();

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            txtManv.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdoNam.Checked == true)
            {
                sql = "UPDATE NHANVIEN SET TENNV=N'" + txtTennv.Text.Trim() + 
                    "',DIACHI = N'" + txtDiachi.Text.Trim() +
                    "',DIENTHOAI = '" + txtSDT.Text.Trim()+
                    "',GIOITINH = 'NAM' WHERE MANV=N'" + txtManv.Text.Trim() + "'";
                Class.Functions.RunSql(sql);
                LoadDataGridView();
                ResetValue();
            }
            if (rdoNu.Checked == true)
            {
                sql = "UPDATE NHANVIEN SET TENNV=N'" + txtTennv.Text.Trim() +
                    "',DIACHI = N'" + txtDiachi.Text.Trim() +
                    "',DIENTHOAI = '" + txtSDT.Text.Trim() +
                    "',GIOITINH = N'Nữ' WHERE MANV=N'" + txtManv.Text.Trim() + "'";
                Class.Functions.RunSql(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManv.Focus();
                return;
            }
            if (tblNhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManv.Text = DataGridView1.CurrentRow.Cells["MANV"].Value.ToString();
            txtTennv.Text = DataGridView1.CurrentRow.Cells["TENNV"].Value.ToString();
            txtDiachi.Text = DataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells["DIENTHOAI"].Value.ToString();
            if(DataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nam")==true)
            {
                rdoNam.Checked = true;
                rdoNu.Checked = false;
            }
            if (DataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nữ")==true)
            {
                rdoNu.Checked = true;
                rdoNam.Checked = false;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }



        private void ResetValue()
        {
            txtManv.Text = "";
            txtTennv.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblNhanvien.Rows.Count == 0)
            {
                g = "NV01";
            }
            else
            {
                int k;
                g = "NV";
                k = tblNhanvien.Rows.Count;
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtManv.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManv.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE FROM NHANVIEN WHERE MANV=N'" + txtManv.Text.Trim() + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void txtManv_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoNam.Checked == true)
            {
                rdoNu.Checked = false;
            }
        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNu.Checked == true)
            {
                rdoNam.Checked = false;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtManv.Enabled = false;
        }
    }
}
