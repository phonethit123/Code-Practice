using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class Program
    {
        static  void Main(string[] args)
        {

            //await ShowOutput();
            //await ShowOutput();
            //Task t1 =ShowOutput();
            //Task t2 =ShowOutput();
            //Task t3 =ShowOutput();

            //await Task.WhenAll(t1, t2, t3);
            //Console.WriteLine("End");
            Thread t1 = new Thread(()=>SayYes("abc"));
            t1.Start();
            for (int i = 0; i < 100; i++)
            {
                Console.Write("x");
            }
            Console.WriteLine();
        }
        static void SayYes(string s)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("y");
            }
        }
        public static async Task ShowOutput()
        {

            Console.WriteLine("Hello Async");
            await Task.Delay(2000);
            Console.WriteLine("Finish");
        }

    }
}
