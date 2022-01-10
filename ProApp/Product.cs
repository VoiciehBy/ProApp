using System;

/// <summary>
/// Class, that represents Product.
/// </summary>
namespace ProApp
{
    public class Product
    {
        private string name;
        private float amount;
        private bool isCountable;
        private string unit;
        private float basePrice;
        public Product()
        {
            name = "None";
            amount = 0.0f;
            isCountable = true;
            unit = "kg";
        }
        public Product(string name = "None", float amount = 0.0f, bool isCountable = true, string unit = "kg",float basePrice = 0.0f)
        {
            this.name = name;
            this.amount = amount;
            this.isCountable = isCountable;
            this.unit = unit;
            this.basePrice = basePrice;
        }
        public string Name { get => name; set => name = value; }
        public float Amount { get => amount; set => amount = value; }
        public bool Countablilty { get => isCountable; set => isCountable = value; }
        public string Unit { get => unit; set => unit = value; }
        public float BasePrice { get => basePrice; set => basePrice = value; }

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => name + " " + amount + unit;
    }
}