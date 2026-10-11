using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai1
{
    public class GiaoDienBai1 : Form
    {
        // Khai báo các thành phần điều khiển
        private Label lblA, lblB, lblKetQua;
        private TextBox txtA, txtB, txtKetQua;
        private Button btnCong, btnTru, btnNhan, btnChia;
        private ErrorProvider epKiemTra;

        public GiaoDienBai1()
        {
            KhoiTaoCacControl();
        }

        private void KhoiTaoCacControl()
        {
            // Thiết lập thuộc tính cửa sổ Form
            this.Text = "Cộng trừ nhân chia";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            epKiemTra = new ErrorProvider();

            // Label và TextBox nhập hệ số a
            lblA = new Label() { Text = "a =", Location = new Point(30, 25), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtA = new TextBox() { Location = new Point(65, 22), Width = 80 };
            txtA.KeyPress += ChanNhapKyTuChu_KeyPress;
            txtA.Leave += KiemTraRong_Leave;

            // Label và TextBox nhập hệ số b
            lblB = new Label() { Text = "b =", Location = new Point(175, 25), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            txtB = new TextBox() { Location = new Point(210, 22), Width = 80 };
            txtB.KeyPress += ChanNhapKyTuChu_KeyPress;
            txtB.Leave += KiemTraRong_Leave;

            // Vùng hiển thị kết quả
            lblKetQua = new Label() { Text = "Kết quả", Location = new Point(30, 68), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold) };
            txtKetQua = new TextBox() { Location = new Point(95, 65), Width = 195, ReadOnly = true };

            // 4 Button phép toán cơ bản
            btnCong = new Button() { Text = "+", Location = new Point(35, 115), Size = new Size(55, 35), Font = new Font("Arial", 11, FontStyle.Bold) };
            btnTru = new Button() { Text = "-", Location = new Point(105, 115), Size = new Size(55, 35), Font = new Font("Arial", 11, FontStyle.Bold) };
            btnNhan = new Button() { Text = "x", Location = new Point(175, 115), Size = new Size(55, 35), Font = new Font("Arial", 11, FontStyle.Bold) };
            btnChia = new Button() { Text = "/", Location = new Point(245, 115), Size = new Size(55, 35), Font = new Font("Arial", 11, FontStyle.Bold) };

            // Gắn sự kiện tính toán tương ứng
            btnCong.Click += (s, e) => XuLyPhepToan('+');
            btnTru.Click += (s, e) => XuLyPhepToan('-');
            btnNhan.Click += (s, e) => XuLyPhepToan('*');
            btnChia.Click += (s, e) => XuLyPhepToan('/');

            this.Controls.AddRange(new Control[] {
                lblA, txtA, lblB, txtB, lblKetQua, txtKetQua,
                btnCong, btnTru, btnNhan, btnChia
            });

            this.FormClosing += GiaoDienBai1_FormClosing;
        }

        // mức 1: Dùng ErrorProvider thông báo lỗi 
        private void KiemTraRong_Leave(object sender, EventArgs e)
        {
            TextBox oNhap = sender as TextBox;
            if (string.IsNullOrWhiteSpace(oNhap.Text))
            {
                epKiemTra.SetError(oNhap, "Ô này không được để trống!");
            }
            else
            {
                epKiemTra.SetError(oNhap, "");
            }
        }

        // mức 2: chặn trực tiếp không cho nhập ký tự khác số từ bàn phím
        private void ChanNhapKyTuChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox oNhap = sender as TextBox;

            // Nhận phím điều khiển và chữ số
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            // Nhận dấu âm ở đầu chuỗi
            if (e.KeyChar == '-' && oNhap.SelectionStart == 0 && !oNhap.Text.Contains("-")) return;

            // Nhận tối đa một dấu chấm thập phân
            if (e.KeyChar == '.' && !oNhap.Text.Contains(".")) return;

            // Hủy sự kiện nếu là chữ cái hoặc ký tự lạ
            e.Handled = true;
        }

        // Hàm điều phối tính toán
        private void XuLyPhepToan(char dauToanTu)
        {
            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị hai số a và b!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                double a = double.Parse(txtA.Text.Trim());
                double b = double.Parse(txtB.Text.Trim());

                PhepTinh pt = new PhepTinh(a, b);
                double ketQua = 0;

                switch (dauToanTu)
                {
                    case '+': ketQua = pt.TinhCong(); break;
                    case '-': ketQua = pt.TinhTru(); break;
                    case '*': ketQua = pt.TinhNhan(); break;
                    case '/': ketQua = pt.TinhChia(); break;
                }

                txtKetQua.Text = ketQua.ToString();
            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi chia 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKetQua.Text = "Lỗi chia 0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hỏi xác nhận trước khi đóng ứng dụng
        private void GiaoDienBai1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult hoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}