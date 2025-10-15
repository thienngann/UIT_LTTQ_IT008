namespace Bai02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tieng viet
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
           

            Console.Write("Nhap duong dan thu muc: ");
            string path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                string[]files = Directory.GetFiles(path);
                if (files == null || files.Length == 0)
                    Console.WriteLine("Khong ton tai tap tin");
                else
                {
                    foreach (var i in files)
                        Console.WriteLine(i);
                }

                string [] dirs = Directory.GetDirectories(path);
                if (dirs == null || dirs.Length == 0)
                { 
                    Console.WriteLine("Khong ton tai thu muc con");
                }
                else
                {
                    foreach (var i in dirs)
                        Console.WriteLine(i);
                   
                }
            }
            else
            {
                
                Console.WriteLine("Khong tim thay thu muc");
            }
        }
    }
}
