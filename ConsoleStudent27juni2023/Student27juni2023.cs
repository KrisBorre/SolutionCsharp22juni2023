namespace ConsoleStudent27juni2023
{
    public enum Klassen { EA2, EB3, FC4, GD5 }

    public class Student27juni2023
    {
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public Klassen Klas { get; set; }
        public int PuntenCommunicatie { get; set; }
        public int PuntenProgrammingPrinciples { get; set; }
        public int PuntenWebTechnologie { get; set; }

        private double BerekenTotaalCijfer()
        {
            double result = PuntenCommunicatie + PuntenProgrammingPrinciples + PuntenWebTechnologie;
            return result / 3;
        }

        public void GeefOverzicht()
        {
            Console.WriteLine($"{Naam}, {Leeftijd} jaar");
            Console.WriteLine($"Klas: {Klas}");
            Console.WriteLine();
            Console.WriteLine("Cijferrapport:");
            Console.WriteLine("*************");
            Console.WriteLine($"Communicatie:           {PuntenCommunicatie}");
            Console.WriteLine($"Programming Principles: {PuntenProgrammingPrinciples}");
            Console.WriteLine($"Web Technology:         {PuntenWebTechnologie}");
            Console.WriteLine($"Gemiddelde:             {BerekenTotaalCijfer():F1}");
            // index[,alignment][:formatString]
        }

        public static Student27juni2023 ZoekStudent(Student27juni2023[] array, string naam)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Naam == naam)
                    return array[i];
            }

            return null;
        }
    }
}
