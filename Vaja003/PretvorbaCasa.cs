using System;

namespace Vaja003
{
    public static class PretvorbaCasa
    {
        public static string OblikujTrajanje(int skupnoSekund)
        {
            if (skupnoSekund < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skupnoSekund), "Trajanje ne sme biti negativno.");
            }

            const int SekundNaMinuto = 60;
            const int SekundNaUro = 3600;
            int ure = skupnoSekund / SekundNaUro;
            int ostanek = skupnoSekund % SekundNaUro;
            int minute = ostanek / SekundNaMinuto;
            int sekunde = ostanek % SekundNaMinuto;
            return ure + " h " + minute + " min " + sekunde + " s";
        }
    }
}
