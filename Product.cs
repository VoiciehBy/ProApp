using System;

/// <summary>
/// Class, that represents Product.
/// </summary>
public class Product
{
	string name;
	float amount;
	public string Name { get => name; set => name = value; }
	public float Amount { get => amount; set => amount = value; }
	public Product()
	{
		Name = "None";
		Amount = 0.0f;
	}
	public Product(string name,float amount)
	{
		Name = name;
		Amount = amount;
	}
}
