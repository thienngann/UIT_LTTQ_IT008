using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class CQuanLy
    {
        public int sl {  get; set; }
        private List<CKhuDat> dat; 
        public CQuanLy()
        {
            sl = 0;
            dat = new List<CKhuDat>();
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong loai dat: ");
            sl = int.Parse(Console.ReadLine());
            int loai;
            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine($"Nhap thong tin loai dat thu {i + 1}: ");
                Console.Write("0. Khu dat, 1. Nha pho, 2. Chung cu: ");
                loai = int.Parse(Console.ReadLine());
                if (loai == 0)
                    dat.Add(new CKhuDat());
                else if (loai == 1)
                    dat.Add(new CNhaPho());
                else
                    dat.Add(new CChungCu());
                dat[i].Nhap();
            }
        }

        public void Xuat()
        {
            if (sl <= 0 )
            {
                Console.WriteLine("Khong ton tai dat");
                return;
            }
            for (int i = 0; i< sl; i++)
            {
                Console.WriteLine($"Thong tin dat thu {i + 1}:");
                dat[i].Xuat();
            }
        }

        public float TongGia()
        {
            float tong = 0;
            foreach(var item in dat)
            {
                tong += item.GiaBan;
            }
            return tong;
        }

        public void XuatDSTheoThongTin()
        {
            int i = 1;
            foreach(var item in dat)
            {
                if (item is CKhuDat && item.DienTich > 100)
                {
                    Console.WriteLine($"Nha thu {i}: ");
                    item.Xuat();
                    i++;
                }
                else if (item is CNhaPho nha && nha.DienTich > 60 && nha.NamXayDung >= 2019)
                {
                    Console.WriteLine($"Nha thu {i}: ");
                    item.Xuat();
                    i++;
                }

            }
        }

        public CQuanLy TimKiem(string diachi, float gia, float dientich)
        {
            CQuanLy result = new CQuanLy();
            foreach(var item in dat)
            {
                if (item.DiaDiem.Contains(diachi, StringComparison.OrdinalIgnoreCase) && item.GiaBan <= gia && item.DienTich >= dientich)
                {
                    result.sl++;
                    result.dat.Add(item);
                }
            }
            return result;
        }
    }
}
