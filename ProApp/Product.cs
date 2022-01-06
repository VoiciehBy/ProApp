using System;

/// <summary>
/// Class, that represents Product.
/// </summary>
public class Product
{
	string name;
	float amount;
	string unit;
	public string Name { get => name; set => name = value; }
	public float Amount { get => amount; set => amount = value; }
	public string Unit { get => unit; set => unit = value; }
	public Product()
	{
		name = "None";
		amount = 0.0f;
		unit = "kg";
	}
	public Product(string name = "None",float amount = 0.0f,string unit = "kg")
	{
		this.name = name;
		this.amount = amount;
		this.unit = unit;
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
		return name + " " + amount + unit;
    }
}
