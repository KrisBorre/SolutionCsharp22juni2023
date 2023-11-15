using ConsoleStudent27juni2023;

namespace ConsoleStudentOrganizer15nov2023
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Student Organizer
            {
                Console.WriteLine("Welkom bij Student Organizer!");

                List<Student27juni2023> lijst = new List<Student27juni2023>() {
                    new Student27juni2023(),
                    new Student27juni2023(),
                    new Student27juni2023(),
                    new Student27juni2023(),
                    new Student27juni2023()};
                string input = "";

                do
                {
                    Console.WriteLine("1 is invoeren; 2 is tonen. exit is stop. Geef keuze: ");
                    input = Console.ReadLine();
                    if (input != "stop" && input != "exit")
                    {
                        if (int.TryParse(input, out int result))
                        {
                            if (result == 1)
                            {
                                Console.WriteLine("Kies studentnummer: (1 t.e.m. 5)");
                                string input2 = Console.ReadLine();
                                if (int.TryParse(input2, out int result2))
                                {
                                    if (result2 >= 1 && result2 <= lijst.Count)
                                    {
                                        bool overschrijven = true;
                                        if (!string.IsNullOrEmpty(lijst[result2 - 1].Naam))
                                        {
                                            Console.WriteLine("Wenst u de oude gegevens te overschrijven: (ja of nee)");
                                            string input8 = Console.ReadLine();
                                            if (input8.ToLower() == "nee") overschrijven = false;
                                            else Console.WriteLine("Overschrijven ...");
                                        }

                                        if (overschrijven)
                                        {
                                            Console.WriteLine("Geef naam: ");
                                            lijst[result2 - 1].Naam = Console.ReadLine();
                                            Console.WriteLine("Geef leeftijd: ");
                                            string input3 = Console.ReadLine();
                                            if (int.TryParse(input3, out int result3))
                                            {
                                                lijst[result2 - 1].Leeftijd = result3;
                                            }
                                            Console.WriteLine("Geef klas: ");
                                            string input4 = Console.ReadLine();
                                            Klassen klas;
                                            if (Enum.TryParse(input4, out klas))
                                            {
                                                lijst[result2 - 1].Klas = klas;
                                            }
                                            Console.WriteLine("Geef punten van Communicatie: ");
                                            string input5 = Console.ReadLine();
                                            if (int.TryParse(input5, out int result5))
                                            {
                                                lijst[result2 - 1].PuntenCommunicatie = result5;
                                            }
                                            Console.WriteLine("Geef punten van Programming Principles: ");
                                            string input6 = Console.ReadLine();
                                            if (int.TryParse(input6, out int result6))
                                            {
                                                lijst[result2 - 1].PuntenProgrammingPrinciples = result6;
                                            }
                                            Console.WriteLine("Geef punten van Web Tech: ");
                                            string input7 = Console.ReadLine();
                                            if (int.TryParse(input7, out int result7))
                                            {
                                                lijst[result2 - 1].PuntenWebTechnologie = result7;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ongeldige keuze.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ongeldige keuze.");
                                }
                            }
                            else if (result == 2)
                            {
                                foreach (var item in lijst)
                                {
                                    if (!string.IsNullOrEmpty(item.Naam))
                                    {
                                        item.GeefOverzicht();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ongeldige keuze.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige keuze.");
                        }
                    }

                } while (input != "stop" && input != "exit");
            }
            #endregion
        }
    }
}