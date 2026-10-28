namespace DogodkiOprema;

public class KosOpreme
{
    public string Naziv { get; set; } = "";
    public bool NaVoljo { get; set; }
}

public static class Katalog
{
    // Podatki so za prikaz dogodkov samo v pomnilniku.
    private static readonly List<KosOpreme> oprema = new List<KosOpreme>()
    {
        new KosOpreme { Naziv = "Projektor Epson", NaVoljo = true },
        new KosOpreme { Naziv = "Prenosnik Lenovo", NaVoljo = false },
        new KosOpreme { Naziv = "Mikrofon Rode", NaVoljo = true },
        new KosOpreme { Naziv = "Projektor BenQ", NaVoljo = false }
    };

    // Metoda ne pozna gumbov ali besedilnih polj. Sprejme podatke in vrne rezultat.
    public static List<KosOpreme> Poisci(string iskano, bool samoNaVoljo)
    {
        string pojem = iskano.Trim();
        List<KosOpreme> rezultat = new List<KosOpreme>();

        foreach (KosOpreme kos in oprema)
        {
            bool ustrezaNaziv = kos.Naziv.Contains(pojem, StringComparison.OrdinalIgnoreCase);
            bool ustrezaStanje = !samoNaVoljo || kos.NaVoljo;
            if (ustrezaNaziv && ustrezaStanje)
            {
                rezultat.Add(kos);
            }
        }

        return rezultat;
    }
}
