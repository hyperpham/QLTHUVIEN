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
    public partial class DMTheloai : Form
    {
        public DMTheloai()
        {
            InitializeComponent();
        }

        DataTable tblTheloai;

        private void DMTheloai_Load(object sender, EventArgs e)
        {
            txtMatl.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MATL,TENTL FROM THELOAI";
            tblTheloai = Class.Functions.GetDataToTable(sql);
            DataGridView1.DataSource = tblTheloai;
            DataGridView1.Columns[0].HeaderText = "Mã thể loại";
            DataGridView1.Columns[1].HeaderText = "Tên thể loại";
            DataGridView1.Columns[0].Width = 300;
            DataGridView1.Columns[1].Width = 300;

            DataGridView1.AllowUserToAddRows = false;
            DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

    

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMatl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatl.Focus();
                return;
            }
            if (txtTentl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTentl.Focus();
                return;
            }

            sql = "SELECT MATL FROM THELOAI WHERE MATL=N'" + txtMatl.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thể loại này đã tồn tại, bạn phải chọn mã thể loại khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatl.Focus();
                return;
            }

                sql="INSERT INTO THELOAI VALUES (N'"+txtMatl.Text.Trim()+"',N'"+txtTentl.Text.Trim()+"')";
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
            txtMatl.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTheloai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatl.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTentl.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE THELOAI SET TENTL=N'" +
                txtTentl.Text.ToString() +
                "' WHERE MATL=N'" + txtMatl.Text + "'";
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
                txtMatl.Focus();
                return;
            }
            if (tblTheloai.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMatl.Text = DataGridView1.CurrentRow.Cells["MATL"].Value.ToString();
            txtTentl.Text = DataGridView1.CurrentRow.Cells["TENTL"].Value.ToString();
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
            txtMatl.Enabled = true;
            txtTentl.Focus();
            matudong();
        }

        private void ResetValue()
        {
            txtMatl.Text = "";
            txtTentl.Text = "";
        }

        private void matudong()
        {
            string g;
            if (tblTheloai.Rows.Count == 0)
            {
                g = "TL01";
            }
            else
            {
                int k;
                g = "TL";
                k = Convert.ToInt32(tblTheloai.Rows[tblTheloai.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txtMatl.Text = g;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTheloai.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMatl.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE THELOAI WHERE MATL=N'" + txtMatl.Text + "'";
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
            txtMatl.Enabled = false;
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
