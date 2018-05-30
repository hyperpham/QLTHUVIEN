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
    public partial class DMDocgia : Form
    {
        public DMDocgia()
        {
            InitializeComponent();
        }

        DataTable tblDocgia;

        private void DMDOCGIA_Load(object sender, EventArgs e)
        {
            txtMadg.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            rdoNam.Checked = true;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MADG,TENDG,GIOITINH,NGAYSINH,DIACHI,NGHENGHIEP,NGAYCAPTHE,NGAYHETHAN FROM DOCGIA";
            tblDocgia = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblDocgia;
            DataGridView1.Columns[0].HeaderText = "Mã độc giả";
            DataGridView1.Columns[1].HeaderText = "Tên độc giả";
            DataGridView1.Columns[2].HeaderText = "Giới tính";
            DataGridView1.Columns[3].HeaderText = "Ngày sinh";
            DataGridView1.Columns[4].HeaderText = "Địa chỉ";
            DataGridView1.Columns[5].HeaderText = "Nghề nghiệp";
            DataGridView1.Columns[6].HeaderText = "Ngày cấp thẻ";
            DataGridView1.Columns[7].HeaderText = "Ngày hết hạn";
            DataGridView1.Columns[0].Width = 70;
            DataGridView1.Columns[1].Width = 125;
            DataGridView1.Columns[2].Width = 50;
            DataGridView1.Columns[3].Width = 100;
            DataGridView1.Columns[4].Width = 140;
            DataGridView1.Columns[5].Width = 100;
            DataGridView1.Columns[6].Width = 100;
            DataGridView1.Columns[7].Width = 100;

            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMadg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMadg.Focus();
                return;
            }
            if (txtTendg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTendg.Focus();
                return;
            }

            sql = "SELECT MADG FROM DOCGIA WHERE MADG=N'" + txtMadg.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã độc giả này đã tồn tại, bạn phải chọn mã độc giả khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMadg.Focus();
                return;
            }

            if (rdoNam.Checked == true)
            {
                sql = "INSERT INTO DOCGIA VALUES (N'" + txtMadg.Text.Trim() + 
                    "',N'" + txtTendg.Text.Trim() +
                    "',N'Nam','"+txtNgaysinh.Text.Trim()+"',N'"+txtDiachi.Text.Trim()+"',N'"+txtNghe.Text.Trim()+"','"+txtNgaycap.Text.Trim()+"','"+txtNgayhet.Text.Trim()+"')";
                    
            }

            if (rdoNam.Checked == true)
            {
                sql = "INSERT INTO DOCGIA VALUES (N'" + txtMadg.Text.Trim() +
                    "',N'" + txtTendg.Text.Trim() +
                    "',N'Nữ','" + txtNgaysinh.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + txtNghe.Text.Trim() + "','" + txtNgaycap.Text.Trim() + "','" + txtNgayhet.Text.Trim() + "')";

            }


            Functions.RunSql(sql);
            LoadDataGridView();


            LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMadg.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDocgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMadg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTendg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdoNam.Checked == true)
            {
                sql = "UPDATE DOCGIA SET TENDG=N'" +
                txtTendg.Text.ToString() + "',GIOITINH=N'Nam',NGAYSINH='" + txtNgaysinh.Text.Trim() + "',DIACHI=N'" + txtDiachi.Text.Trim() + "',NGHENGHIEP=N'" + txtNghe.Text.Trim() + "',NGAYCAPTHE='" + txtNgaycap.Text.Trim() + "',NGAYHETHAN='" + txtNgayhet.Text.Trim() + "' WHERE MADG=N'" + txtMadg.Text + "'";
                Class.Functions.RunSql(sql);
            }
            if (rdoNu.Checked == true)
            {
                sql = "UPDATE DOCGIA SET TENDG=N'" +
               txtTendg.Text.ToString() + "',GIOITINH=N'Nữ',NGAYSINH='" + txtNgaysinh.Text.Trim() + "',DIACHI=N'" + txtDiachi.Text.Trim() + "',NGHENGHIEP=N'" + txtNghe.Text.Trim() + "',NGAYCAPTHE='" + txtNgaycap.Text.Trim() + "',NGAYHETHAN='" + txtNgayhet.Text.Trim() + "' WHERE MADG=N'" + txtMadg.Text + "'";
                Class.Functions.RunSql(sql);
            }

            
            LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMadg.Focus();
                return;
            }
            if (tblDocgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMadg.Text = DataGridView1.CurrentRow.Cells["MADG"].Value.ToString();
            txtTendg.Text = DataGridView1.CurrentRow.Cells["TENDG"].Value.ToString();
            txtNgaysinh.Text = DataGridView1.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            txtNgayhet.Text = DataGridView1.CurrentRow.Cells["NGAYHETHAN"].Value.ToString();
            txtNgaycap.Text = DataGridView1.CurrentRow.Cells["NGAYCAPTHE"].Value.ToString();
            txtNghe.Text = DataGridView1.CurrentRow.Cells["NGHENGHIEP"].Value.ToString();
            txtDiachi.Text = DataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
            if (DataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nam") == true)
            {
                rdoNam.Checked = true;
                rdoNu.Checked = false;
            }
            if (DataGridView1.CurrentRow.Cells["GIOITINH"].Value.ToString().Equals("Nữ") == true)
            {
                rdoNu.Checked = true;
                rdoNam.Checked = false;
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMadg.Enabled = true;
            txtTendg.Focus();
            matudong();
        }

        private void ResetValue()
        {
            txtMadg.Text = "";
            txtNgaysinh.Text = "";
            txtNgayhet.Text = "";
            txtNgaycap.Text = "";
            txtDiachi.Text = "";
            txtNghe.Text = "";
            rdoNam.Checked = true;
            txtTendg.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblDocgia.Rows.Count == 0)
            {
                g = "DG01";
            }
            else
            {
                int k;
                g = "DG";
                k = Convert.ToInt32(tblDocgia.Rows[tblDocgia.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtMadg.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDocgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMadg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE DOCGIA WHERE MADG=N'" + txtMadg.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
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
            txtMadg.Enabled = false;
        }

        private void txtMadg_KeyUp(object sender, KeyEventArgs e)
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
            if (rdoNam.Checked == true)
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
    }
}
