using System;
using System.Collections.Generic;

namespace BTNC
{
    public class HocVien
    {
        public string HoTen { get; set; }
        public string Lop { get; set; } // lớp A hoặc lớp B

        public HocVien()
        {
            HoTen = "";
            Lop = "Lớp A";
        }

        public HocVien(string hoTen, string lop)
        {
            HoTen = hoTen;
            Lop = lop;
        }
    }

    // Lớp hỗ trợ xử lý danh sách học viên của 2 lớp
    public class QuanLyHocVien
    {
        public List<string> DanhSachLopA { get; set; } = new List<string>();
        public List<string> DanhSachLopB { get; set; } = new List<string>();

        // Thêm học viên vào lớp tương ứng
        public void ThemHocVien(string hoTen, string lop)
        {
            if (lop == "Lớp A")
            {
                DanhSachLopA.Add(hoTen);
            }
            else
            {
                DanhSachLopB.Add(hoTen);
            }
        }

        // Chuyển danh sách các học viên được chọn từ nguồn sang đích
        public void ChuyenLop(List<string> dsChon, List<string> lopNguon, List<string> lopDich)
        {
            foreach (string ten in dsChon)
            {
                lopNguon.Remove(ten);
                lopDich.Add(ten);
            }
        }

        // Xóa danh sách học viên được chọn
        public void XoaHocVien(List<string> dsChon, List<string> lop)
        {
            foreach (string ten in dsChon)
            {
                lop.Remove(ten);
            }
        }
    }
}