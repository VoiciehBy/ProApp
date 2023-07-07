using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace ProApp
{
    class ProductDAO
    {
        public static void addProduct(int id, string name, float amount, bool isCountable, string unit, float basePrice)
        {
            int b = isCountable ? 1 : 0;
            string insert = "INSERT INTO products VALUES("
                + id.ToString() + ','
                + "'" + name + "',"
                + amount.ToString().Replace(',', '.') + ','
                + b.ToString() + ','
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

        public static void deleteProduct(int id)
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
    }
}
