using System;

namespace Bai1
{
    public class PhepTinh
    {
        // Thuộc tính lưu trữ 2 giá trị đầu vào
        public double SoA { get; set; }
        public double SoB { get; set; }

        public PhepTinh()
        {
            SoA = 0;
            SoB = 0;
        }

        public PhepTinh(double a, double b)
        {
            SoA = a;
            SoB = b;
        }

        public double TinhCong() => SoA + SoB;
        public double TinhTru() => SoA - SoB;
        public double TinhNhan() => SoA * SoB;

        // Phép chia kiểm soát lỗi mẫu số bằng 0
        public double TinhChia()
        {
            if (SoB == 0)
            {
                throw new DivideByZeroException("Phép tính không hợp lệ: Mẫu số phải khác 0!");
            }
            return SoA / SoB;
        }
    }
}