using System;
using System.Collections;

/// <summary>
/// This class represents Shop made using Singleton pattern.
/// </summary>
namespace ProApp
{
    public class Shop
    {
        private static Shop instance;
        private ArrayList products;
        private Shop()
        {
            products = new ArrayList();
        }
        public static Shop getInstance()
        {
            if (instance == null)
                instance = new Shop();
            return instance;
        }
        public void addToStock(Product product)
        {
            products.Add(product);
        }
        public bool isProductInTheStock(Product p) => products.Contains(p);
        public int indexOfTheProduct(Product product) => products.IndexOf(product);

        public bool removeFromTheStock(Product product, float amount)
        {
            try
            {
                Console.WriteLine(Utility.tryingToRemoveTxt(product,amount));
                if (isProductInTheStock(product))
                {
                    if (amount == product.Amount)
                        products.RemoveAt(indexOfTheProduct(product));
                    else if (amount > product.Amount)
                    {
                        string msg = Utility.notEnoughtProductTxt(product);
                        throw new NoProductException(msg);
                    }
                    else
                        product.Amount -= amount;
                    Console.WriteLine(Constants.SUCCESS);
                    return true;
                }
                else
                {
                    string msg = Constants.FAILURE + "->" + Utility.noProductTxt(product);
                    throw new NoProductException(msg);
                }
            }
            catch (NoProductException nPE)
            {
                Console.WriteLine(nPE.Message);
                return false;
            }
        }

        public void removeAllFromTheStock(Product product)
        {
            try
            {
                Console.WriteLine(Utility.tryingToRemoveTxt(product));
                if (isProductInTheStock(product))
                    products.RemoveAt(indexOfTheProduct(product));
                else
                {
                    string msg = Utility.noProductTxt(product);
                    throw new NoProductException(msg);
                }
            }
            catch (NoProductException nPE)
            {
                Console.WriteLine(nPE.Message);
            }
        }
        public void showStock()
        {
            Console.WriteLine(Constants.STOCK + ':');
            foreach (Product product in products)
                Console.WriteLine(products.IndexOf(product).ToString() + ' ' + product);
            Console.WriteLine();
        }
    }
}