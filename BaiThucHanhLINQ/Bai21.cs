using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai21
    {
        public static void Chay()
        {
            Console.WriteLine("-- Bài 2.1:");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Liệt kê các phần tử chia hết cho 4 và 3
            var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
            Console.WriteLine("a. Chia hết cho 4 và 3: " + string.Join(", ", cauA));

            // b. Liệt kê các phần tử nhỏ hơn hoặc bằng 3
            var cauB = mangSo.Where(x => x <= 3);
            Console.WriteLine("b. Nhỏ hơn hoặc bằng 3: " + string.Join(", ", cauB));

            // c. Tạo một mảng dữ liệu mới ngẫu nhiên (không viết cứng số theo mảng cũ)
            Random rd = new Random();
            int[] mangMoi = Enumerable.Range(1, 10).Select(_ => rd.Next(1, 100)).ToArray();
            Console.WriteLine("c. Mảng dữ liệu mới: " + string.Join(", ", mangMoi));

            // Tạo một dãy mới: chẵn chia đôi, lẻ giữ nguyên
            var cauC = mangMoi.Select(x => x % 2 == 0 ? x / 2 : x);
            Console.WriteLine("   Dãy sau biến đổi: " + string.Join(", ", cauC));
        }
    }
}