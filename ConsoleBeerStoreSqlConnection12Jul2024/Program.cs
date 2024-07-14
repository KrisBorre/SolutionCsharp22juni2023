using System.Data.SQLite;

namespace ConsoleBeerStoreSqlConnection12Jul2024
{
    internal class Program
    {
        static string connectionString = $"Data Source=../../../../beerstore9jul2024.db";

        static void ExecuteQuery(string query)
        {
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

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Beerstore SQLite SQLiteConnection!");

            //string query1 = "SELECT * FROM Customers";
            //ExecuteQuery(query1);

            //string query2 = "SELECT Naam FROM Customers ORDER BY Naam;";
            //ExecuteQuery(query2);

            //string query3 = "SELECT Naam FROM Customers ORDER BY Naam DESC;";
            //ExecuteQuery(query3);

            //string query4 = "SELECT Naam, Land FROM Customers ORDER BY Land ASC;";
            //ExecuteQuery(query4);
            /*
            Naam    Land
            Jason Pugh      Australi?
            BSBP BVBA       Belgi?
            Hexagon Europe BVBA     Belgi?
            Intertracon     Belgi?
            Topace Europe   Belgi?
            Huang Trading bvba      Belgi?
            White Pony Pub  Belgi?
            Den Troetsel    Belgi?
            Den Arend       Belgi?
            */

            //string query5 = "SELECT DISTINCT Land FROM Customers;";
            //ExecuteQuery(query5);

            //string query6 = "SELECT * FROM Customers WHERE naam LIKE 'M%';";
            //ExecuteQuery(query6);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            20      100585  Multi Bier Asten BV     Nederland       Helmond Varenschut, 25
            23      101343  Multidrink S.R.L.(Multibirra)   Itali?
            43      101973  Made in Belgium Itali?  Lentate Sul Seveso
            */

            //string query7 = "SELECT * FROM customers WHERE naam LIKE '_e%';";
            //ExecuteQuery(query7);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            5       101992  WENZHOU WIN-WIN INTERNATIONAL TRADE CO., LTD    China   Wenzhou
            8       100017  Den-Belgiske-Olmand     Denemarken
            10      100039  Henk Smit       Nederland
            16      100220  Belgisk Bryg I/S        Denemarken
            */

            //string query8 = "SELECT * FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query8);
            /*
            Id      KlantID Naam    Land    Plaats  Adres
            1       100219  Bier en Co Amsterdam BV Nederland
            2       100452  B&S Global Food Purchase B.V.   Nederland       Dordrecht       Rijksstraatweg, 7
            4       101989  Prima Beer ApS  Denemarken      Hobro
            8       100017  Den-Belgiske-Olmand     Denemarken
            10      100039  Henk Smit       Nederland
            11      100041  Soren Claus Knudsen     Denemarken      Helsinge
            */

            //string query9 = "SELECT * FROM customers WHERE land IN ('denemarken', 'nederland');";
            //ExecuteQuery(query9);
            /*
            The number of columns: 6
            Id      KlantID Naam    Land    Plaats  Adres
            End of program. Press enter.
            */

            //string query10 = "SELECT COUNT(*) FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query10);
            /*
            The number of columns: 1
            COUNT(*)
            30
            */

            //string query11 = "SELECT COUNT(DISTINCT land) FROM customers WHERE land IN ('Denemarken', 'Nederland');";
            //ExecuteQuery(query11);
            /*
            COUNT(DISTINCT land)
            2
            */

            //string query12 = "SELECT COUNT(DISTINCT land) FROM customers;";
            //ExecuteQuery(query12);
            /*
            COUNT(DISTINCT land)
            27
            */

            //string query13 = "SELECT COUNT(DISTINCT land) FROM customers WHERE naam LIKE '___';";
            //ExecuteQuery(query13);
            /*
            COUNT(DISTINCT land)
            1
            */

            //string query14 = "SELECT * FROM customers WHERE naam LIKE '___';";
            //ExecuteQuery(query14);
            /*
            The number of columns: 6
            Id      KlantID Naam    Land    Plaats  Adres
            107     101624  HLS     Belgi?  Antwerpen
            */

            //string query15 = "SELECT land, count(*) FROM customers GROUP BY land;";
            //ExecuteQuery(query15);
            /*
            Land    count(*)
            Australi?       1
            Belgi?  15
            Bulgarije       2
            China   3
            Denemarken      7
            Duitsland       3
            Estland 1
            */

            //string query16 = "SELECT land, count(*) FROM customers GROUP BY land HAVING land LIKE '%e%e%';";
            //ExecuteQuery(query16);
            /*
            Land    count(*)
            Denemarken      7
            Griekenland     2
            Nederland       23
            Nieuw-Zeeland   1
            Roemeni?        1
            */

            //string query17 = "SELECT * FROM customers WHERE land != 'Nederland'";
            //ExecuteQuery(query17);

            //string query18 = "SELECT * FROM customers WHERE land <> 'Denemarken'";
            //ExecuteQuery(query18);

            string query19 = "SELECT * FROM articles";
            ExecuteQuery(query19);


            Console.WriteLine("End of program. Press enter.");
            Console.Read();
        }
    }
}
