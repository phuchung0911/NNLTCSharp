using System;

namespace Bai3
{
    public class UocBoiSo
    {
        public long A { get; set; }
        public long B { get; set; }

        public UocBoiSo()
        {
            A = 0;
            B = 0;
        }

        public UocBoiSo(long a, long b)
        {
            A = a;
            B = b;
        }

        // Tìm Ước số chung lớn nhất 
        public long TimUCLN()
        {
            long x = Math.Abs(A);
            long y = Math.Abs(B);

            if (x == 0 && y == 0) return 0; // Cả 2 bằng 0 ko xác định
            if (x == 0) return y;
            if (y == 0) return x;

            while (y != 0)
            {
                long du = x % y;
                x = y;
                y = du;
            }
            return x;
        }

        // Tìm Bội số chung nhỏ nhất 
        public long TimBCNN()
        {
            long ucln = TimUCLN();
            if (ucln == 0) return 0;

            return Math.Abs(A * B) / ucln;
        }
    }
}