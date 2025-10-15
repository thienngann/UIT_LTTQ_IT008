using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class CChungCu : CKhuDat
    {
        public int Tang {  get; set; }
        public override void Nhap()
        {
            base.Nhap();
            while (true)
            {
                Console.Write("Nhap tang: ");
                Tang = int.Parse(Console.ReadLine());
                if (Tang <= 0)
                    Console.WriteLine("Thong tin khong hop le");
                else break;
            }
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Tang: {Tang}");
        }
    }
}
