using System;
using System.Collections;

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

        // Constructor mac nhien
        public Point()
        {
            x = 0;
            y = 0;
        }

        // Constructor co tham so
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Constructor sao chep
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }

        // Method
        public void Nhap()
        {
            Console.Write("Nhap toa do x: ");
            X = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap toa do y: ");
            Y = double.Parse(Console.ReadLine() ?? "0");
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }

    // Lop phuc ArrayPoint quan ly danh sach cac Point
    class ArrayPoint
    {
        // Field
        private ArrayList danhSach;

        // Property lay so luong diem
        public int SoLuong
        {
            get { return danhSach.Count; }
        }

        // Constructor mac nhien
        public ArrayPoint()
        {
            danhSach = new ArrayList();
        }

        // Constructor co tham so
        public ArrayPoint(int capacity)
        {
            danhSach = new ArrayList(capacity);
        }

        // Constructor sao chep
        public ArrayPoint(ArrayPoint ap)
        {
            danhSach = new ArrayList();
            for (int i = 0; i < ap.SoLuong; i++)
            {
                danhSach.Add(new Point(ap[i]));
            }
        }

        // Indexer cho phep truy cap Point thu i
        public Point this[int index]
        {
            get
            {
                if (index >= 0 && index < danhSach.Count)
                {
                    return (Point)danhSach[index]!;
                }
                throw new IndexOutOfRangeException("Chi so vuot qua pham vi danh sach!");
            }
            set
            {
                if (index >= 0 && index < danhSach.Count)
                {
                    danhSach[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Chi so vuot qua pham vi danh sach!");
                }
            }
        }

        // Method them 1 Point vao danh sach
        public void Them(Point p)
        {
            danhSach.Add(p);
        }

        // Method nhap danh sach cac Point
        public void Nhap()
        {
            Console.Write("Nhap so luong diem: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nNhap diem thu {0}:", i + 1);
                Point p = new Point();
                p.Nhap();
                danhSach.Add(p);
            }
        }

        // Method xuat danh sach cac Point su dung Indexer
        public void Xuat()
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                Console.WriteLine("Diem [{0}]: {1}", i, this[i]);
            }
        }
    }

    class Bai2_1
    {
        public static void Main(string[] args)
        {
            ArrayPoint ds = new ArrayPoint();

            Console.WriteLine("NHAP DANH SACH CAC DIEM:");
            ds.Nhap();

            Console.WriteLine("\nDANH SACH DIEM VUA NHAP:");
            ds.Xuat();

            if (ds.SoLuong > 0)
            {
                Console.WriteLine("\nKIEM TRA INDEXER:");
                Console.WriteLine("Diem tai vi tri index 0 la: {0}", ds[0]);

                Console.WriteLine("\nCap nhat diem tai index 0 thanh toan bo (9, 9)...");
                ds[0] = new Point(9, 9);

                Console.WriteLine("Diem tai vi tri index 0 sau khi cap nhat: {0}", ds[0]);
            }
        }
    }
}