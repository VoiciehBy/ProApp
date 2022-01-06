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
	public void showStock()
    {
		Console.WriteLine("STOCK:");
		int i = 1;
		foreach(Product product in products)
        {
			Console.WriteLine(i.ToString() + " " + product);
			i++;
        }
    }
}
