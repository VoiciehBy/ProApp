using System;
using System.Collections.Generic;
using System.Text;

namespace ProApp
{
    public class ShopClient
    {
        private string name;
        private string surname;
        private string id;
        public ShopClient()
        {
            name = "None";
            surname = "None";
            id = "-1";
        }
        public ShopClient(string name = "None", string surname = "None", string id = "-1")
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
        }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Id { get => id; set => id = value; }
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
            return base.ToString();
        }
    }
}
