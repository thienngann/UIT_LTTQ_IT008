
namespace Bai01
{
    internal class Program
    {
        static bool LaSoNguyenTo(int x)
        {
            if (x < 2) return false;
            if (x == 2 || x == 3) return true;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }
        static bool LaSoChinhPhuong(int x)
        {
            for (int i = 0; i <= Math.Sqrt(x); i++)
                if (i * i == x)
                    return true;
            return false;
        }

        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Nhap n: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                //Console.Write($"Nhap phan tu thu {i + 1}: ");
                array[i] = rnd.Next(100);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n");
            int TongSoLe = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 != 0)
                    TongSoLe += array[i];
            }

            int SoNguyenTo = 0;
            for (int i = 0; i < n; i++)
            {
                if (LaSoNguyenTo(array[i]) == true)
                    SoNguyenTo++;
            }
            int SoChinhPhuongNhoNhat = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (LaSoChinhPhuong(array[i]))
                {
                    if (array[i] < SoChinhPhuongNhoNhat)
                        SoChinhPhuongNhoNhat = array[i];
                }
            }
            if (SoChinhPhuongNhoNhat == int.MaxValue)
                SoChinhPhuongNhoNhat = -1;
            Console.WriteLine($"Tong cac so le: {TongSoLe}");
            Console.WriteLine($"Đem so nguyen to trong mang: {SoNguyenTo}");
            Console.WriteLine($"So chinh phuong nho nhat trong mang: {SoChinhPhuongNhoNhat}");

        }
    }
}
