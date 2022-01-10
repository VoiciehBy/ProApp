using System;

namespace ProApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = Shop.getInstance();
            Product product = new Product();
            Product tomatoes = new Product("Tomatoes", 50.0f, true, "kg", 2000.02f);
            Product peas = new Product("Peas", 23.0f);
            Console.WriteLine("It just works.");
            shop.addToStock(product);
            shop.addToStock(tomatoes);
            shop.showStock();
            shop.removeFromTheStock(tomatoes, 25.0f);
            shop.showStock();
            shop.removeFromTheStock(tomatoes, 26.0f);
            shop.removeAllFromTheStock(peas);
            shop.showStock();
            ShopClient shopClient = new ShopClient();
            shopClient.buy(tomatoes, 1.0f);
            shopClient.showShoppingHistory();
            Console.WriteLine(Utility.isInDebtTxt(shopClient));
            Console.WriteLine(Utility.moneyToPayTxt(shopClient));
        }
    }
}
