using System;
using System.Collections;

namespace ProApp
{
    public class ShopClient
    {
        private string id;
        private string name;
        private string surname;
        private float paidAmount;
        private float dueAmount;

        private ArrayList shoppingHistory;
        public ShopClient()
        {
            name = "None";
            surname = "None";
            id = "-1";
            shoppingHistory = new ArrayList();
        }
        public ShopClient(string name = "None", string surname = "None", string id = "-1", float paidAmount = 0.0f, float dueAmount = 0.0f)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.paidAmount = paidAmount;
            this.dueAmount = dueAmount;
            shoppingHistory = new ArrayList();
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public float PaidAmount { get => paidAmount; set => paidAmount = value; }
        public float DueAmount { get => dueAmount; set => dueAmount = value; }

        public void buy(int id, Product product, float amount)
        {
            Shop shop = Shop.getInstance();
            if (shop.removeFromTheStock(id, product, amount))
            {
                Product p = new Product(product.Name, amount, true, "kg", product.BasePrice);
                shoppingHistory.Add(p);
                dueAmount += (product.BasePrice * amount);
                string txt = Utility.clientBoughtTxt(this, product, amount);
                Console.WriteLine(txt);
            }
        }
        public void showShoppingHistory()
        {
            Console.WriteLine(Constants.SHOPING_HISTORY + Constants.OF + id + ':');
            foreach (Product product in shoppingHistory)
                Console.WriteLine(shoppingHistory.IndexOf(product).ToString() + ' ' + product);
            Console.WriteLine();
        }

        public bool isInDebt() => (dueAmount > paidAmount);
        public float moneyToPay() => dueAmount - paidAmount;
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }
}
