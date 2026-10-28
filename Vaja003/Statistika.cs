using System;

namespace Vaja003
{
    public static class Statistika
    {
        public static double Povprecje(double[] meritve)
        {
            if (meritve == null || meritve.Length == 0)
            {
                return double.NaN;
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
            if (meritve == null || meritve.Length == 0)
            {
                return double.NaN;
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
                return 0;
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
