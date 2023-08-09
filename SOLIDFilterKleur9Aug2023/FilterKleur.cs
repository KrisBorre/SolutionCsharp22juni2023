namespace SOLIDFilterKleur9Aug2023
{
    internal class FilterKleur : IFilter
    {
        readonly Kleuren kleur;

        public FilterKleur(Kleuren kleur)
        {
            this.kleur = kleur;
        }

        public Producten Filter(Producten producten)
        {
            Producten result = new Producten();
            foreach (Product product in producten)
            {
                if (product.Kleur == kleur)
                    result.Add(product);
            }
            return result;
        }

    }
}
