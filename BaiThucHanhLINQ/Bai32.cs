using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai32
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 3.2:");
            string[] monAn = {
                "Nước Cà phê", "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang"
            };

            //a. Tìm các phần tử có chiều dài ngắn nhất và dài nhất.
            int minLen = monAn.Min(m => m.Length);
            int maxLen = monAn.Max(m => m.Length);
            Console.WriteLine("a. Phần tử ngắn nhất: " + string.Join(", ", monAn.Where(m => m.Length == minLen)));
            Console.WriteLine("   Phần tử dài nhất: " + string.Join(", ", monAn.Where(m => m.Length == maxLen)));

            // b. Phân nhóm theo từ đầu tiên của tên món và liệt kê các phần tử trong từng nhóm.
            Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
            var nhom = monAn.GroupBy(m => m.Split(' ')[0]);
            foreach (var g in nhom)
            {
                Console.WriteLine($"   Nhóm [{g.Key}]: " + string.Join("; ", g));
            }

            // c. Đếm số phần tử có từ đầu tiên là “Bánh”.
            Console.WriteLine("c. Số phần tử có từ đầu tiên là 'Bánh': " + monAn.Count(m => m.StartsWith("Bánh")));
        }
    }
}