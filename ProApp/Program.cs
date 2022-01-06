using System;

namespace ProApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = Shop.getInstance();
            Product product = new Product();
            Product tomatoes = new Product("Tomatoes", 50.0f);
            Console.WriteLine("It just works.");
            shop.addToStock(product);
            shop.addToStock(tomatoes);
            shop.showStock();
        }
    }
}
