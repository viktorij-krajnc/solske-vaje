using System;

namespace Vaja003
{
    public static class Statistika
    {
        public static double Povprecje(double[] meritve)
        {
            if (meritve == null)
            {
                throw new ArgumentNullException(nameof(meritve));
            }
            if (meritve.Length == 0)
            {
                throw new ArgumentException("Prazna tabela nima povprečja.", nameof(meritve));
            }

            double vsota = 0;
            for (int i = 0; i < meritve.Length; i++)
            {
                vsota += meritve[i];
            }
            return vsota / meritve.Length;
        }

        public static double Najvecja(double[] meritve)
        {
            if (meritve == null)
            {
                throw new ArgumentNullException(nameof(meritve));
            }
            if (meritve.Length == 0)
            {
                throw new ArgumentException("Prazna tabela nima največje vrednosti.", nameof(meritve));
            }

            double najvecja = meritve[0];
            for (int i = 1; i < meritve.Length; i++)
            {
                if (meritve[i] > najvecja)
                {
                    najvecja = meritve[i];
                }
            }
            return najvecja;
        }

        public static int PrestejNad(double[] meritve, double meja)
        {
            if (meritve == null)
            {
                throw new ArgumentNullException(nameof(meritve));
            }

            int stevilo = 0;
            for (int i = 0; i < meritve.Length; i++)
            {
                if (meritve[i] > meja)
                {
                    stevilo++;
                }
            }
            return stevilo;
        }
    }
}
