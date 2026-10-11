using System;

namespace ThucHanh02
{
    class Point
    {
        // Field
        private double x;
        private double y;

        // Property
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // Constructor
        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Method
        public void Nhap()
        {
            Console.Write("Nhap toa do x: ");
            X = double.Parse(Console.ReadLine());

            Console.Write("Nhap toa do y: ");
            Y = double.Parse(Console.ReadLine());
        }

        public void Xuat()
        {
            Console.WriteLine("({0}, {1})", X, Y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        // cac phep toan +, -, lay am
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y);
        }

        // a. khoang cach giua 2 diem
        // Phuong thuc thanh vien
        public double KhoangCach(Point p)
        {
            return Math.Sqrt(Math.Pow(this.X - p.X, 2) + Math.Pow(this.Y - p.Y, 2));
        }

        // Phuong thuc tinh
        public static double KhoangCach(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        // b. Trung diem cua 2 diem
        // Phuong thuc thanh vien
        public Point TrungDiem(Point p)
        {
            return new Point((this.X + p.X) / 2, (this.Y + p.Y) / 2);
        }

        // Phuong thuc tinh
        public static Point TrungDiem(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }

    class Bai1_2
    {
        public static void Main(string[] args)
        {
            Point A = new Point();
            Point B = new Point();

            Console.WriteLine("NHAP TOA DO DIEM A:");
            A.Nhap();

            Console.WriteLine("\nNHAP TOA DO DIEM B:");
            B.Nhap();

            Console.WriteLine("\nTOA DO CAC DIEM:");
            Console.WriteLine("Diem A: {0}", A);
            Console.WriteLine("Diem B: {0}", B);

            Console.WriteLine("\nCAC PHEP TOAN TOA DO:");
            Point tong = A + B;
            Point hieu = A - B;
            Point doiA = -A;
            Console.WriteLine("A + B = {0}", tong);
            Console.WriteLine("A - B = {0}", hieu);
            Console.WriteLine("-A = {0}", doiA);

            Console.WriteLine("\nKHOANG CACH GIUA A VA B:");
            Console.WriteLine("Phuong thuc thanh vien: {0:F2}", A.KhoangCach(B));
            Console.WriteLine("Phuong thuc tinh: {0:F2}", Point.KhoangCach(A, B));

            Console.WriteLine("\nTRUNG DIEM I CUA AB:");
            Point i1 = A.TrungDiem(B);
            Point i2 = Point.TrungDiem(A, B);
            Console.WriteLine("Phuong thuc thanh vien: {0}", i1);
            Console.WriteLine("Phuong thuc tinh: {0}", i2);
        }
    }
}