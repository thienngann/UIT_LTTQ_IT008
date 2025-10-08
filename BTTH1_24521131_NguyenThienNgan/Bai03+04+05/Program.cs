using System;
using System.Security.Cryptography;
namespace Bai03_04_05
{
    class Date
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }

        public Date()
        {
            day = 1;
            month = 1;
            year = 1;

        }
        public Date(int d, int m, int y) : this()
        {
            day = d;
            month = m;
            year = y;
        }
        public void Nhap()
        {
            Console.Write("Nhap ngay: ");
            day = int.Parse(Console.ReadLine());
            Console.Write("Nhap thang: ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Nhap nam: ");
            year = int.Parse(Console.ReadLine());
        }

        public int XuatSoNgay()
        {
            /* Console.Write("Nhap thang: ");
             month = int.Parse(Console.ReadLine());
             Console.Write("Nhap nam: ");
             year = int.Parse(Console.ReadLine());*/

            if (month == 2)
            {
                if (KiemTraNamNhuan()) return 29;
                return 28;
            }
            switch (month)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
            }
            return 31;
        }
        public bool KiemTraNamNhuan()
        {
            if (year % 400 == 0) return true;
            if (year % 4 == 0 && year % 100 != 0) return true;
            return false;
        }
        public bool KiemTraNgayHopLe()
        {
            if (day < 1 || day > 31)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (year < 1)
                return false;
            if (day > 30)
            {
                switch (month)
                {
                    case 2:
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        return false;

                }
            }
            if (month == 2)
            {
                if (KiemTraNamNhuan() && day <= 29) return true;
                if (day <= 28) return true;
                return false;
            }
            return true;
        }

        public int TongSoNgay()
        {
            int[] ngaythang = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (KiemTraNamNhuan())
                ngaythang[1] = 29;
            int tong = 0;
            for (int i = 1; i < year; i++)
            {
                Date dt = new Date(day, month, i);
                tong += 365;
                if (dt.KiemTraNamNhuan()) tong++;
            }
            for (int i = 1; i < month; i++)
            {
                tong += ngaythang[i - 1];
            }
            tong += day;
            return tong;
        }

        public string ThuTrongTuan()
        {
            int n = TongSoNgay() % 7;
            if (n == 0) return ("Chu nhat");
            return ($"thu {n + 1}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Date date = new Date();
            date.Nhap();
            //cau 3: cho biết ngày tháng năm đó có hợp lệ không ?
            if (date.KiemTraNgayHopLe() == false)
                Console.WriteLine("Ngay thang nam khong hop le");
            else
            {
                Console.WriteLine("Ngay thang nam hop le");
                Console.WriteLine($"Thang {date.month} nam {date.year} co {date.XuatSoNgay()} ngay");
                Console.WriteLine($"Thu trong tuan: {date.ThuTrongTuan()}");
            }
        }
    }
}
