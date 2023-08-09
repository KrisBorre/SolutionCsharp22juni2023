using SOLIDOppervlakteBerekenaar9Aug2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij SOLID Oppervlakte Berekenaar");
        Console.WriteLine("Single Responsibility Principle");

        Shape shape1 = new Circle(1);
        Shape shape2 = new Square(2);
        Shape shape3 = new Rectangle(1, 2);
        Shapes shapes = new Shapes();
        shapes.VoegToe(shape1);
        shapes.VoegToe(shape2);
        shapes.VoegToe(shape3);
        Console.WriteLine("De output is ");
        Console.WriteLine(new OutputShapes(shapes).HtmlFormat());

        Console.WriteLine();

        Console.WriteLine(new OutputShapes(null).HtmlFormat());
        shapes.VoegToe(null);
        Console.WriteLine(new OutputShapes(shapes).HtmlFormat());


        Console.ReadLine();

    }
}