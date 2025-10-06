namespace Bai02
{
    internal class Program
    {
        static bool snt(int x)
        {
            if (x < 2) return false;
            if (x == 2 || x == 3) return true;
            for (int i = 2; i <= Math.Sqrt(x); i++)
                if (x % i == 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Nhap n: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            int tong = 0;
            for (int i = 2; i < n; i++)
            {
                if (snt(i) == true)
                    tong += i;
            }
            Console.WriteLine($"Tong cac so nguyen to < n: {tong}");
        }
    }
}
