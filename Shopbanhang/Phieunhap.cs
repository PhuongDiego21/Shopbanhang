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
    public partial class Phieunhap : Form
    {
        DataTable phieunhap;
        public Phieunhap()
        {
            InitializeComponent();
        }

        private void Phieunhap_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from Nhacungcap";
            txtmaphn.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cbnhacc, "Manhacungcap", "Tennhacungcap");
            cbnhacc.SelectedIndex = -1;
            sql = "SELECT * from tblChatLieu";
            Functions.FillCombo(sql, cbchatlieu, "MaChatLieu", "TenChatLieu");
            cbchatlieu.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtmaphn.Text = "";
            cbnhacc.Text = "";
            cbchatlieu.Text = "";
            txtgia.Text = "";
            txtsoluong.Text = "";
            txtngaynhap.Text = "";

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from Phieunhap";
            phieunhap = Functions.GetDataToTable(sql);
            dgvphieunhap.DataSource = phieunhap;
            dgvphieunhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dgvphieunhap.Columns[1].HeaderText = "Nhà cung cấp";
            dgvphieunhap.Columns[2].HeaderText = "Chất liệu";
            dgvphieunhap.Columns[3].HeaderText = "Số lượng nhập";
            dgvphieunhap.Columns[4].HeaderText = "Giá nhập";
            dgvphieunhap.Columns[5].HeaderText = "Ngày nhập";

            dgvphieunhap.Columns[0].Width = 80;
            dgvphieunhap.Columns[1].Width = 140;
            dgvphieunhap.Columns[2].Width = 80;
            dgvphieunhap.Columns[3].Width = 80;
            dgvphieunhap.Columns[4].Width = 80;
            dgvphieunhap.Columns[5].Width = 80;

            dgvphieunhap.AllowUserToAddRows = false;
            dgvphieunhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvphieunhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Manhacungcap;
            string Machatlieu;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphn.Focus();
                return;
            }
            if (phieunhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaphn.Text = dgvphieunhap.CurrentRow.Cells["Maphieunhap"].Value.ToString();

            Manhacungcap = dgvphieunhap.CurrentRow.Cells["Manhacungcap"].Value.ToString();
            sql = "SELECT Tennhacungcap FROM Nhacungcap WHERE Manhacungcap=N'" + Manhacungcap + "'";
            cbnhacc.Text = Functions.GetFieldValues(sql);

            Machatlieu = dgvphieunhap.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + Machatlieu + "'";
            cbchatlieu.Text = Functions.GetFieldValues(sql);
            txtsoluong.Text = dgvphieunhap.CurrentRow.Cells["Soluongnhap"].Value.ToString();
            txtgia.Text = dgvphieunhap.CurrentRow.Cells["Gianhap"].Value.ToString();
            txtngaynhap.Text = dgvphieunhap.CurrentRow.Cells["Ngaynhap"].Value.ToString();

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
            txtmaphn.Enabled = true;
            txtmaphn.Focus();
            txtsoluong.Enabled = true;
            txtgia.Enabled = true;
            txtngaynhap.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaphn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã phiếu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphn.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            if (cbnhacc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbnhacc.Focus();
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
                MessageBox.Show("Bạn phải nhập giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtgia.Focus();
                return;
            }
            if (txtngaynhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngaynhap.Focus();
                return;
            }

            sql = "INSERT INTO Phieunhap(Maphieunhap,Manhacungcap,MaChatLieu, Soluongnhap,Gianhap, Ngaynhap) VALUES(N'"
                + txtmaphn.Text.Trim()+"',N'" + cbnhacc.SelectedValue.ToString() + "',N'" + cbchatlieu.SelectedValue.ToString() + 
                "',N'" + txtsoluong.Text.Trim() + "',N'" + txtgia.Text.Trim() + "',N'" + txtngaynhap.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtmaphn.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (phieunhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphn.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE Phieunhap WHERE Maphieunhap=N'" + txtmaphn.Text + "'";
                Functions.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (phieunhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaphn.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmaphn.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsoluong.Focus();
                return;
            }
            if (cbnhacc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nha cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbnhacc.Focus();
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
            if (txtngaynhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtngaynhap.Focus();
                return;
            }
            sql = "UPDATE Phieunhap SET Manhacungcap=N'" + cbnhacc.SelectedValue.ToString() +
              "',MaChatLieu=N'" + cbchatlieu.SelectedValue.ToString() +
              "',Soluongnhap=" + txtsoluong.Text +
              ",Gianhap='" + txtgia.Text + "',Ngaynhap=N'" + txtngaynhap.Text + "' WHERE Maphieunhap=N'" + txtmaphn.Text + "'";
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
            txtmaphn.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
