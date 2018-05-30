using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN.form
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string sql;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Class.Functions.Connect();

            //kiem tra ton tai user
            sql = "SELECT USERS FROM LOGIN where USERS=N'" + txtuser.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                sql = "SELECT PASS FROM LOGIN WHERE USERS='" + txtpass.Text.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    this.Hide();
                    form.Mainform main = new form.Mainform();
                    main.ShowDialog();
                    
                }
                else MessageBox.Show("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu!");

            }

            else MessageBox.Show("Bạn đã nhập sai tên đăng nhập hoặc mật khẩu!");


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender,e);
            }
        }
    }
}
