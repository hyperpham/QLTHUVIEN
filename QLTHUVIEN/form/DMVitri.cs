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
    public partial class DMVitri : Form
    {
        public DMVitri()
        {
            InitializeComponent();
        }

        DataTable tblVitri;

        private void DMVitri_Load(object sender, EventArgs e)
        {
            txtMavt.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MAVT,VITRI FROM VITRI";
            tblVitri = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblVitri;
            DataGridView1.Columns[0].HeaderText = "Mã vị trí";
            DataGridView1.Columns[1].HeaderText = "Vị trí";
            DataGridView1.Columns[0].Width = 300;
            DataGridView1.Columns[1].Width = 300;

            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMavt.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMavt.Focus();
                return;
            }
            if (txtVitri.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtVitri.Focus();
                return;
            }

            sql = "SELECT MAVT FROM VITRI WHERE MAVT=N'" + txtMavt.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã vị trí này đã tồn tại, bạn phải chọn mã vị trí khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMavt.Focus();
                return;
            }

                sql = "INSERT INTO VITRI VALUES (N'" + txtMavt.Text.Trim() + "',N'" + txtVitri.Text.Trim() + "')";
                Functions.RunSql(sql);
                LoadDataGridView();
            ResetValue();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMavt.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblVitri.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMavt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtVitri.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE VITRI SET VITRI=N'" +
                txtVitri.Text.ToString() +
                "' WHERE MAVT=N'" + txtMavt.Text + "'";
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
                txtMavt.Focus();
                return;
            }
            if (tblVitri.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMavt.Text = DataGridView1.CurrentRow.Cells["MAVT"].Value.ToString();
            txtVitri.Text = DataGridView1.CurrentRow.Cells["VITRI"].Value.ToString();
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
            txtMavt.Enabled = true;
            txtVitri.Focus();
            matudong();
        }

        private void ResetValue()
        {
            txtMavt.Text = "";
            txtVitri.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblVitri.Rows.Count == 0)
            {
                g = "VT01";
            }
            else
            {
                int k;
                g = "VT";
                k = Convert.ToInt32(tblVitri.Rows[tblVitri.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtMavt.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblVitri.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMavt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE VITRI WHERE MAVT=N'" + txtMavt.Text + "'";
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
            txtMavt.Enabled = false;
        }

        private void txtMavt_KeyUp(object sender, KeyEventArgs e)
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
