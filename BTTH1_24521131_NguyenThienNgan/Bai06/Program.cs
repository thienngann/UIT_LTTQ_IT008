using System.Numerics;
using System.Security.Cryptography;

namespace Bai06
{
    class MaTran
    {
        public int row { get; set; }
        public int column { get; set; }
        private List<List<int>> Matrix;
        public MaTran()
        {
            row = 0;
            column = 0;
            Matrix = new List<List<int>>();

        }
        public void Create()
        {
            do
            {
                Console.Write("Nhap so dong: ");
                row = int.Parse(Console.ReadLine());
            } while (row <= 0);

            do
            {
                Console.Write("Nhap so cot: ");
                column = int.Parse(Console.ReadLine());
            } while (column <= 0);

            Random rnd = new Random();
            Matrix = new List<List<int>>();
            for (int i = 0; i < row; i++)
            {
                Matrix.Add(new List<int>());
                for (int j = 0; j < column; j++)
                {
                    //int n = int.Parse(Console.ReadLine());
                     int n = rnd.Next(100);
                    Matrix[i].Add(n);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(Matrix[i][j] + " ");
                }
                Console.Write('\n');
            }
        }

        public int PhanTuLonNhat()
        {
            int maxx = Matrix[0][0];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (maxx < Matrix[i][j])
                        maxx = Matrix[i][j];
                }
            }
            return maxx;
        }

        public int PhanTuNhoNhat()
        {
            int minn = Matrix[0][0];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (minn > Matrix[i][j])
                        minn = Matrix[i][j];
                }
            }
            return minn;
        }

        public int DongCoTongLonNhat()
        {
            int index = -1;
            double maxx = int.MinValue, sum = 0;
            for (int i = 0; i < row; i++)
            {
                sum = 0;
                for (int k = 0; k < column; k++)
                {
                    sum += Matrix[i][k];
                }
                if (sum > maxx)
                {
                    index = i;
                    maxx = sum;
                }

            }
            return index;
        }

        public bool IsSoNuyento(int x)
        {
            if (x < 2) return false;
            if (x == 2 || x == 3) return true;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }
        public double TongSoKhongNto()
        {
            double sum = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (IsSoNuyento(Matrix[i][j]) == false)
                        sum += Matrix[i][j];
                }
            }
            return sum;
        }

        public void XoaDong(int k)
        {
            if (k >= row)
            {
                Console.WriteLine($"Khong ton tai dong thu {k}");
                return;
            }
            Matrix.Remove(Matrix[k]);
            row--;
            Print();
        }

        public void XoaCotPhanTuLonNhat()
        {
            int maxx = PhanTuLonNhat();
            SortedSet<int> index = new SortedSet<int>();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (Matrix[i][j] == maxx)
                    {
                        index.Add(j);
                    }
                }
            }
            for (int k = index.Count - 1; k >= 0; k--)
            {
                for (int i = 0; i < row; i++)
                {
                    Matrix[i].RemoveAt(index.ElementAt(k));
                }
                column--;
            }
            Print();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MaTran matran = new MaTran();
            matran.Create();
            matran.Print();
            Console.WriteLine($"Phan tu lon nhat: {matran.PhanTuLonNhat()}");
            Console.WriteLine($"Phan tu nho nhat: {matran.PhanTuNhoNhat()}");
            Console.WriteLine($"Dong co tong lon nhat: {matran.DongCoTongLonNhat()}");
            Console.WriteLine($"Tong cac so khong phai la so nguyen to: {matran.TongSoKhongNto()}");
            Console.WriteLine("Xoa dong thu k");
            Console.Write("Nhap k = ");
            int k = int.Parse(Console.ReadLine());
            matran.XoaDong(k);
            Console.WriteLine("Xoa cot chua phan tu lon nhat");
            matran.XoaCotPhanTuLonNhat();

        }
    }
}


