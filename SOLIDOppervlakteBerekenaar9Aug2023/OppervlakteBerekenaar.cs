namespace SOLIDOppervlakteBerekenaar9Aug2023
{
    internal class OppervlakteBerekenaar : IOppervlakte
    {
        private readonly Shapes shapes;

        public OppervlakteBerekenaar(Shapes shapes)
        {
            this.shapes = shapes;
        }

        public double Oppervlakte()
        {
            double total = 0;
            if (shapes != null)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape != null)
                    {
                        total += shape.Oppervlakte();
                    }
                }
            }
            return total;
        }

    }
}
