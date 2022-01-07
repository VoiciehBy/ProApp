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

	public void removeFromTheStock(Product product,float amount)
	{
		try
		{
			if (isProductOnTheStock(product))
            {
				if (amount == product.Amount)
					products.RemoveAt(indexOfTheProduct(product));
				else if (amount > product.Amount)
				{
					string msg = "There is no as much/many " + product.Name.ToLower() + " on the stock.";
					throw new NoProductException(msg);
				}
				else
					product.Amount -= amount;
			}		
			else
			{
				string msg = "There is no " + product.Name.ToLower() + " on the stock.";
				throw new NoProductException(msg);
			}
		}
		catch (NoProductException nPE)
		{
			Console.WriteLine(nPE.Message);
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
				string msg = "There is no " + product.Name.ToLower() + " on the stock.";
				throw new NoProductException(msg);
			}
		}
		catch(NoProductException nPE)
        {
			Console.WriteLine(nPE.Message);
        }
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
