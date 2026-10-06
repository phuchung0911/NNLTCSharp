using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public static class Bai31
    {
        public static void Chay()
        {
            Console.WriteLine("\n-- Bài 3.1:");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Cho biết tổng số phần tử, số phần tử chẵn và số phần tử lẻ.
            Console.WriteLine($"a. Tổng số phần tử: {mangSo.Count()}");
            Console.WriteLine($"   chẵn: {mangSo.Where(x => x % 2 == 0).Sum()}");
            Console.WriteLine($"   lẻ: {mangSo.Where(x => x % 2 != 0).Max()}");

            // b. Tính tổng các giá trị, giá trị lớn nhất và giá trị nhỏ nhất.
            Console.WriteLine($"b. Tổng các giá trị: {mangSo.Sum()}");
            Console.WriteLine($"   max: {mangSo.Max()}");
            Console.WriteLine($"   min: {mangSo.Min()}");

            // c. Cho biết có bao nhiêu giá trị khác nhau trong mảng.
            Console.WriteLine($"c. Số giá trị khác nhau: {mangSo.Distinct().Count()}");

            // d. Phân nhóm các phần tử theo số dư khi chia cho 5; in số dư và các phần tử thuộc từng nhóm.
            Console.WriteLine("d. Phân nhóm theo số dư khi chia cho 5:");
            var nhom = mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key);
            foreach (var g in nhom)
            {
                Console.WriteLine($"   Số dư {g.Key}: " + string.Join(", ", g));
            }
        }
    }
}