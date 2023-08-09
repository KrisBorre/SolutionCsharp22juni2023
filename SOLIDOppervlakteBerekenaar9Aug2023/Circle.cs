namespace SOLIDOppervlakteBerekenaar9Aug2023
{
    internal class Circle : Shape
    {
        public int straal;

        public Circle(int s)
        {
            straal = s;
        }

        public override double Oppervlakte()
        {
            return straal * straal * Math.PI;
        }

        public double Omtrek()
        {
            return 2 * straal * Math.PI;
        }
    }
}
