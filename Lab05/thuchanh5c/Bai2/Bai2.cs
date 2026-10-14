using System;
using System.Collections.Generic;

namespace ThucHanh5c_Bai2
{
    // Lớp chứa thông tin một sinh viên
    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        public SinhVien()
        {
            MaSV = "";
            HoTen = "";
            DiaChi = "";
        }

        public SinhVien(string maSV, string hoTen, string diaChi)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiaChi = diaChi;
        }

        // Định dạng chuỗi hiển thị trên nút cha: "Mã SV, Họ Tên"
        public string LayChuoiHienThi()
        {
            return MaSV + ", " + HoTen;
        }
    }

    // Lớp quản lý danh sách lớp và sinh viên
    public class QuanLyLopHoc
    {
        // Danh sách tên các lớp học
        private List<string> danhSachLop;

        // Lưu trữ sinh viên: Khóa là tên lớp, Giá trị là danh sách sinh viên của lớp đó
        private Dictionary<string, List<SinhVien>> duLieuSinhVien;

        public QuanLyLopHoc()
        {
            danhSachLop = new List<string>();
            duLieuSinhVien = new Dictionary<string, List<SinhVien>>();

            // Nạp sẵn 4 lớp mẫu ban đầu theo đề bài
            string[] cacLop = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (string lop in cacLop)
            {
                ThemLop(lop);
            }
        }

        // Lấy danh sách các lớp hiện có
        public List<string> LayDanhSachLop()
        {
            return danhSachLop;
        }

        // Kiểm tra xem tên lớp đã tồn tại chưa (không phân biệt chữ hoa, chữ thường)
        public bool KiemTraTrungLop(string tenLop)
        {
            foreach (string lop in danhSachLop)
            {
                if (string.Compare(lop, tenLop, true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Thêm lớp mới
        public bool ThemLop(string tenLop)
        {
            if (KiemTraTrungLop(tenLop)) return false;

            danhSachLop.Add(tenLop);
            duLieuSinhVien[tenLop] = new List<SinhVien>();
            return true;
        }

        // Kiểm tra xem mã sinh viên đã có trong toàn trường chưa
        public bool KiemTraTrungMaSV(string maSV)
        {
            foreach (var dsSV in duLieuSinhVien.Values)
            {
                foreach (var sv in dsSV)
                {
                    if (string.Compare(sv.MaSV, maSV, true) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Thêm sinh viên vào lớp chỉ định
        public bool ThemSinhVien(string tenLop, SinhVien sv)
        {
            if (!duLieuSinhVien.ContainsKey(tenLop)) return false;
            if (KiemTraTrungMaSV(sv.MaSV)) return false;

            duLieuSinhVien[tenLop].Add(sv);
            return true;
        }

        // Xóa một sinh viên theo mã SV
        public bool XoaSinhVien(string maSV)
        {
            foreach (var dsSV in duLieuSinhVien.Values)
            {
                for (int i = 0; i < dsSV.Count; i++)
                {
                    if (string.Compare(dsSV[i].MaSV, maSV, true) == 0)
                    {
                        dsSV.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}