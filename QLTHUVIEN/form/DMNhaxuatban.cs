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
    public partial class DMNhaxuatban : Form
    {
        public DMNhaxuatban()
        {
            InitializeComponent();
        }

        DataTable tblNhaxuatban;
        private void DMNhaxuatban_Load(object sender, EventArgs e)
        {
            txtManxb.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MANXB,TENNXB,DIACHI,SDT FROM NHAXUATBAN";
            tblNhaxuatban = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblNhaxuatban;
            DataGridView1.Columns[0].HeaderText = "Mã nhà xuất bản";
            DataGridView1.Columns[1].HeaderText = "Tên nhà xuất bản";
            DataGridView1.Columns[2].HeaderText = "Địa chỉ";
            DataGridView1.Columns[3].HeaderText = "SĐT";
            DataGridView1.Columns[0].Width = 200;
            DataGridView1.Columns[1].Width = 200;
            DataGridView1.Columns[2].Width = 200;
            DataGridView1.Columns[3].Width = 200;

            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtManxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }
            if (txtTennxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennxb.Focus();
                return;
            }

            sql = "SELECT MANXB FROM NHAXUATBAN WHERE MANXB=N'" + txtManxb.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà xuất bản này đã tồn tại, bạn phải chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }

            sql = "INSERT INTO NHAXUATBAN VALUES (N'" + txtManxb.Text.Trim() + "',N'" + txtTennxb.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "',N'" + txtSDT.Text.Trim() + "')";
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
            txtManxb.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaxuatban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTennxb.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NHAXUATBAN SET TENNXB=N'" +
                txtTennxb.Text.ToString() +
                "',DIACHI=N'" +
                txtDiachi.Text.ToString() +
                "',SDT=N'" +
                txtSDT.Text.ToString() +
                "' WHERE MANXB=N'" + txtManxb.Text + "'";
            Class.Functions.RunSql(sql);
            LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtManxb.Focus();
                return;
            }
            if (tblNhaxuatban.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtManxb.Text = DataGridView1.CurrentRow.Cells["MANXB"].Value.ToString();
            txtTennxb.Text = DataGridView1.CurrentRow.Cells["TENNXB"].Value.ToString();
            txtDiachi.Text = DataGridView1.CurrentRow.Cells["DIACHI"].Value.ToString();
            txtSDT.Text = DataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
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
            txtManxb.Enabled = true;
            txtTennxb.Focus();
            matudong();
        }

        private void ResetValue()
        {
            txtManxb.Text = "";
            txtTennxb.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblNhaxuatban.Rows.Count == 0)
            {
                g = "NXB01";
            }
            else
            {
                int k;
                g = "NXB";
                k = Convert.ToInt32(tblNhaxuatban.Rows[tblNhaxuatban.Rows.Count - 1][0].ToString().Substring(3, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtManxb.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNhaxuatban.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManxb.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NHAXUATBAN WHERE MANXB=N'" + txtManxb.Text + "'";
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
            txtManxb.Enabled = false;
        }

        private void txtMatl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
