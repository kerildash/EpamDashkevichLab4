using EpamDashkevichLab4.Models;
using System;

namespace EpamDashkevichLab4.IO
{
    class DateCli
    {
        public DateCli(out Date date)
        {
            date = CreateDate();
        }

        public void ShowDate(Date date)
        {
            Console.WriteLine($"The date is: {date}\n");
        }

        public Date ChangeDate(Date date)
        {
            try
            {
                Console.WriteLine("Choose direction of shift.");
                Console.WriteLine("1. Forward.");
                Console.WriteLine("2. Backward.");
                int direction = int.Parse(Console.ReadLine());
                Console.WriteLine();

                bool isForward;
                switch (direction)
                {
                    case 1:
                        isForward = true;
                        break;
                    case 2:
                        isForward = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Incorrect output of shift direction");
                }

                Console.WriteLine("Enter number of days:");
                int days = int.Parse(Console.ReadLine());
                if (days < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect amount of days");
                }

                Console.WriteLine("Enter number of months");
                int months = int.Parse(Console.ReadLine());
                if (months < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect amount of months");
                }

                Console.WriteLine("Enter number of years:");
                int years = int.Parse(Console.ReadLine());
                if (years < 0)
                {
                    throw new ArgumentOutOfRangeException("Incorrect amount of years");
                }

                date.Shift(isForward, days, months, years);

                return date;
            }
            catch
            {
                throw;
            }
            
        }
        private Date CreateDate()
        {
            try
            {
                Console.WriteLine("Enter day of month:");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter month (its number):");
                int month = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter year:");
                int year = int.Parse(Console.ReadLine());

                Date date = new Date(day, month, year);
                ShowDate(date);
                return date;
            }
            catch
            {
                throw;
            }
        }
    }
}
