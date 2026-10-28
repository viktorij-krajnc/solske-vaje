namespace DogodkiOprema;

// Podatki, ki jih pošljemo ob uspešni pripravi osnutka.
public class OsnutekEventArgs : EventArgs
{
    public string Oprema { get; }
    public string Namen { get; }

    public OsnutekEventArgs(string oprema, string namen)
    {
        Oprema = oprema;
        Namen = namen;
    }
}
