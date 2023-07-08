using System;
using System.Collections;

/// <summary>
/// This class represents Shop made using Singleton pattern.
/// </summary>
namespace ProApp
{
    public class Shop
    {
        public static int numberOfUniqueProducts;
        private static Shop instance;
        private ArrayList products;
        private Shop()
        {
            products = new ArrayList();
            numberOfUniqueProducts = 0;
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
            numberOfUniqueProducts++;
            ProductDAO.addProduct(numberOfUniqueProducts, product);
        }
        public bool isProductInTheStock(Product p) => products.Contains(p);
        public int indexOfTheProduct(Product product) => products.IndexOf(product);

        public bool removeFromTheStock(int id, Product product, float amount)
        {
            try
            {
                Console.WriteLine(Utility.tryingToRemoveTxt(product, amount));
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
                    ProductDAO.removeProduct(id, amount);
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

        public void removeAllFromTheStock(int id, Product product)
        {
            try
            {
                Console.WriteLine(Utility.tryingToRemoveTxt(product));
                if (isProductInTheStock(product))
                {
                    products.RemoveAt(indexOfTheProduct(product));
                    ProductDAO.deleteProductFromDB(id);
                }
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

            /*ArrayList rows = DBConnection.getData();

            foreach (String row in rows)
                Console.WriteLine(row);*/
        }
    }
}