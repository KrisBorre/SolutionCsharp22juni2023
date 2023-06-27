using ConsumptiePrijsIndex27juni2023;
using System.Globalization;

internal class Program
{
    const string delimiter = "|";

    private static void Main(string[] args)
    {
        Console.SetWindowSize(180, 30);
        Console.WriteLine("Welkom bij Data.Gov.Be !");
        Console.WriteLine("Consumptieprijsindex en gezondheidsindex");
        Console.WriteLine("Consumptieprijsindex vanaf 1920 en gezondheidsindex vanaf 1994");
        Console.WriteLine("NM_YR   NM_MTH  MS_CPI_IDX                MS_WITHOUT_ENE_IDX                        MS_WITHOUT_PTRL_IDX                  MS_WT_CPI       MS_CPI_INFL      MS_HLTH_IDX          MS_SMOOTH_IDX                       NM_BASE_YR");
        Console.WriteLine("Jaar    Maand  Consumptieprijsindex       Index zonder energetische producten       Index zonder petroleum producten        Weging    Inflatie        Gezondheidsindex        Afgevlakte gezondheidsindex       Basisjaar  ");
        Console.WriteLine("Gezondheidsindex: " + "Het gezondheidsindexcijfer is afgeleid uit het indexcijfer van de consumptieprijzen en is gepubliceerd sinds januari 1994. De actuele waarde van dit indexcijfer wordt bekomen door een aantal producten uit de korf van het indexcijfer van de consumptieprijzen te weren, met name alcoholische dranken (in de winkelgekocht of in een café geconsumeerd), tabakswaren en motorbrandstoffen (met uitzondering van LPG).");
        // https://data.gov.be/en/node/27707
        // https://statbel.fgov.be/nl/themas/consumptieprijsindex/consumptieprijsindex
        // https://statbel.fgov.be/sites/default/files/files/metadata/T8.STAT_DTST_501.CTAC_ORG_1.DIFF_LVL_1.NL.pdf
        // https://statbel.fgov.be/nl/open-data/consumptieprijsindex-en-gezondheidsindex

        Console.WriteLine("Default Culture from the Windows user is {0}", CultureInfo.CurrentCulture.Name);

        //CultureInfo myCultureInfoInternational = new CultureInfo("en-US", false);
        //CultureInfo.CurrentCulture = myCultureInfoInternational;
        //Console.WriteLine("The current culture is now {0}", CultureInfo.CurrentCulture.Name);
        // Kris: Om een reden die ik nog niet weet kan ik de file niet lezen met instelling en-US.

        StreamReader streamReader = new StreamReader(@"..\..\..\CPI All base years.txt");

        string header = streamReader.ReadLine();
        string[] headerValues = header.Split(delimiter);

        foreach (string s in headerValues)
        {
            Console.Write(s + "\t");
        }
        Console.WriteLine();

        List<ConsumptieRecord27juni2023> lijst = new List<ConsumptieRecord27juni2023>();

        while (!streamReader.EndOfStream)
        {
            string line = streamReader.ReadLine();
            string[] values = line.Split(delimiter);

            if (values.Length != 10) Console.WriteLine("Vervelende record!");

            ConsumptieRecord27juni2023 record = new ConsumptieRecord27juni2023();
            int j = 0;
            record.StringJaar = values[j++];
            record.StringMaand = values[j++];
            record.StringConsumptieprijsindex = values[j++];
            record.Index_zonder_energetische_producten = values[j++];
            record.Index_zonder_petroleum_producten = values[j++];
            record.StringWeging = values[j++];
            record.Inflatie = values[j++];
            record.Gezondheidsindex = values[j++];
            record.Afgevlakte_gezondheidsindex = values[j++];
            record.StringBasisjaar = values[j++];

            lijst.Add(record);
        }

        streamReader.Close();
        streamReader.Dispose();

        string input = "";
        int keuze;

        do
        {
            Console.WriteLine("Kies het basisjaar: (1, .. 11)");
            for (int k = 0; k < 11; k++)
            {
                Console.WriteLine(k + 1 + ")    " + lijst[k].StringBasisjaar);
            }
            input = Console.ReadLine();

        } while (!int.TryParse(input, out keuze) || (keuze <= 0 || keuze >= 12));

        string strBasisjaar = lijst[keuze - 1].StringBasisjaar;

        int startJaar = 0;
        do
        {
            Console.WriteLine("Kies het start jaar:");
            input = Console.ReadLine();

        } while (!int.TryParse(input, out startJaar) || (startJaar < 1920 || startJaar > 2020));

        string dateTime = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");

        // jaar maand Consumptieprijsindex (alle data)
        using (StreamWriter streamWriter = new StreamWriter("consumptieprijsindex_" + dateTime + ".txt"))
        {
            foreach (ConsumptieRecord27juni2023 record in lijst)
            {
                if (record.StringBasisjaar == strBasisjaar && record.Jaar >= startJaar)
                {
                    streamWriter.WriteLine(record.Jaar + record.Maand / 12.0 + "\t" + record.Consumptieprijsindex);
                }
            }
        }

        // jaar maand Index_zonder_energetische_producten (vanaf 2006)
        using (StreamWriter streamWriter = new StreamWriter("index_zonder_energetische_producten_" + dateTime + ".txt"))
        {
            foreach (ConsumptieRecord27juni2023 record in lijst)
            {
                if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(2006, startJaar))
                {
                    streamWriter.WriteLine(record.Jaar + record.Maand / 12.0 + "\t" + record.Index_zonder_energetische_producten);
                }
            }
        }

        // jaar maand Index_zonder_petroleum_producten (vanaf 1997)
        using (StreamWriter streamWriter = new StreamWriter("index_zonder_petroleum_producten_" + dateTime + ".txt"))
        {
            foreach (ConsumptieRecord27juni2023 record in lijst)
            {
                if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(1997, startJaar))
                {
                    streamWriter.WriteLine(record.Jaar + record.Maand / 12.0 + "\t" + record.Index_zonder_petroleum_producten);
                }
            }
        }

        // jaar maand inflatie (alle data)
        using (StreamWriter streamWriter = new StreamWriter("inflatie_" + dateTime + ".txt"))
        {
            foreach (ConsumptieRecord27juni2023 record in lijst)
            {
                if (record.StringBasisjaar == strBasisjaar && record.Jaar >= startJaar)
                {
                    streamWriter.WriteLine(record.Jaar + record.Maand / 12.0 + "\t" + record.Inflatie);
                }
            }
        }

        // jaar maand gezondheidsindex (vanaf 1994)
        using (StreamWriter streamWriter = new StreamWriter("gezondheidsindex_" + dateTime + ".txt"))
        {
            foreach (ConsumptieRecord27juni2023 record in lijst)
            {
                if (record.StringBasisjaar == strBasisjaar && record.Jaar >= Math.Max(1994, startJaar))
                {
                    streamWriter.WriteLine(record.Jaar + record.Maand / 12.0 + "\t" + record.Gezondheidsindex);
                }
            }
        }
        Console.WriteLine("Er zijn files gegenereerd in de folder: ConsumptiePrijsIndex27juni2023\\bin\\Debug\\net6.0\\");
        Console.ReadLine();
    }
}