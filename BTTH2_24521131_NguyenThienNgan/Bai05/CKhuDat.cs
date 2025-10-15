using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class CKhuDat
    {
        protected string DiaDiem { get; set; }
        protected float GiaBan {  get; set; }
        protected float DienTich {  get; set; }

        public virtual void Nhap()
        {
            while (true)
            {
                Console.Write("Nhap dia diem: ");
                DiaDiem = Console.ReadLine();
                if (DiaDiem == "")
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }

            while (true)
            {
                Console.Write("Nhap gia ban: ");
                GiaBan = float.Parse(Console.ReadLine());
                if (GiaBan < 0)
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }
            while (true)
            {
                Console.Write("Nhap dien tich: ");
                DienTich = float.Parse(Console.ReadLine());
                if (DienTich <= 0)
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }
        }
        public virtual void Xuat()
        {
            Console.WriteLine($"Dia diem: {DiaDiem}");
            Console.WriteLine($"Gia ban: {GiaBan}");
            Console.WriteLine($"Dien tich: {DienTich}");
        }
    }
}
