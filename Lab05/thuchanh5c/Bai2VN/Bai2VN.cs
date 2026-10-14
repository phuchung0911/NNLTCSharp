using System;
using System.Collections.Generic;

namespace BTVN2
{
    public class XuLySoNguyen
    {
        // Tính tổng các phần tử trong danh sách
        public static long TinhTong(List<int> danhSach)
        {
            long tong = 0;
            foreach (int x in danhSach)
            {
                tong += x;
            }
            return tong;
        }

        // Tăng mỗi phần tử trong danh sách lên 2
        public static void TangLenHai(List<int> danhSach)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                danhSach[i] += 2;
            }
        }

        // Thay mỗi phần tử bằng bình phương của chính nó
        public static void ThayBangBinhPhuong(List<int> danhSach)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                danhSach[i] = danhSach[i] * danhSach[i];
            }
        }

        // Kiểm tra số chẵn
        public static bool LaSoChan(int n)
        {
            return n % 2 == 0;
        }

        // Kiểm tra số lẻ
        public static bool LaSoLe(int n)
        {
            return n % 2 != 0;
        }
    }
}