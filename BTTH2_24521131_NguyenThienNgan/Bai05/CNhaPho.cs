using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class CNhaPho:CKhuDat
    {
        public int NamXayDung {  get; set; }
        public int SoTang {  get; set; }
        public override void Nhap()
        {
            base.Nhap();
            
            while (true)
            {
                Console.Write("Nhap nam xay dung: ");
                NamXayDung = int.Parse(Console.ReadLine());
                if (NamXayDung <= 0)
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }
             
            while (true)
            {
                Console.Write("Nhap so tang: ");
                SoTang = int.Parse(Console.ReadLine());
                if (SoTang <= 0)
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }
            
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Nam xay dung: {NamXayDung}");
            Console.WriteLine($"So tang: {SoTang}");
        }
    }
}
