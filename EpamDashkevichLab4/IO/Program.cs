using EpamDashkevichLab4.Models;
using EpamDashkevichLab4.IO;

using System;

namespace EpamDashkevichLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Date date;
                DateCli cli = new DateCli(out date);
                cli.ChangeDate(date);
                cli.ShowDate(date);
            }
            catch(Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
    }
}
