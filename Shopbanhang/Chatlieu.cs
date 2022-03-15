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
    public partial class Chatlieu : Form
    {
        DataTable chatlieu; //Chứa dữ liệu bảng Chất liệu
        public Chatlieu()
        {
            InitializeComponent();
        }

        private void Chatlieu_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from Nhacungcap";
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Functions.FillCombo(sql, cbmaNcc, "Manhacungcap", "Tennhacungcap");
            cbmaNcc.SelectedIndex = -1;
            LoadDataGridView();//Hiển thị bảng tblChatLieu
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaChatLieu.Text = "";
            txtTenChatLieu.Text = "";
            cbmaNcc.Text = "";
            
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblChatlieu";
            chatlieu = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvChatLieu.DataSource = chatlieu;  //Nguồn dữ liệu    
            dgvChatLieu.Columns[0].HeaderText = "Mã chất liệu";
            dgvChatLieu.Columns[1].HeaderText = "Tên chất liệu";
            dgvChatLieu.Columns[2].HeaderText = "Nhà cung cấp";
            
            dgvChatLieu.Columns[0].Width = 80;
            dgvChatLieu.Columns[1].Width = 140;
            dgvChatLieu.Columns[2].Width = 80;
            
            dgvChatLieu.AllowUserToAddRows = false;
            dgvChatLieu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvChatLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Manhacungcap;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (chatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaChatLieu.Text = dgvChatLieu.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            txtTenChatLieu.Text = dgvChatLieu.CurrentRow.Cells["TenChatLieu"].Value.ToString();
            Manhacungcap = dgvChatLieu.CurrentRow.Cells["Manhacungcap"].Value.ToString();
            sql = "SELECT Tennhacungcap FROM Nhacungcap WHERE Manhacungcap=N'" + Manhacungcap + "'";
            cbmaNcc.Text = Functions.GetFieldValues(sql);
            
            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaChatLieu.Enabled = true;
            txtMaChatLieu.Focus();
            txtTenChatLieu.Enabled = true;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenChatLieu.Focus();
                return;
            }
            if (cbmaNcc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbmaNcc.Focus();
                return;
            }
            
            sql = "INSERT INTO tblChatLieu(MaChatLieu, TenChatLieu, Manhacungcap) VALUES(N'"
                + txtMaChatLieu.Text.Trim() + "',N'" + txtTenChatLieu.Text.Trim() +
                "',N'" + cbmaNcc.SelectedValue.ToString() + "')";

            Functions.RunSQL(sql);//Thực hiện câu lệnh sql
            LoadDataGridView();//Nạp lại DataGridView
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        
    }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (chatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChatLieu.Focus();
                return;
            }
            if (txtTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenChatLieu.Focus();
                return;
            }
            if (cbmaNcc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbmaNcc.Focus();
                return;
            }
           
            sql = "UPDATE tblChatLieu SET TenChatLieu=N'" + txtTenChatLieu.Text.Trim().ToString() +
                "',Manhacungcap=N'" + cbmaNcc.SelectedValue.ToString() + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (chatlieu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChatLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChatLieu WHERE MaChatLieu=N'" + txtMaChatLieu.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
