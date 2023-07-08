using System;
using System.Collections;

namespace ProApp
{
    public class ShopClient
    {
        private string id;
        private string name;
        private string surname;
        private float balance;

        private ArrayList shoppingHistory;
        public ShopClient()
        {
            name = "None";
            surname = "None";
            id = "-1";
            balance = 0.0f;
            shoppingHistory = new ArrayList();
        }
        public ShopClient(string id = "-1", string name = "None", string surname = "None", float balance = 0.0f)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.balance = balance;
            shoppingHistory = new ArrayList();
        }
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public float Balance { get => balance; set => balance = value; }

        public void buy(int id, Product product, float amount)
        {
            Shop shop = Shop.getInstance();
            if (shop.removeFromTheStock(id, product, amount))
            {
                Product p = new Product(product.Name, amount, true, "kg", product.BasePrice);
                shoppingHistory.Add(p);
                this.balance -= (product.BasePrice * amount);
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

        public bool isInDebt() => (balance < 0);
        public float moneyToPay() => -1 * balance;
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }
}
