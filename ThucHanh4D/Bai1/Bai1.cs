using System;

namespace Bai1
{
    public class PhuongTrinhBacHai
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }

        public PhuongTrinhBacHai()
        {
            a = b = c = 0;
        }

        public PhuongTrinhBacHai(double a, double b, double c = 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public string GiaiBacNhat()
        {
            if (a == 0)
            {
                if (b == 0) return "Phương trình vô số nghiệm";
                return "Phương trình vô nghiệm";
            }
            double x = -b / a;
            return "Phương trình có nghiệm x = " + x.ToString("0.00");
        }

        public string GiaiBacHai()
        {
            if (a == 0)
            {
                return GiaiBacNhat();
            }

            double delta = b * b - 4 * a * c;

            if (delta < 0) return "Phương trình vô nghiệm";
            if (delta == 0)
            {
                double xKep = -b / (2 * a);
                return "Phương trình có nghiệm kép x1 = x2 = " + xKep.ToString("0.00");
            }

            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return "x1 = " + x1.ToString("0.00") + "; x2 = " + x2.ToString("0.00");
        }
    }
}