using System.Numerics;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CQuanLy qly = new CQuanLy();
            qly.Nhap();
            Console.WriteLine("\nDanh sach thong tin: ");
            qly.Xuat();
            Console.WriteLine($"\nTong gia ban: {qly.TongGia()}");
            Console.WriteLine("\nDanh sach cac khu dat co dien tich >1000m2 hoac nha pho co dien tich > 60m2 va nam xay dung >= 2019");
            qly.XuatDSTheoThongTin();

            Console.WriteLine("\nNhap thong tin can tim kiem: ");
            string diachi = "";
            float gia = float.MaxValue;
            float dientich = 0;

            Console.Write("Dia chi: ");
            string input_dc  = Console.ReadLine();
            if (!string.IsNullOrEmpty(input_dc))
            {
                diachi = input_dc;
            }

            Console.Write("Gia ban: ");
            string input_gia = Console.ReadLine();
            if (!string.IsNullOrEmpty(input_gia))
            {
                gia = float.Parse(input_gia);
            }
                        
            Console.Write("Dien tich: ");
            string input_dt = Console.ReadLine();
            if (!string.IsNullOrEmpty(input_dt))
            {
                dientich = float.Parse(input_dt);
            }
            Console.WriteLine("\nDanh sach dat phu hop voi yeu cau: ");
            qly.TimKiem(diachi, gia, dientich).Xuat();         
        }
    }
}
