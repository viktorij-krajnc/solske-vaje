using System;

namespace Vaja003
{
    public static class Dostava
    {
        public static decimal CenaDostave(decimal masaKg, bool prednostno)
        {
            if (masaKg <= 0m || masaKg > 20m)
            {
                throw new ArgumentOutOfRangeException(nameof(masaKg), "Masa mora biti večja od 0 in največ 20 kg.");
            }

            decimal cena;
            if (masaKg <= 1m)
            {
                cena = 3m;
            }
            else if (masaKg <= 5m)
            {
                cena = 5m;
            }
            else
            {
                cena = 9m;
            }

            if (prednostno)
            {
                cena += 2m;
            }
            return cena;
        }
    }
}
