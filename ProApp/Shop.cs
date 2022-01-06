using System;
using System.Collections;

/// <summary>
/// This class represents Shop made using Singleton pattern.
/// </summary>
public class Shop
{
	private static Shop instance;
	private ArrayList products;
	private Shop(){
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
	public void removeAllFromTheStock(Product product)
	{
		if (isProductOnTheStock(product)) products.RemoveAt(indexOfTheProduct(product));
		else Console.WriteLine("There is no " + product.Name + " on the stock.");
	}
	public void showStock()
    {
		Console.WriteLine("STOCK:");
		foreach(Product product in products)
        {
			Console.WriteLine(products.IndexOf(product).ToString() + " " + product);
        }
    }
}
