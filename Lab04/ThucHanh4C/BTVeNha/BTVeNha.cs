using System;

namespace BTVeNha
{
    public class MayTinhBoTui
    {
        // Toán hạng thứ nhất
        public double SoThuNhat { get; set; } = 0;

        // Phép toán đang thực hiện +, -, *, /
        public char PhepToan { get; set; } = ' ';

        // Cờ kiểm tra có đang chờ nhập số mới sau khi nhấn phép tính hay ko
        public bool DangChoSoMoi { get; set; } = false;

        public MayTinhBoTui()
        {
            Reset();
        }

        // Thực hiện phép tính giữa SoThuNhat và SoThuHai
        public double TinhToan(double soThuHai)
        {
            switch (PhepToan)
            {
                case '+':
                    return SoThuNhat + soThuHai;
                case '-':
                    return SoThuNhat - soThuHai;
                case '*':
                    return SoThuNhat * soThuHai;
                case '/':
                    if (soThuHai == 0)
                    {
                        throw new DivideByZeroException("Không thể chia cho số 0!");
                    }
                    return SoThuNhat / soThuHai;
                default:
                    return soThuHai;
            }
        }

        // Xóa sạch trạng thái máy tính (nut c)
        public void Reset()
        {
            SoThuNhat = 0;
            PhepToan = ' ';
            DangChoSoMoi = false;
        }
    }
}