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
    public partial class DMNgonngu : Form
    {
        public DMNgonngu()
        {
            InitializeComponent();
        }

        DataTable tblNgonngu;

        private void DMNgonngu_Load(object sender, EventArgs e)
        {
            txtMann.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MANN,NGONNGU FROM NGONNGU";
            tblNgonngu = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblNgonngu;
            DataGridView1.Columns[0].HeaderText = "Mã ngôn ngữ";
            DataGridView1.Columns[1].HeaderText = "Ngôn ngữ";
            DataGridView1.Columns[0].Width = 300;
            DataGridView1.Columns[1].Width = 300;

            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMann.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMann.Focus();
                return;
            }
            if (txtNn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNn.Focus();
                return;
            }

            sql = "SELECT MANN FROM NGONNGU WHERE MANN=N'" + txtMann.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã tồn tại, bạn phải chọn mã thể loại khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMann.Focus();
                return;
            }

            sql = "INSERT INTO NGONNGU VALUES (N'" + txtMann.Text.Trim() + "',N'" + txtNn.Text.Trim() + "')";
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
            txtMann.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNgonngu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMann.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtNn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập NGÔN NGỮ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE NGONNGU SET NGONNGU=N'" +
                txtNn.Text.ToString() +
                "' WHERE MANN=N'" + txtMann.Text + "'";
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
                txtMann.Focus();
                return;
            }
            if (tblNgonngu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMann.Text = DataGridView1.CurrentRow.Cells["MANN"].Value.ToString();
            txtNn.Text = DataGridView1.CurrentRow.Cells["NGONNGU"].Value.ToString();
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
            txtMann.Enabled = true;
            txtNn.Focus();
            matudong();
        }

        private void ResetValue()
        {
            txtMann.Text = "";
            txtNn.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblNgonngu.Rows.Count == 0)
            {
                g = "NN01";
            }
            else
            {
                int k;
                g = "NN";
                k = Convert.ToInt32(tblNgonngu.Rows[tblNgonngu.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtMann.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNgonngu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMann.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE NGONNGU WHERE MANN=N'" + txtMann.Text + "'";
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
            txtMann.Enabled = false;
        }

        private void txtMann_KeyUp(object sender, KeyEventArgs e)
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
