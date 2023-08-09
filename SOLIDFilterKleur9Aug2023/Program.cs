using SOLIDFilterKleur9Aug2023;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welkom bij SOLID Filter");
        Console.WriteLine("Open Closed Principe: Open to extension; Closed to modification.");

        Product vis = new Product();
        vis.Naam = "Vis";
        vis.Grootte = 4;
        vis.Kleur = Kleuren.Geel;
        Product vlees = new Product();
        vlees.Naam = "Vlees";
        vlees.Grootte = 1;
        vlees.Kleur = Kleuren.Blauw;
        Product appel = new Product();
        appel.Naam = "Appel";
        appel.Grootte = 2;
        appel.Kleur = Kleuren.Groen;
        Product peer = new Product();
        peer.Naam = "Peer";
        peer.Grootte = 3;
        peer.Kleur = Kleuren.Geel;
        Product banaan = new Product();
        banaan.Naam = "Banaan";
        banaan.Grootte = 1;
        banaan.Kleur = Kleuren.Geel;
        Product strijkijzer = new Product();
        strijkijzer.Naam = "Strijkijzer";
        strijkijzer.Grootte = 1;
        strijkijzer.Kleur = Kleuren.Groen;

        Producten producten = new Producten() { vis, vlees, appel, peer, banaan, strijkijzer };
        Console.WriteLine("Alle Producten: ");
        Console.WriteLine(producten);

        FilterGrootte filterGrootte = new FilterGrootte(1);
        Console.WriteLine("Filteren op grootte 1: ");
        Console.WriteLine(filterGrootte.Filter(producten));
        Producten gefilterdeProducten1 = filterGrootte.Filter(producten);
        Console.WriteLine("De gefilterde producten: " + gefilterdeProducten1);

        FilterGrootteKleur filterGrootteKleur = new FilterGrootteKleur(1, Kleuren.Groen);
        Console.WriteLine("Filteren op grootte 1 en kleur groen: ");
        Console.WriteLine(filterGrootteKleur.Filter(producten));
        Producten gefilterdeProducten2 = filterGrootteKleur.Filter(producten);
        Console.WriteLine("De gefilterde producten: " + gefilterdeProducten2);

        FilterGrootteKleur filterKleurGrootte = new FilterGrootteKleur(2, Kleuren.Groen);
        Console.WriteLine("Filteren op de kleur groen en de grootte 2: ");
        Console.WriteLine(filterKleurGrootte.Filter(producten));
        Producten gefilterdeProducten3 = filterKleurGrootte.Filter(producten);
        Console.WriteLine("De gefilterde producten: " + gefilterdeProducten3);

        FilterKleur filterKleur = new FilterKleur(Kleuren.Geel);
        Console.WriteLine("Filteren op de kleur geel: ");
        Console.WriteLine(filterKleur.Filter(producten));
        Producten gefilterdeProducten4 = filterKleur.Filter(producten);
        Console.WriteLine("De gefilterde producten: " + gefilterdeProducten4);

        Console.ReadLine();
    }
}