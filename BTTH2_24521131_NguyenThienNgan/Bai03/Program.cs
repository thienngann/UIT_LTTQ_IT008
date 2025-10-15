using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Numerics;

namespace Bai03
{
    internal class Program
    {
        class MaTran
        {
            public int row { get; set; }
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
                    Console.Write("Nhập số hàng: ");
                    row = int.Parse(Console.ReadLine());
                } while (row <= 0);

                do
                {
                    Console.Write("Nhập số cột: ");
                    col = int.Parse(Console.ReadLine());
                } while (col <= 0);

                Matrix = new List<List<int>>();
                Console.WriteLine("Nhập phần tử ma trận");
                for (int i = 0; i < row; i++)
                {
                    Matrix.Add(new List<int>());
                    for (int j = 0; j < col; j++)
                    {
                        int res = int.Parse(Console.ReadLine());
                        Matrix[i].Add(res);
                    }
                }
            }
            public void Print()
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        Console.Write($"{Matrix[i][j]} ");
                    }
                    Console.Write("\n");
                }
            }
            public int Search(int n)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        if (Matrix[i][j] == n)
                        {
                            Console.WriteLine($"Giá trị {n} nằm ở dòng {i + 1} cột {j + 1}");
                            return 1;
                        }
                    }
                }
                return 0;
            }
            public bool IsSoNguyenTo(int n)
            {
                if (n < 2) return false;
                if (n == 2 || n == 3) return true;
                //  Console.WriteLine(Math.Sqrt(n));
                for (int i = 2; i <= Math.Sqrt(n); i++)
                    if (n % i == 0)
                        return false;
                return true;
            }
            public void XuatSoNguyenTo()
            {
                for (int i = 0; i < row; i++)
                {
                    for (int k = 0; k < col; k++)
                        if (IsSoNguyenTo(Matrix[i][k]))
                            Console.Write(Matrix[i][k] + " ");
                }
            }
            public SortedSet<int> DongCoSoNguyenToNhieuNhat()
            {
                SortedSet<int> index = new SortedSet<int>();
                SortedDictionary<int, int> result = new SortedDictionary<int, int>();
                for (int i = 0; i < row; i++)
                {
                    int dem = 0;
                    for (int j = 0; j < col; j++)
                    {
                        if (IsSoNguyenTo(Matrix[i][j]))
                        {
                            dem++;
                        }
                    }
                    result[i] = dem;
                }
                if (result.Values.Max() == 0) return index;
                
                int maxx = result.Values.Max();
                foreach (var ans in result)
                {
                    if (ans.Value == maxx)
                        index.Add(ans.Key);
                }
                return index;
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MaTran matrix = new MaTran();         
            matrix.Create();
            Console.WriteLine("Xuất ma trận");
            matrix.Print();

            Console.Write("Nhập phần tử cần tìm: ");
            int res = int.Parse(Console.ReadLine());
            if (matrix.Search(res) == 0)
                Console.WriteLine("Không tồn tại phần tử trong ma trận");

            Console.Write("Các phần tử là số nguyên tố: ");
            matrix.XuatSoNguyenTo();

            Console.Write("\nDòng có nhiều số nguyên tố nhất: ");
            if (matrix.DongCoSoNguyenToNhieuNhat().Count() > 0)
                foreach (var s in matrix.DongCoSoNguyenToNhieuNhat())
                    Console.Write($"{ s + 1} ");
            else Console.WriteLine("Không dòng nào chứa số nguyên tố");
        }
    }
}
