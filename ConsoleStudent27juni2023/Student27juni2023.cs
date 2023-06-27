namespace ConsoleStudent27juni2023
{
    internal enum Klassen { EA2, EB3, FC4, GD5 }

    internal class Student27juni2023
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
    }
}
