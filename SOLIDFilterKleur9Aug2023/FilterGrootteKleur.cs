namespace SOLIDFilterKleur9Aug2023
{
    internal class FilterGrootteKleur : IFilter
    {
        readonly Kleuren kleur;
        readonly int grootte;

        public FilterGrootteKleur(int grootte, Kleuren kleur)
        {
            this.kleur = kleur;
            this.grootte = grootte;
        }

        public Producten Filter(Producten producten)
        {
            Producten result = new Producten();
            foreach (Product product in producten)
            {
                if (product.Grootte == grootte && product.Kleur == kleur)
                    result.Add(product);
            }
            return result;
        }
    }
}
