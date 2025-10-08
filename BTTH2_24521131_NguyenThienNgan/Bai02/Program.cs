namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap duong dan thu muc:");
            string path = Console.ReadLine();
            if (path == null)
                return;
            if (Directory.Exists(path))
            {
                string[]files = Directory.GetFiles(path);
                if (files == null || files.Length == 0)
                    Console.WriteLine("Khong ton tai tap tin");
                else
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        Console.WriteLine($"{files[i]}");
                    }
                }

                string [] dirs = Directory.GetDirectories(path);
                if (dirs == null || dirs.Length == 0)
                { 
                    Console.WriteLine("Khong ton tai thu muc con");
                }
                else
                {
                    for (int i = 0;i<dirs.Length;i++)
                    {
                        string[] files_dirs = Directory.GetFiles (dirs[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay thu muc");
            }
        }
    }
}
