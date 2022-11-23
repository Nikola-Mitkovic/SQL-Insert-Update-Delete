using System;
using System.Data.SqlClient;

namespace SQL_Insert_Update_Delete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintGames();

            InsertProduct();

            UpdateProduct();

            DeleteProduct();

            Console.ReadLine();

        }
        public static void PrintGames()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;initial Catalog=Introduction_Database;User ID =sa;Password=1234";

            try
            {
                Console.WriteLine("Here are the video games in the catalogue: ");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                string sqlQuery = "SELECT * FROM Video_Games;";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int release = reader.GetInt32(2);
                    string genre = reader.GetString(3);
                    decimal score = reader.GetDecimal(4);

                    Console.WriteLine($"{id} | {name} | {release} | {genre} | {score}");
                }


                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void InsertProduct()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;initial Catalog=Introduction_Database;User ID =sa;Password=1234";

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                Console.WriteLine("Please type the name of the game you wish to catalogue: ");
                string qName = Console.ReadLine();
                Console.WriteLine($"Now enter the year {qName} was released: ");
                int qYear = int.Parse(Console.ReadLine());
                Console.WriteLine($"Please enter the genre of the game: ");
                string qGenre = Console.ReadLine();
                Console.WriteLine($"Finally enter the score the game received if you know it: ");
                decimal qMetascore = decimal.Parse(Console.ReadLine());

                string sqlQuery = $"INSERT INTO Video_Games (Name, Release_Date, Genre, Metascore) VALUES ('{qName}', {qYear}, '{qGenre}',{qMetascore});";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"Cataloguing completed, the number of rows changed: {result}");

                PrintGames();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void UpdateProduct()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;initial Catalog=Introduction_Database;User ID =sa;Password=1234";

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                Console.WriteLine("Please type the ID number of the game you wish to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Please type the name you wish to update to: ");
                string qName = Console.ReadLine();
                Console.WriteLine($"Now update the year {qName} was released: ");
                int qYear = int.Parse(Console.ReadLine());
                Console.WriteLine($"Please update the genre of the game: ");
                string qGenre = Console.ReadLine();
                Console.WriteLine($"Finally let's edit the score the game received if you know it: ");
                decimal qMetascore = decimal.Parse(Console.ReadLine());

                string sqlQuery = $"UPDATE Video_Games SET Name = '{qName}', Release_Date = {qYear}, Genre = '{qGenre}', Metascore = {qMetascore} WHERE ID = {id};";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"Update completed, the number of rows changed: {result}");

                PrintGames();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DeleteProduct()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;initial Catalog=Introduction_Database;User ID =sa;Password=1234";

            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                PrintGames();

                Console.WriteLine("Please type the ID number of the game you wish to DELETE: ");
                int id = int.Parse(Console.ReadLine());

                string sqlQuery = $"DELETE FROM Video_Games WHERE ID = {id};";

                SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"Deletion completed, the number of rows deleted: {result}");

                PrintGames();

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
