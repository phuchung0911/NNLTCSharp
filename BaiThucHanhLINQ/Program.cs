using System;
using System.Text;

namespace BaiThucHanhLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // chạy lần lượt từng bài
            Bai21.Chay();
            Bai22.Chay();
            Bai31.Chay();
            Bai32.Chay();
            Bai51.Chay();
            Bai52.Chay();
            Bai62.Chay();

            Console.WriteLine("Nhấn phím bất kì để thoát.");
            Console.ReadKey();
        }
    }
}