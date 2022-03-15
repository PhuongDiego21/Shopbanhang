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
    public partial class Phieuxuat : Form
    {
        DataTable phieuxuat;
        public Phieuxuat()
        {
            InitializeComponent();
        }

        private void Phieuxuat_Load(object sender, EventArgs e)
        {
            string sql;
            txtmaphx.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
            sql = "SELECT * from tblChatLieu";
            Functions.FillCombo(sql, cbchatlieu, "MaChatLieu", "TenChatLieu");
            cbchatlieu.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtmaphx.Text = "";
            cbchatlieu.Text = "";
            txtgia.Text = "";
            txtsoluong.Text = "";
            txtngayxuat.Text = "";

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Phieuxuat";
            phieuxuat = Functions.GetDataToTable(sql);
            dgvphieuxuat.DataSource = phieuxuat;
            dgvphieuxuat.Columns[0].HeaderText = "Mã phiếu xuất";
            dgvphieuxuat.Columns[1].HeaderText = "Chất liệu";
            dgvphieuxuat.Columns[2].HeaderText = "Số lượng xuất";
            dgvphieuxuat.Columns[3].HeaderText = "Giá xuất";
            dgvphieuxuat.Columns[4].HeaderText = "Ngày xuất";

            dgvphieuxuat.Columns[0].Width = 80;
            dgvphieuxuat.Columns[1].Width = 140;
            dgvphieuxuat.Columns[2].Width = 80;
            dgvphieuxuat.Columns[3].Width = 80;
            dgvphieuxuat.Columns[4].Width = 80;

            dgvphieuxuat.AllowUserToAddRows = false;
            dgvphieuxuat.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvphieuxuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Machatlieu;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphx.Focus();
                return;
            }
            if (phieuxuat.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaphx.Text = dgvphieuxuat.CurrentRow.Cells["Maphieuxuat"].Value.ToString();

            Machatlieu = dgvphieuxuat.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + Machatlieu + "'";
            cbchatlieu.Text = Functions.GetFieldValues(sql);
            txtsoluong.Text = dgvphieuxuat.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtgia.Text = dgvphieuxuat.CurrentRow.Cells["Giaxuat"].Value.ToString();
            txtngayxuat.Text = dgvphieuxuat.CurrentRow.Cells["Ngayxuat"].Value.ToString();

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
            txtmaphx.Enabled = true;
            txtmaphx.Focus();
            txtsoluong.Enabled = true;
            txtgia.Enabled = true;
            txtngayxuat.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaphx.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phiếu xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphx.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            
            if (cbchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbchatlieu.Focus();
                return;
            }
            if (txtgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgia.Focus();
                return;
            }
            if (txtngayxuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngayxuat.Focus();
                return;
            }

            sql = "INSERT INTO Phieuxuat(Maphieuxuat,MaChatLieu, SoLuong,Giaxuat, Ngayxuat) VALUES(N'"
                + txtmaphx.Text.Trim() + "',N'" + cbchatlieu.SelectedValue.ToString() +
                "',N'" + txtsoluong.Text.Trim() + "',N'" + txtgia.Text.Trim() + "',N'" + txtngayxuat.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaphx.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (phieuxuat.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Phieuxuat WHERE Maphieuxuat=N'" + txtmaphx.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (phieuxuat.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphx.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            
            if (cbchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbchatlieu.Focus();
                return;
            }
            if (txtgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgia.Focus();
                return;
            }
            if (txtngayxuat.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngayxuat.Focus();
                return;
            }
            sql = "UPDATE Phieuxuat SET MaChatLieu=N'" + cbchatlieu.SelectedValue.ToString() +
              "',SoLuong=" + txtsoluong.Text +",Giaxuat='" + txtgia.Text +
              "',Ngayxuat=N'" + txtngayxuat.Text + "' WHERE Maphieuxuat=N'" + txtmaphx.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaphx.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
