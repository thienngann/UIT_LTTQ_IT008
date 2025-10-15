namespace Bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month = 0, year = 0;
            do
            {
                Console.Write("Nhap thang: ");
                month = int.Parse(Console.ReadLine());
            } while (month < 1 || month > 12);

            do
            {
                Console.Write("Nhap nam: ");
                year = int.Parse(Console.ReadLine());
            } while (year < 1 || year > 9999);

            int MonthOfDate = DateTime.DaysInMonth(year, month); // so ngay
            DateTime datetime = new DateTime(year, month, 1);
            int day = (int)datetime.DayOfWeek; // thu

            Console.WriteLine($"Lich thang {month} nam {year}");
            Console.WriteLine("Sun  Mon  Tue  Wed  Thu  Fri  Sat");
            int date = 1;
            while (date<=MonthOfDate)
            {
                for (int i = 0;i<7; i++)
                {
                    if (date > MonthOfDate) break;
                    if (i < day)
                        Console.Write(new string(' ', 5));
                    else
                    {
                        if (date<10)
                            Console.Write("  "+date +"  ");
                        else
                            Console.Write(" "+date+"  ");
                        date++;
                        day = -1;
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
