using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;

namespace ProApp
{
    class ProductDAO
    {
        public static void addProduct(int id, Product product)
        {
            string name = product.Name;
            float amount = product.Amount;
            int isCountable = product.Countablilty ? 1 : 0;
            string unit = product.Unit;
            float basePrice = product.BasePrice;
            string insert = "INSERT INTO products VALUES("
                + id.ToString() + ','
                + "'" + name + "',"
                + amount.ToString().Replace(',', '.') + ','
                + isCountable.ToString() + ','
                + "'" + unit + "',"
                + basePrice.ToString().Replace(',', '.')
                + ");";
            try
            {
                DBConnection.executeDML(insert);
                Debug.WriteLine(insert);
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public static void removeProduct(int id, float amount)
        {
            string remove = "UPDATE products SET "
                + "amount = " + amount.ToString().Replace(',', '.') + ' '
                + "WHERE id = " + id + ';';
            try
            {
                DBConnection.executeDML(remove);
                Debug.WriteLine(remove);
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public static void deleteProductFromDB(int id)
        {
            string delete = "DELETE FROM products "
                + "WHERE id = " + id + ';';
            try
            {
                DBConnection.executeDML(delete);
                Debug.WriteLine(delete);
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        private static void updateStringColumn(int id, String columnName, String value)
        {
            string remove = "UPDATE products SET "
                + "amount = " + columnName + " = '" + value + "'"
                + "WHERE id = " + id + ';';
            try
            {
                DBConnection.executeDML(remove);
                Debug.WriteLine(remove);
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        private static void updateNumberColumn(int id, String columnName, float value)
        {
            string remove = "UPDATE products SET "
                + columnName + " = " + value.ToString().Replace(',', '.')
                + "WHERE id = " + id + ';';
            try
            {
                DBConnection.executeDML(remove);
                Debug.WriteLine(remove);
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e.StackTrace);
            }
        }

        public static void updateName(int id, string name)
        {
            updateStringColumn(id, "name", name);
        }

        public static void updateAmount(int id, float amount)
        {
            updateNumberColumn(id, "amount", amount);
        }

        public static void updateCountability(int id, bool countability)
        {
            int isCountable = countability ? 1 : 0;
            updateNumberColumn(id, "amount", isCountable);
        }

        public static void updateUnit(int id, string unit)
        {
            updateStringColumn(id, "amount", unit);
        }

        public static void updateBasePrice(int id, float basePrice)
        {
            updateNumberColumn(id, "amount", basePrice);
        }
    }
}
