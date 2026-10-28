using System;

namespace Vaja003
{
    public static class Ugibanje
    {
        public static bool Zazeni()
        {
            int iskanoStevilo = new Random().Next(1, 101);
            return Igraj(iskanoStevilo);
        }

        public static bool Igraj(int iskanoStevilo)
        {
            if (iskanoStevilo < 1 || iskanoStevilo > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(iskanoStevilo), "Iskano število mora biti med 1 in 100.");
            }

            int veljavniPoskusi = 0;
            Console.WriteLine("Ugani število od 1 do 100. Imaš 7 veljavnih poskusov.");
            while (veljavniPoskusi < 7)
            {
                Console.Write("Poskus " + (veljavniPoskusi + 1) + ": ");
                string? vnos = Console.ReadLine();
                if (vnos == null)
                {
                    return false;
                }

                int ugib;
                if (!int.TryParse(vnos, out ugib))
                {
                    Console.WriteLine("Vnesi celo število.");
                    continue;
                }
                if (ugib < 1 || ugib > 100)
                {
                    Console.WriteLine("Vnesi število od 1 do 100.");
                    continue;
                }

                veljavniPoskusi++;
                if (ugib == iskanoStevilo)
                {
                    Console.WriteLine("pravilno");
                    return true;
                }
                if (ugib < iskanoStevilo)
                {
                    Console.WriteLine("premajhno");
                }
                else
                {
                    Console.WriteLine("preveliko");
                }
            }
            Console.WriteLine("Poraz. Iskano število je " + iskanoStevilo + ".");
            return true;
        }
    }
}
