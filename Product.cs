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

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
		return "Name:" + name + "\n" + amount;
    }
}
