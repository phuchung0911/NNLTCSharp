using System;
using System.Collections.Generic;

namespace Bai1
{
    public class SinhVien
    {
        public string HoTen { get; set; }
        public string MaSV { get; set; }
        public string GioiTinh { get; set; }
        public string NgoaiNgu { get; set; }
        public string DanToc { get; set; }

        public SinhVien()
        {
            HoTen = "";
            MaSV = "";
            GioiTinh = "Nam";
            NgoaiNgu = "";
            DanToc = "Kinh";
        }

        public SinhVien(string hoTen, string maSV, string gioiTinh, string ngoaiNgu, string danToc)
        {
            HoTen = hoTen;
            MaSV = maSV;
            GioiTinh = gioiTinh;
            NgoaiNgu = ngoaiNgu;
            DanToc = danToc;
        }
    }

    // Lớp quản lý danh sách sinh viên
    public class QuanLySinhVien
    {
        private List<SinhVien> danhSach = new List<SinhVien>();

        public List<SinhVien> LayDanhSach() => danhSach;

        // Kiểm tra trùng mã sinh viên
        public bool KiemTraTrungMa(string maSV)
        {
            foreach (var sv in danhSach)
            {
                if (string.Compare(sv.MaSV, maSV.Trim(), true) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // Thêm sinh viên mới
        public bool Them(SinhVien sv)
        {
            if (KiemTraTrungMa(sv.MaSV)) return false;
            danhSach.Add(sv);
            return true;
        }

        // Xóa sinh viên theo mã
        public bool Xoa(string maSV)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (string.Compare(danhSach[i].MaSV, maSV.Trim(), true) == 0)
                {
                    danhSach.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        // Sửa thông tin sinh viên (giữ nguyên mã SV)
        public bool Sua(SinhVien svMoi)
        {
            for (int i = 0; i < danhSach.Count; i++)
            {
                if (string.Compare(danhSach[i].MaSV, svMoi.MaSV.Trim(), true) == 0)
                {
                    danhSach[i].HoTen = svMoi.HoTen;
                    danhSach[i].GioiTinh = svMoi.GioiTinh;
                    danhSach[i].NgoaiNgu = svMoi.NgoaiNgu;
                    danhSach[i].DanToc = svMoi.DanToc;
                    return true;
                }
            }
            return false;
        }
    }
}