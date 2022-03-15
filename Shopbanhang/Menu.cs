using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopbanhang
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
           
        }
        private void bynhanghoa_Click(object sender, EventArgs e)
        {
            HangHoa hh = new HangHoa();
            hh.ShowDialog();
        }

        private void btnnhacc_Click(object sender, EventArgs e)
        {
            Nhacungcap ncc = new Nhacungcap();
            ncc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Chatlieu cl = new Chatlieu();
            cl.ShowDialog();
        }

        private void btnhoadon_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.ShowDialog();
        }

        private void btntimkiemHD_Click(object sender, EventArgs e)
        {
            TimkiemHD tkhd = new TimkiemHD();
            tkhd.ShowDialog();
        }

        private void btnkhachang_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.ShowDialog();
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.ShowDialog();
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có chắc muốn thoát không ? ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (rs == DialogResult.OK)
            {
                Application.Exit();
                
            }    
               
            
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            Thongke tk = new Thongke();
            tk.ShowDialog();
        }

        private void btnphieunhap_Click(object sender, EventArgs e)
        {
            Phieunhap pn = new Phieunhap();
            pn.ShowDialog();
        }

        private void btnphieuxuat_Click(object sender, EventArgs e)
        {
            Phieuxuat px = new Phieuxuat();
            px.ShowDialog();
        }
    }
}
