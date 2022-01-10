using System;

/// <summary>
/// Set of utility methods inside static Utility class.
/// </summary>
namespace ProApp
{
    public static class Utility
    {
        public static double randomDouble()
        {
            Random random = new Random();
            return random.NextDouble();
        }
        public static string initCap(string str)
        {
            string firstCharacter = str.Substring(0, 1).ToUpper();
            string remaingCharacter = str.Substring(1, str.Length - 1);
            return firstCharacter + remaingCharacter.ToLower();
        }

        private static string thereIsOrThereAre(Product product)
        {
            string s = Constants.THERE;
            if (product.Countablilty && product.Amount > 1)
                s += Constants.ARE;
            else s += Constants.IS;
            return s;
        }

        public static string noProductTxt(Product product)
        {
            string s = thereIsOrThereAre(product);
            s += Constants.NO;
            string s1 = product.Name.ToLower();
            string s2 = Constants.IN_THE_STOCK + '.';
            return initCap(s + s1 + s2);
        }

        private static string manyOrMuch(Product product)
        {
            string s = "";
            if (product.Countablilty)
                s += Constants.MANY;
            else s += Constants.MUCH;
            return s;
        }

        public static string notEnoughtProduct(Product product)
        {
            string s = thereIsOrThereAre(product);
            s += Constants.NOT_SO;
            string s1 = manyOrMuch(product);
            s1 = s1 + (product.Name);
            s1 = s1.ToLower();
            string s2 = Constants.IN_THE_STOCK + '.';
            return initCap(s + s1 + s2);
        }

        public static string tryingToRemoveTxt(Product product)
        {
            string s = Constants.TRYING_TO_REMOVE + product.Amount + product.Unit + ' ';
            string s1 = product.Name + Constants.FROM_THE_STOCK + "...";
            return initCap(s + s1);
        }
        public static string tryingToRemoveTxt(Product product, float amount)
        {
            string s = Constants.TRYING_TO_REMOVE + amount + product.Unit + ' ';
            string s1 = product.Name + Constants.FROM_THE_STOCK + "...";
            return initCap(s + s1);
        }

        public static string isInDebtTxt(ShopClient sC)
        {
            string s = Constants.IS + sC.Id + ' ' + Constants.IN_DEBT + ':' + sC.isInDebt();
            return initCap(s);
        }
        public static string moneyToPayTxt(ShopClient sC)
        {
            string s = Constants.MONEY_TO_PAY_TXT + Constants.OF + sC.Id + ':' + sC.moneyToPay();
            return initCap(s);
        }
    }
}