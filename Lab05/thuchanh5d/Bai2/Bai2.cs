using System;
using System.Collections.Generic;

namespace Bai2
{
    public class TaiKhoan
    {
        public string SoTaiKhoan { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public decimal SoTien { get; set; }

        public TaiKhoan()
        {
            SoTaiKhoan = "";
            TenKhachHang = "";
            DiaChi = "";
            SoTien = 0;
        }

        public TaiKhoan(string stk, string ten, string diaChi, decimal soTien)
        {
            SoTaiKhoan = stk;
            TenKhachHang = ten;
            DiaChi = diaChi;
            SoTien = soTien;
        }
    }

    // Lớp quản lý danh sách tài khoản
    public class QuanLyTaiKhoan
    {
        // Danh sách rỗng ban đầu để người dùng tự nhập tay
        private List<TaiKhoan> danhSach = new List<TaiKhoan>();

        public List<TaiKhoan> LayDanhSach() => danhSach;

        // Kiểm tra xem số tài khoản đã có chưa
        public bool KiemTraTrungSTK(string stk)
        {
            foreach (var tk in danhSach)
            {
                if (string.Compare(tk.SoTaiKhoan, stk.Trim(), true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Thêm tài khoản mới vào danh sách
        public bool Them(TaiKhoan tk)
        {
            if (KiemTraTrungSTK(tk.SoTaiKhoan)) return false;
            danhSach.Add(tk);
            return true;
        }

        // Xóa tài khoản theo số tài khoản
        public bool Xoa(string stk)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (string.Compare(danhSach[i].SoTaiKhoan, stk.Trim(), true) == 0)
                {
                    danhSach.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Tính tổng tiền hiện có trong danh sách
        public decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (var tk in danhSach)
            {
                tong += tk.SoTien;
            }
            return tong;
        }
    }
}