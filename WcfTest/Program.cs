using System;

namespace WcfTest
{
    static class Program
    {
        static void Main()
        {
            using (var proxy = new CalculatorProxy())
            {
                Console.WriteLine($"1 + 5 = {proxy.Add(1, 5)}");
                Console.WriteLine($"State = {proxy.State}");
            }
        }
    }
}