using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Numerics;

namespace Bai03
{
    internal class Program
    {
        class MaTran
        {
            public int row {  get; set; }
            public int col { get; set; }
            private List<List<int>> Matrix;
            public MaTran()
            {
                col = 0;
                row = 0;
                Matrix = new List<List<int>>();
            }

            public MaTran(int r, int c)
            {
                if (r <= 0 || c <= 0) return;
                row = r;
                col = c;
                Matrix = new List<List<int>>();
            }
            public void Create()
            {
                do
                {
                    Console.Write("Nhap so hang: ");
                    row = int.Parse(Console.ReadLine());
                }while (row <= 0);

                do
                {
                    Console.Write("Nhap so cot: ");
                    col = int.Parse(Console.ReadLine());
                } while (col <= 0);

                Matrix = new List<List<int>>();
                for (int i = 0; i<row; i++)
                {
                    Matrix.Add(new List<int>());
                    for (int j = 0; j< col; j++)
                    {
                        int res = int.Parse(Console.ReadLine());
                        Matrix[i].Add(res);
                    }
                }
            }

            public void Print()
            {
                for (int i = 0;i<row; i++)
                {
                    for (int j = 0;j< col; j++)
                    {
                        Console.Write($"{Matrix[i][j]} ") ;
                    }
                    Console.Write("\n");
                }
            }

            public int Search (int n)
            {
                for (int i = 0;i<row;i++)
                {
                    for (int j =0;j< col;j++)
                    {
                        if (Matrix[i][j] == n)
                        {
                            Console.WriteLine($"Gia tri {n} nam o dong {i+1} cot {j+1}");
                            return 1;
                        }
                    }
                }
                return 0;
            }

            public bool IsSoNguyenTo(int n)
            {
                if (n < 2) return false;
                if (n==2 || n==3)  return true;
              //  Console.WriteLine(Math.Sqrt(n));
                for (int i = 2; i <= Math.Sqrt(n); i++)
                    if (n%i == 0) 
                        return false;
                return true;
            }

            public void XuatSoNguyenTo()
            {
                for (int i =0;i<row;i++)
                {
                    for (int k = 0;k<col;k++)
                        if (IsSoNguyenTo(Matrix[i][k]))
                            Console.Write(Matrix[i][k] + " ");
                }    
            }
            public SortedSet<int> DongCoSoNguyenToNhieuNhat()
            {
                int maxx = int.MinValue;
                SortedSet<int> index = new SortedSet<int>();
                for (int i = 0;i<row;i++)
                {
                    int dem = 0;
                    for (int j = 0; j < col;j++)
                    {
                        if (IsSoNguyenTo(Matrix[i][j]))
                        {
                            
                            dem++;
                        }
                        if (dem > maxx)
                        {
                            maxx = dem;
                        }
                            
                    }
                }

                for (int i = 0;i<row; i++)
                {
                    int dem = 0;
                    for (int j = 0; j<col;j++)
                    {
                        if (IsSoNguyenTo(Matrix[i][j]))
                            dem++;
                    }
                    if (dem == maxx)
                        index.Add(i);
                }

                return index;
            }
        }

        static void Main(string[] args)
        {
            MaTran matrix = new MaTran();
            matrix.Create();
            Console.WriteLine("Xuat ma tran");
            matrix.Print();
            Console.Write("Nhap phan tu can tim: ");
            int res = int.Parse(Console.ReadLine());
           if( matrix.Search(res) == 0) 
                Console.WriteLine("Khong ton tai phan tu trong ma tran");
            Console.Write("Cac phan tu la so nguyen to: ");
            matrix.XuatSoNguyenTo();
            Console.Write("\nDong co nhieu so nguyen to nhat: ");
            foreach(var s in matrix.DongCoSoNguyenToNhieuNhat())
                Console.Write(s + " ");


        }
    }
}
