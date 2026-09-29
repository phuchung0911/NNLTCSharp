using System;

namespace ThucHanh02
{
    class Person
    {
        // Field
        private string id;
        private string name;
        private int yob;
        private int yod;

        // Property
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Yob
        {
            get { return yob; }
            set { yob = value; }
        }

        public int Yod
        {
            get { return yod; }
            set { yod = value; }
        }

        // Default Constructor
        public Person()
        {
            id = "";
            name = "";
            yob = 0;
            yod = 0;
        }

        // Constructor co tham so
        public Person(string id, string name, int yob, int yod)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // Copy Constructor
        public Person(Person p)
        {
            this.id = p.id;
            this.name = p.name;
            this.yob = p.yob;
            this.yod = p.yod;
        }

        // Method
        public void Nhap()
        {
            Console.Write("Nhap ma dinh danh (ID): ");
            Id = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            Name = Console.ReadLine() ?? "";

            Console.Write("Nhap nam sinh (YOB): ");
            Yob = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap nam mat (YOD - nhap 0 neu con song): ");
            Yod = int.Parse(Console.ReadLine() ?? "0");
        }

        public bool IsLiving()
        {
            return Yod == 0;
        }

        public void Xuat()
        {
            Console.WriteLine("ID: {0}", Id);
            Console.WriteLine("Ho ten: {0}", Name);
            Console.WriteLine("Nam sinh: {0}", Yob);
            if (IsLiving())
            {
                Console.WriteLine("Tinh trang: Con song");
            }
            else
            {
                Console.WriteLine("Nam mat: {0}", Yod);
                Console.WriteLine("Tinh trang: Da mat");
            }
        }
    }

    class Bai1_3
    {
        public static void Main(string[] args)
        {
            // Khoi tao bang Default Constructor
            Person p1 = new Person();
            Console.WriteLine("NHAP THONG TIN CA NHAN 1:");
            p1.Nhap();

            Console.WriteLine("\nTHONG TIN CA NHAN 1:");
            p1.Xuat();

            // Khoi tao bang Copy Constructor
            Person p2 = new Person(p1);
            Console.WriteLine("\nTHONG TIN CA NHAN 2 (SAO CHEP TU CA NHAN 1):");
            p2.Xuat();
        }
    }
}