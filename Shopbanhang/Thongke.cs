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
    public partial class Thongke : Form
    {
        DataTable tblHDB;
        DataTable tblCTHDB;
        public Thongke()
        {
            InitializeComponent();
        }

        

        private void Thongke_Load(object sender, EventArgs e)
        {
            
            dgvThongke.DataSource = null;
        }

        
        private void LoadDataGridView()
        {
            dgvThongke.Columns[0].HeaderText = "Mã HĐB";
            dgvThongke.Columns[1].HeaderText = "Mã nhân viên";
            dgvThongke.Columns[2].HeaderText = "Ngày bán";
            dgvThongke.Columns[3].HeaderText = "Mã khách";
            dgvThongke.Columns[4].HeaderText = "Tổng tiền";
            dgvThongke.Columns[0].Width = 150;
            dgvThongke.Columns[1].Width = 100;
            dgvThongke.Columns[2].Width = 80;
            dgvThongke.Columns[3].Width = 80;
            dgvThongke.Columns[4].Width = 80;
            dgvThongke.AllowUserToAddRows = false;
            dgvThongke.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            string sql;
            
            sql = "SELECT * FROM tblHoaDon WHERE 1=1";
            if(txtthang.Text==null && txtnam.Text==null)
            {
                dgvThongke.DataSource = tblHDB;
                LoadDataGridView();
            }
            else
            {
                if (txtthang.Text != "")
                    sql = sql + " AND MONTH(NgayBan) =" + txtthang.Text;
                if (txtnam.Text != "")
                    sql = sql + " AND YEAR(NgayBan) =" + txtnam.Text;

                tblHDB = Functions.GetDataToTable(sql);
                if (tblHDB.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvThongke.DataSource = tblHDB;
                LoadDataGridView();

            }
            //float tong, Tongmoi;
            //tong = float.Parse(Functions.GetFieldValues("SELECT TongTien FROM tblHoaDon "));
            
            
            //Functions.RunSQL(sql);
           // txtdoanhthu.Text = tong.ToString();
            //tblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tong.ToString()));

            float tong = 0;
           

            for (int i = 0; i < dgvThongke.Rows.Count ; i++)
            {

                tong = tong + float.Parse(dgvThongke.Rows[i].Cells[4].Value.ToString());

            }
            lbdoanhthu.Text = tong.ToString();
            tblbangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tong.ToString()));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
