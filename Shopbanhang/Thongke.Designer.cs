
namespace Shopbanhang
{
    partial class Thongke
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvThongke = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnthongke = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtthang = new System.Windows.Forms.TextBox();
            this.txtnam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbdoanhthu = new System.Windows.Forms.Label();
            this.tblbangchu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThongke
            // 
            this.dgvThongke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongke.BackgroundColor = System.Drawing.Color.Honeydew;
            this.dgvThongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongke.Location = new System.Drawing.Point(21, 191);
            this.dgvThongke.Name = "dgvThongke";
            this.dgvThongke.RowHeadersWidth = 62;
            this.dgvThongke.RowTemplate.Height = 28;
            this.dgvThongke.Size = new System.Drawing.Size(1018, 217);
            this.dgvThongke.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(364, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // btnthongke
            // 
            this.btnthongke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnthongke.BackColor = System.Drawing.Color.CadetBlue;
            this.btnthongke.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthongke.ForeColor = System.Drawing.SystemColors.Window;
            this.btnthongke.Location = new System.Drawing.Point(875, 129);
            this.btnthongke.Name = "btnthongke";
            this.btnthongke.Size = new System.Drawing.Size(125, 35);
            this.btnthongke.TabIndex = 6;
            this.btnthongke.Text = "Thống kê";
            this.btnthongke.UseVisualStyleBackColor = false;
            this.btnthongke.Click += new System.EventHandler(this.btnthongke_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(26, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nhập tháng cần thống kê";
            // 
            // txtthang
            // 
            this.txtthang.Location = new System.Drawing.Point(282, 80);
            this.txtthang.Name = "txtthang";
            this.txtthang.Size = new System.Drawing.Size(137, 26);
            this.txtthang.TabIndex = 8;
            // 
            // txtnam
            // 
            this.txtnam.Location = new System.Drawing.Point(781, 82);
            this.txtnam.Name = "txtnam";
            this.txtnam.Size = new System.Drawing.Size(137, 26);
            this.txtnam.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(540, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nhập năm cần thống kê";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbdoanhthu);
            this.panel1.Controls.Add(this.tblbangchu);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(21, 428);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 131);
            this.panel1.TabIndex = 11;
            // 
            // lbdoanhthu
            // 
            this.lbdoanhthu.AutoSize = true;
            this.lbdoanhthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdoanhthu.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbdoanhthu.Location = new System.Drawing.Point(136, 49);
            this.lbdoanhthu.Name = "lbdoanhthu";
            this.lbdoanhthu.Size = new System.Drawing.Size(82, 29);
            this.lbdoanhthu.TabIndex = 3;
            this.lbdoanhthu.Text = "0 VNĐ";
            // 
            // tblbangchu
            // 
            this.tblbangchu.AutoSize = true;
            this.tblbangchu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblbangchu.ForeColor = System.Drawing.Color.Red;
            this.tblbangchu.Location = new System.Drawing.Point(13, 97);
            this.tblbangchu.Name = "tblbangchu";
            this.tblbangchu.Size = new System.Drawing.Size(96, 22);
            this.tblbangchu.TabIndex = 2;
            this.tblbangchu.Text = "Thành chữ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 32);
            this.label4.TabIndex = 1;
            this.label4.Text = "Doanh thu:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CadetBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(830, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 43);
            this.button1.TabIndex = 12;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1051, 587);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtnam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtthang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnthongke);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvThongke);
            this.Name = "Thongke";
            this.Text = "THỐNG KÊ DOANH THU";
            this.Load += new System.EventHandler(this.Thongke_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongke)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThongke;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnthongke;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtthang;
        private System.Windows.Forms.TextBox txtnam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tblbangchu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbdoanhthu;
    }
}