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
    public partial class DMTacgia : Form
    {
        public DMTacgia()
        {
            InitializeComponent();
        }
        DataTable tblTacgia;

        private void DMTacgia_Load(object sender, EventArgs e)
        {
            txtMatg.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MATG,TENTG,DIACHI FROM TACGIA";
            tblTacgia = Class.Functions.GetDataToTable(sql);
            dtgTacgia.DataSource = tblTacgia;

            dtgTacgia.Columns[0].HeaderText = "Mã tác giả";
            dtgTacgia.Columns[1].HeaderText = "Tên tác giả";
            dtgTacgia.Columns[2].HeaderText = "Địa chỉ";

            dtgTacgia.Columns[0].Width = 250;
            dtgTacgia.Columns[1].Width = 250;
            dtgTacgia.Columns[2].Width = 300;

            dtgTacgia.AllowUserToAddRows = false;
            dtgTacgia.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMatg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatg.Focus();
                return;
            }
            if (txtTentg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTentg.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ của tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiachi.Focus();
                return;
            }

            sql = "SELECT MATG FROM TACGIA WHERE MATG=N'" + txtMatg.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã tác giả này đã tồn tại, bạn phải nhập mã tác giả mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatg.Focus();
                return;
            }

                sql = "INSERT INTO TACGIA VALUES (N'" + txtMatg.Text.Trim() + "',N'" + txtTentg.Text.Trim() + "',N'" + txtDiachi.Text.Trim() + "')";
                Functions.RunSql(sql);
                LoadDataGridView();

            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;

            btnLuu.Enabled = false;
            txtMatg.Enabled = false;
            txtDiachi.Enabled = false;

        }

        private void ResetValue()
        {
            txtMatg.Text = "";
            txtTentg.Text = "";
            txtDiachi.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE TACGIA WHERE MATG=N'" + txtMatg.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            txtDiachi.Enabled = true;
            txbTimkiem.Text = "";

            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMatg.Text = dtgTacgia.CurrentRow.Cells["MATG"].Value.ToString();
            txtTentg.Text = dtgTacgia.CurrentRow.Cells["TENTG"].Value.ToString();
            txtDiachi.Text = dtgTacgia.CurrentRow.Cells["DIACHI"].Value.ToString();
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void matudong()
        {
            string g;
            if (tblTacgia.Rows.Count == 0)
            {
                g = "TG01";
            }
            else
            {
                int k;
                g = "TG";
                k = Convert.ToInt32(tblTacgia.Rows[tblTacgia.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtMatg.Text = g;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
            txbTimkiem.Text = "";

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMatg.Enabled = true;
            txtTentg.Focus();
            matudong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatg.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTentg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE TACGIA SET TENTG=N'" +
                txtTentg.Text.Trim() + 
                "',DIACHI = N'" + txtDiachi.Text.Trim() + "'WHERE MATG=N'" + txtMatg.Text.Trim() + "'";

            Class.Functions.RunSql(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMatg.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;

            dtgTacgia.ClearSelection();

            if (tblTacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTimkiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sql = "SELECT MATG,TENTG,DIACHI FROM TACGIA WHERE MATG LIKE N'%" + txbTimkiem.Text.Trim() + "%' OR TENTG LIKE N'%" + txbTimkiem.Text.Trim() + "%' OR DIACHI LIKE N'%" + txbTimkiem.Text.Trim() + "%';";
            tblTacgia = Class.Functions.GetDataToTable(sql);
            dtgTacgia.DataSource = tblTacgia;
        }
    }
}
