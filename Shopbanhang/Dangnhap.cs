using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopbanhang
{
    public partial class Dangnhap : Form
    {
        DataTable ngdung;
        public Dangnhap()
        {
            InitializeComponent();
        }

       
        private void Dangnhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string ten = txttk.Text.Trim();
            string mk = txtmk.Text.Trim();
            string sql = "select * from nguoidung where Taikhoan= '" + ten + "' and Matkhau= '" + mk + "'";
            if (ten != " " || mk != " ")
            {
                if (Functions.GetDataToTable(sql).Rows.Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    this.txttk.Clear();
                    this.txtmk.Clear();
                    Menu frm = new Menu
                    {
                        StartPosition = FormStartPosition.CenterScreen
                    };
                    frm.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
                this.lblstatus.ForeColor = Color.Red;
                this.lblstatus.Text = "Tài khoản không tồn tại";
                this.txttk.Clear();
                this.txtmk.Clear();
                this.txttk.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn thoát không ? ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (rs == DialogResult.OK)
            {
                Application.Exit();

            }
        }
    }
}
