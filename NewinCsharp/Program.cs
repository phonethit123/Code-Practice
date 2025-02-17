using System.Net.Sockets;

namespace NewinCsharp
{
    class Program
    {
      static  void Main()
        {
            //var col = FromRainbow(Rainbow.Blue);
            //Console.WriteLine(col);

            var add = new Address { State = "YGN" };
            var res = ComputeCommercialTax(add,1000);
            Console.WriteLine(res);
        }
        public static string FromRainbow(Rainbow col) =>
            col switch
            { 
                Rainbow.Red=>"Red",
                Rainbow.Green=>"Green",
                Rainbow.Blue => "Blue",
                Rainbow.Orange => "Orange",
                Rainbow.Yellow => "Yellow",
                Rainbow.Violet => "Violet",
                Rainbow.Indigo => "Indigo",
                _ => "Invalid RainbowColor"
               
            };
        static double ComputeCommercialTax(Address loc, double amount) =>
            loc switch
            {
                { State: "YGN" } => amount * 0.1,
                { State: "MDY" } => amount * 0.09,
                { State: "MLM" } => amount * 0.8,
                _ => amount

            };
        class Address
        {
            public string State;
        }
        public enum Rainbow
        {
            Red,
            Green,
            Blue,
            Orange,
            Yellow,
            Violet,
            Indigo
        }

    }
}
