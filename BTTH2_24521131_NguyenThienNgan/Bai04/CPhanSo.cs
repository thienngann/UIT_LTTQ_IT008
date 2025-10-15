using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class CPhanSo
    {
        public double tu { get; set; }
        public double mau { get; set; }
        public CPhanSo()
        {
            tu = 0;
            mau = 1;
        }

        public CPhanSo(CPhanSo other)
        {
            this.tu = other.tu;
            this.mau = other.mau;
        }

        public void Nhap()
        {
            Console.Write("Nhap tu so: ");
            tu = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            while (true)
            {
                mau = int.Parse(Console.ReadLine());
                if (mau != 0) break;
                else
                {
                    Console.WriteLine("Mau so khong hop le");
                    Console.Write("Nhap lai mau so: ");
                }
            }
        }
        public void Xuat()
        {
           
            if (mau == 0)
            {
                Console.WriteLine("Mau so khong hop le");
                return;
            }
            RutGon();
            if (tu == 0)
                Console.WriteLine(0);
           else if (mau == 1)
                Console.WriteLine(tu);
           
            else if (mau == -1)
                Console.WriteLine(-tu);
            
            else
            {
              
                if (tu< 0 && mau < 0)
                {
                    tu = Math.Abs(tu);
                    mau = Math.Abs(mau);
                }
                Console.WriteLine($"{tu}/{mau}");
            }    
               
        }

        public double UCLN()
        {
            double a = Math.Abs(tu);
            double b = Math.Abs(mau);
            while (b != 0)
            {
                double r = a % b;
                a = b;
                b = r;
            }            
            return a;
        }
        public CPhanSo RutGon()
        {
            double ucln = UCLN();
            if (ucln!=0)
            {
                tu = tu / ucln;
                mau = mau / ucln;
            }               
            return this;
        }
        public static CPhanSo operator +(CPhanSo a, CPhanSo b)
        {
            CPhanSo res = new CPhanSo();
            res.tu = a.tu * b.mau + a.mau * b.tu;
            res.mau = a.mau * b.mau;
            return res;
        }
        public static CPhanSo operator -(CPhanSo a, CPhanSo b)
        {
            CPhanSo res = new CPhanSo();
            res.tu = a.tu * b.mau - a.mau * b.tu;
            res.mau = a.mau * b.mau;
            return res;
        }
        public static CPhanSo operator *(CPhanSo a, CPhanSo b)
        {
            CPhanSo res = new CPhanSo();
            res.tu = a.tu * b.tu;
            res.mau = a.mau * b.mau;
            return res;
        }

        public static CPhanSo operator /(CPhanSo a, CPhanSo b)
        {

            CPhanSo res = new CPhanSo();
            res.tu = a.tu * b.mau;
            res.mau = a.mau * b.tu;
            return res;
        }

        
    }
}
