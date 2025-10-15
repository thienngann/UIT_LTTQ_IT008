using System.Diagnostics.Contracts;
using System.Numerics;

namespace Bai04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CPhanSo a = new CPhanSo(), b = new CPhanSo();
            Console.WriteLine("Nhap phan so a: ");
            a.Nhap();
            Console.WriteLine("Nhap phan so b: ");
            b.Nhap();

            Console.Write("Phan so a: "); a.Xuat();
            Console.Write("Phan so b: "); b.Xuat();

            CPhanSo tong = (a + b);
            CPhanSo hieu = (a - b);
            CPhanSo tich = (a * b);
            CPhanSo thuong = (a / b);
            Console.Write("Tong 2 phan so: "); tong.Xuat();
            Console.Write("Hieu 2 phan so: "); hieu.Xuat();
            Console.Write("Tich 2 phan so: "); tich.Xuat();
            Console.Write("Thuong 2 phan so: "); thuong.Xuat();

            CArrayPhanSo arr = new CArrayPhanSo();
            arr.Nhap();
            Console.Write("Phan so lon nhat: ");
            arr.PhanSoLonNhat().Xuat();
            Console.WriteLine("Sap xep day phan so tang dan:");
            arr.SapXepTangDan();


        }
    }
}
