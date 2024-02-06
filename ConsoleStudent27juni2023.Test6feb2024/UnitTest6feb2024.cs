namespace ConsoleStudent27juni2023.Test6feb2024
{
    public class UnitTest6feb2024
    {
        [Fact]
        public void Test1()
        {
            Student27juni2023 student1 = new Student27juni2023();
            student1.Klas = Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTechnologie = 13;

            Assert.Equal(expected: "Joske Vermeulen", actual: student1.Naam);
        }

        [Fact]
        public void Test2()
        {
            Student27juni2023 student1 = new Student27juni2023();
            student1.Klas = Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTechnologie = 13;

            Assert.Equal(expected: 21, actual: student1.Leeftijd);
        }

        [Fact]
        public void Test3()
        {
            Student27juni2023 student1 = new Student27juni2023();
            student1.Klas = Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTechnologie = 13;

            Student27juni2023 student2 = Student27juni2023.ZoekStudent([student1], "Joske Vermeulen");

            Assert.Equal(expected: 12, actual: student2.PuntenCommunicatie);
        }

        [Fact]
        public void Test4()
        {
            Student27juni2023 student1 = new Student27juni2023();
            student1.Klas = Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTechnologie = 13;

            Student27juni2023 student2 = Student27juni2023.ZoekStudent([student1], "Elza");

            Assert.Null(student2);
        }

        [Fact]
        public void Test5()
        {
            Student27juni2023 student1 = new Student27juni2023();
            student1.Klas = Klassen.EA2;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTechnologie = 13;

            Student27juni2023 student2 = new Student27juni2023();
            student2.Klas = Klassen.FC4;
            student2.Leeftijd = 14;
            student2.Naam = "Elza";
            student2.PuntenCommunicatie = 15;
            student2.PuntenProgrammingPrinciples = 18;
            student2.PuntenWebTechnologie = 12;

            Student27juni2023 student3 = Student27juni2023.ZoekStudent([student1, student2], "Joske Vermeulen");

            Assert.Equal(expected: 15, actual: student3.PuntenProgrammingPrinciples);
        }
    }
}