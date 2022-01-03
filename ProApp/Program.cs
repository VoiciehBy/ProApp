using System;

namespace ProApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            Console.WriteLine("It just works.");
            Console.WriteLine(product);
            Console.WriteLine(Utility.randomDouble());
        }
    }
}
