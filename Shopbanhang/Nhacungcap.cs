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
    public partial class Nhacungcap : Form
    {
        DataTable NCC;
        public Nhacungcap()
        {
            InitializeComponent();
        }

        private void Nhacungcap_Load(object sender, EventArgs e)
        {
            txtmancc.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM Nhacungcap";
            NCC = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvNCC.DataSource = NCC; //Nguồn dữ liệu            
            dgvNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns[2].HeaderText = "SDT";
            dgvNCC.Columns[3].HeaderText = "Email";
            dgvNCC.Columns[4].HeaderText = "Địa chỉ";
            dgvNCC.Columns[5].HeaderText = "Trạng thái";
            dgvNCC.Columns[0].Width = 100;
            dgvNCC.Columns[1].Width = 100;
            dgvNCC.Columns[2].Width = 100;
            dgvNCC.Columns[3].Width = 300;
            dgvNCC.Columns[4].Width = 300;
            dgvNCC.Columns[5].Width = 300;
            dgvNCC.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmancc.Focus();
                return;
            }
            if (NCC.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmancc.Text = dgvNCC.CurrentRow.Cells["Manhacungcap"].Value.ToString();
            txttenncc.Text = dgvNCC.CurrentRow.Cells["Tennhacungcap"].Value.ToString();
            txtsdt.Text = dgvNCC.CurrentRow.Cells["SDT"].Value.ToString();
            txtemail.Text = dgvNCC.CurrentRow.Cells["email"].Value.ToString();
            txtdiachi.Text = dgvNCC.CurrentRow.Cells["Diachi"].Value.ToString();
            txttrangthai.Text = dgvNCC.CurrentRow.Cells["Trangthai"].Value.ToString();
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
            ResetValue(); //Xoá trắng các textbox
            txtmancc.Enabled = true; //cho phép nhập mới
            txtmancc.Focus();
        }
        private void ResetValue()
        {
            txtmancc.Text = "";
            txttenncc.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdiachi.Text = "";
            txttrangthai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmancc.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmancc.Focus();
                return;
            }
            if (txttenncc.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttenncc.Focus();
                return;
            }
            sql = "Select Manhacungcap From Nhacungcap where Manhacungcap=N'" + txtmancc.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmancc.Focus();
                return;
            }

            sql = "INSERT INTO Nhacungcap VALUES(N'" +
                txtmancc.Text + "',N'" + txttenncc.Text+ "',N'" + txtsdt.Text + "',N'" + txtemail.Text + "',N'" + txtdiachi.Text +
                 "',N'" + txttrangthai.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmancc.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (NCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmancc.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenncc.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtsdt.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtemail.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtdiachi.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttrangthai.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE Nhacungcao SET Tennhacungcap=N'" +
                txttenncc.Text.ToString() +
                "' WHERE Manhacungcap=N'" + txtmancc.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (NCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmancc.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Nhacungcap WHERE Manhacungcap=N'" + txtmancc.Text + "'";
                Functions.RunSqlDel(sql);
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
            txtmancc.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
