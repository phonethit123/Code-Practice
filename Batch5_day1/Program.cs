
using Batch5_day1;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

class program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("1:Insert \t 2:Select \t 3:Update 4:Delete");
        int ch = int.Parse(Console.ReadLine());

        switch(ch)
        {
            case 1:
                AdoDotNetExample ad1 = new AdoDotNetExample();
                ad1.Create();
            break;
            case 2:
                AdoDotNetExample ad2 = new AdoDotNetExample();
                ad2.Read();
            break;
            case 3:
                AdoDotNetExample ad3 = new AdoDotNetExample();
                ad3.Update();
            break;
            case 4:
                AdoDotNetExample ad4 = new AdoDotNetExample();
                ad4.Delete();
            break;
        }

    }
}

