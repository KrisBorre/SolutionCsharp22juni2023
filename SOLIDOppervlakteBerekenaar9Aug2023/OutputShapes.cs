namespace SOLIDOppervlakteBerekenaar9Aug2023
{
    internal class OutputShapes
    {
        private Shapes shapes;

        public OutputShapes(Shapes shapes)
        {
            this.shapes = shapes;
        }

        public string HtmlFormat()
        {
            OppervlakteBerekenaar calculatorShapes = new OppervlakteBerekenaar(shapes);
            return "<h1> Totale som = " + calculatorShapes.Oppervlakte() + " </h1> ";
        }

        public string TextFormat()
        {
            OppervlakteBerekenaar calculatorShapes = new OppervlakteBerekenaar(shapes);
            return "Totale som = " + calculatorShapes.Oppervlakte();
        }
    }
}
