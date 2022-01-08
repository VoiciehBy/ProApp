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
        public bool isProductOnTheStock(Product product)
        {
            return products.Contains(product);
        }
        public int indexOfTheProduct(Product product)
        {
            return products.IndexOf(product);
        }

        public void removeFromTheStock(Product product, float amount)
        {
            Console.WriteLine(Utility.initCap(Constants.TRYING_TO_REMOVE + amount + product.Unit + ' ' + product.Name + Constants.FROM_THE_STOCK + "..."));
            try
            {
                if (isProductOnTheStock(product))
                {                 
                    if (amount == product.Amount)
                        products.RemoveAt(indexOfTheProduct(product));
                    else if (amount > product.Amount)
                    {
                        string msg = Utility.notEnoughtProduct(product);
                        throw new NoProductException(msg);
                    }
                    else
                        product.Amount -= amount;
                    Console.WriteLine(Constants.SUCCESS);
                }
                else
                {
                    string msg = Utility.noProductTxt(product);
                    throw new NoProductException(msg);
                }
            }
            catch (NoProductException nPE)
            {
                Console.WriteLine(Constants.FAILURE + "\n" + nPE.Message);
            }
        }

        public void removeAllFromTheStock(Product product)
        {
            try
            {
                if (isProductOnTheStock(product))
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
            {
                Console.WriteLine(products.IndexOf(product).ToString() + ' ' + product);
            }
        }
    }
}