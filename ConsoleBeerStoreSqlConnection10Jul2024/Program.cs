using System.Data.SQLite;

namespace ConsoleBeerStoreSqlConnection10Jul2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Beerstore SqlConnection!");

            string connectionString = $"Data Source=../../../../beerstore9jul2024.db";

            string query = "SELECT * FROM Customers";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();

                    int columnCount = reader.FieldCount;
                    Console.WriteLine("The number of columns: " + columnCount);

                    // Print column names as a header
                    for (int i = 0; i < columnCount; i++)
                    {
                        Console.Write(reader.GetName(i) + "\t"); // Tab separation between column names
                    }
                    Console.WriteLine(); // New line after header

                    // Read and print data from each row
                    while (reader.Read())
                    {
                        for (int i = 0; i < columnCount; i++)
                        {
                            // Get the data type of the current column
                            var dataType = reader.GetFieldType(i);

                            switch (dataType)
                            {
                                case Type t when t == typeof(string):
                                    Console.Write(reader.GetString(i) + "\t");
                                    break;
                                case Type t when t == typeof(int):
                                    Console.Write(reader.GetInt32(i) + "\t");
                                    break;
                                case Type t when t == typeof(double):
                                    // Access double value and consider formatting if needed
                                    double value1 = reader.GetDouble(i);
                                    Console.Write(value1.ToString("F") + "\t"); // Format as fixed-point with one decimal place
                                    break;
                                case Type t when t == typeof(bool):
                                    // Access boolean value
                                    bool value2 = reader.GetBoolean(i);
                                    Console.Write(value2.ToString() + "\t"); // Print "true" or "false"
                                    break;
                                case Type t when t == typeof(DateTime):
                                    // Access DateTime value and consider formatting if needed
                                    DateTime value3 = reader.GetDateTime(i);
                                    Console.Write(value3.ToString("yyyy-MM-dd HH:mm:ss") + "\t"); // Format as YYYY-MM-DD HH:MM:SS
                                    break;
                                default:
                                    Console.Write(reader.GetValue(i) + "\t"); // Handle unknown types generically
                                    break;
                            }
                        }
                        Console.WriteLine(); // New line after each row
                    }

                    reader.Close();
                }
            }


            Console.WriteLine("End of program. Press enter.");
            Console.Read();
        }
    }
}
