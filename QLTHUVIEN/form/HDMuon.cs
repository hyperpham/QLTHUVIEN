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
    public partial class HDMuon : Form
    {
        public HDMuon()
        {
            InitializeComponent();
        }

        public static string mpm;
        public static int soluong;

        DataTable tblMuontra;

        private void button4_Click(object sender, EventArgs e)
        {
            string sql;

            if (tblMuontra.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMapm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbMadg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbSLmuon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng sách mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sql = "UPDATE HOADONMUON SET MANV='"+cmbManv.SelectedValue.ToString()+"',MADG='"+cmbMadg.SelectedValue.ToString()+"',SOLUONG='"+txbSLmuon.Text.Trim()+"',NGAYTHUE='"+txtNgaythue.Text.Trim()+"' WHERE MAPM='"+txbMapm.Text.Trim()+"'";
            Class.Functions.RunSql(sql);
            LoadDataGridView();
            ResetValue();
            btnBoqua.Enabled = false;
        }

        private void matudong()
        {
            string g;
            if (tblMuontra.Rows.Count == 0)
            {
                g = "PM01";
            }
            else
            {
                int k;
                g = "PM";
                k = Convert.ToInt32(tblMuontra.Rows[tblMuontra.Rows.Count - 1][0].ToString().Substring(2, 2));
                k = k + 1;
                if (k < 10)
                {
                    g = g + "0";
                }
                g = g + k.ToString();
            }
            txbMapm.Text = g;
        }

        private void DMMuontra_Load(object sender, EventArgs e)
        {
            txbMapm.Enabled = false;
            txbSLmuon.Enabled = false;
            txtNgaythue.Enabled = false;
            //cmbMadg.Enabled = false;
            //cmbManv.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
           

            string sqlDG = "SELECT MADG,TENDG FROM DOCGIA";
            Functions.FillCombo(sqlDG, cmbMadg, "MADG", "TENDG");
            cmbMadg.SelectedIndex = -1;

            string sqlNV = "SELECT MANV,TENNV FROM NHANVIEN";
            Functions.FillCombo(sqlNV, cmbManv, "MANV", "TENNV");
            cmbManv.SelectedIndex = -1;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MAPM,MADG,MANV,SOLUONG,NGAYTHUE FROM HOADONMUON";
            tblMuontra = Class.Functions.GetDataToTable(sql);
            dtgMuontra.DataSource = tblMuontra;
            dtgMuontra.Columns[0].HeaderText = "Mã phiếu mượn";
            dtgMuontra.Columns[1].HeaderText = "Mã đọc giả";
            dtgMuontra.Columns[2].HeaderText = "Mã nhân viên";
            dtgMuontra.Columns[3].HeaderText = "Số lượng mượn";
            dtgMuontra.Columns[4].HeaderText = "Ngày thuê";

            dtgMuontra.Columns[0].Width = 170;
            dtgMuontra.Columns[1].Width = 150;
            dtgMuontra.Columns[2].Width = 150;
            dtgMuontra.Columns[3].Width = 150;
            dtgMuontra.Columns[4].Width = 150;

            dtgMuontra.AllowUserToAddRows = false;
            dtgMuontra.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            matudong();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txbMapm.Enabled = true;
            txbSLmuon.Enabled = true;
            txtNgaythue.Enabled = true;
            cmbMadg.Enabled = true;
            cmbManv.Enabled = true;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;

            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string sql;

            if (txbMapm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMapm.Focus();
                return;
            }

            if (cmbManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbManv.Focus();
                return;
            }

            if(cmbMadg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đọc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbMadg.Focus();
                return;
            }

            if(txbSLmuon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng sách mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSLmuon.Focus();
                return;
            }

            sql = "SELECT MAPM FROM HOADONMUON WHERE MAPM=N'" + txbMapm.Text.Trim() + "'";

            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thể loại này đã tồn tại, bạn phải chọn mã thể loại khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMapm.Focus();
                return;
            }

            sql = "INSERT INTO HOADONMUON VALUES (N'"+txbMapm.Text.Trim()+"',N'"+cmbMadg.SelectedValue.ToString()+"',N'"+cmbManv.SelectedValue.ToString()+"',N'"+ txtNgaythue.Text.Trim()+"',N'"+txbSLmuon.Text.Trim()+"')";
            Functions.RunSql(sql);
            LoadDataGridView();

            ResetValue();
            btnBoqua.Enabled = false;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txbMapm.Enabled = false;
            txbSLmuon.Enabled = false;
            txtNgaythue.Enabled = false;
            cmbMadg.Enabled = false;
            cmbManv.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void ResetValue()
        {
            txbMapm.Text = "";
            txbSLmuon.Text = "";
            txtNgaythue.Text = "";
            cmbMadg.Text = "";
            cmbManv.Text = "";
            txbTimkiem.Text = "";
        }

        private void dtgMuontra_Click(object sender, EventArgs e)
        {
            txbSLmuon.Enabled = true;
            txtNgaythue.Enabled = true;
            cmbMadg.Enabled = true;
            cmbManv.Enabled = true;

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbMapm.Focus();
                return;
            }
            if (tblMuontra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txbMapm.Text = dtgMuontra.CurrentRow.Cells["MAPM"].Value.ToString();
            
            txtNgaythue.Text = dtgMuontra.CurrentRow.Cells["NGAYTHUE"].Value.ToString();
            txbSLmuon.Text = dtgMuontra.CurrentRow.Cells["SOLUONG"].Value.ToString();

            string temp= dtgMuontra.CurrentRow.Cells["MADG"].Value.ToString();
            string sql = "SELECT TENDG FROM DOCGIA WHERE MADG='" + temp + "'";
            cmbMadg.Text=Class.Functions.GetFieldValues(sql);

            temp = dtgMuontra.CurrentRow.Cells["MANV"].Value.ToString();
            sql = "SELECT TENNV FROM NHANVIEN WHERE MANV='" + temp + "'";
            cmbManv.Text = Class.Functions.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMuontra.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbMapm.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE HOADONMUON WHERE MAPM=N'" + txbMapm.Text + "'";
                Class.Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txbMapm.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string sql;

            dtgMuontra.ClearSelection();

            if (tblMuontra.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txbTimkiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã phiếu mượn cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sql = "SELECT MAPM,MADG,MANV,NGAYTHUE,SOLUONG FROM HOADONMUON WHERE MAPM='"+txbTimkiem.Text.Trim()+"'";
            //Class.Functions.RunSql(sql);

            //sql = "SELECT MAPM,MADG,MANV,SOLUONGMUON,SOLUONGTRA FROM TIMKIEMHOADONMUON";
            tblMuontra = Class.Functions.GetDataToTable(sql);
            dtgMuontra.DataSource = tblMuontra;
            dtgMuontra.Columns[0].HeaderText = "Mã phiếu mượn";
            dtgMuontra.Columns[1].HeaderText = "Mã đọc giả";
            dtgMuontra.Columns[2].HeaderText = "Mã nhân viên";
            dtgMuontra.Columns[3].HeaderText = "Ngày thuê";
            dtgMuontra.Columns[4].HeaderText = "Số lượng";

            dtgMuontra.Columns[0].Width = 170;
            dtgMuontra.Columns[1].Width = 150;
            dtgMuontra.Columns[2].Width = 150;
            dtgMuontra.Columns[3].Width = 150;
            dtgMuontra.Columns[4].Width = 150;

            dtgMuontra.AllowUserToAddRows = false;
            dtgMuontra.EditMode = DataGridViewEditMode.EditProgrammatically;

            //sql = "DELETE FROM TIMKIEMHOADONMUON;";
            //Class.Functions.RunSql(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txbMapm.Text == "")
            {
                MessageBox.Show("Chưa chọn mã phiếu mượn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            mpm = txbMapm.Text.Trim();
            form.Chonsach cs = new Chonsach();

            cs.ShowDialog();

            if (cs.IsDisposed)
            {
                txbSLmuon.Text = soluong.ToString();
            }
           
        }
    }
}
