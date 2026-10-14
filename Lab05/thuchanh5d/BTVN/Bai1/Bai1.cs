using System;

namespace BTVN1
{
    public class BoDemNguoc
    {
        // Tổng số giây đếm ngược (30 phút = 1800 giây)
        private int tongSoGiay;
        private const int GIA_TRI_MAC_DINH = 30 * 60;

        public BoDemNguoc(int soPhut = 30)
        {
            tongSoGiay = soPhut * 60;
        }

        public void DatLai()
        {
            tongSoGiay = GIA_TRI_MAC_DINH;
        }

        // Giảm 1 giây mỗi nhịp
        public bool GiamMotGiay()
        {
            if (tongSoGiay > 0)
            {
                tongSoGiay--;
                return true;
            }
            return false; // Hết giờ
        }

        public bool DaHetGio()
        {
            return tongSoGiay <= 0;
        }

        // Định dạng thành chuỗi mm:ss
        public string LayChuoiThoiGian()
        {
            int phut = tongSoGiay / 60;
            int giay = tongSoGiay % 60;
            return string.Format("{0:D2}:{1:D2}", phut, giay);
        }
    }
}