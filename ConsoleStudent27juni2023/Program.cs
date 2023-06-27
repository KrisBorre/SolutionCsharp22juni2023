using ConsoleStudent27juni2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij Studentklasse!");

        Student27juni2023 student1 = new Student27juni2023();
        student1.Klas = Klassen.EA2;
        student1.Leeftijd = 21;
        student1.Naam = "Joske Vermeulen";
        student1.PuntenCommunicatie = 12;
        student1.PuntenProgrammingPrinciples = 15;
        student1.PuntenWebTechnologie = 13;

        student1.GeefOverzicht();
        Console.ReadLine();
    }

    static Student27juni2023 ZoekStudent(Student27juni2023[] array, string naam)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].Naam == naam)
                return array[i];
        }

        return null;
    }

}