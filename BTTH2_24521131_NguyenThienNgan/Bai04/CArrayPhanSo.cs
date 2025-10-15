using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class CArrayPhanSo 
    {
        public int sl {  get; set; }
        private List<CPhanSo> arrPs;
        public CArrayPhanSo()
        {
            sl = 0;
            arrPs = new List<CPhanSo> { };
        }

        public void Nhap()
        {
           
            while (true)
            {
                Console.Write("Nhap so luong day phan so: ");
                sl = int.Parse(Console.ReadLine());
                if (sl > 0) break;
                else
                    Console.WriteLine("So luong khong hop le");
            }

            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine($"Nhap phan so thu {i + 1}");
                arrPs.Add(new CPhanSo());
                arrPs[i].Nhap();
            }
        }

        public void Xuat()
        {
            if (sl == 0) return;
            foreach(var item in arrPs)
            {
                item.Xuat();
            }
        }

        public CPhanSo PhanSoLonNhat()
        {
            CPhanSo maxx = arrPs[0];
            foreach(var p  in arrPs)
            {
                CPhanSo temp = p - maxx;
                if (temp.tu * temp.mau > 0)
                    maxx = p;
            }
            return maxx;
        }     

        public void SapXepTangDan()
        {
            for (int i = 1; i < arrPs.Count; i++)
            {
                CPhanSo curr = arrPs[i];
                int j;
                for (j = i-1; j >= 0; j--)
                {
                    CPhanSo temp = curr - arrPs[j];
                    if (temp.tu * temp.mau < 0)
                        arrPs[j + 1] = arrPs[j];
                    else break;
                }
                arrPs[j + 1] = curr;
            }
            Xuat();
        }
    }
}
