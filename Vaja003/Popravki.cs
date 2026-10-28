using System;

namespace Vaja003
{
    public static class Popravki
    {
        public static void Prikazi()
        {
            Console.WriteLine("5.1 oklepaj");
            Console.WriteLine("Težava: manjka zaključni oklepaj pogoja. Popravek: if (stevilo > 0), da je pogoj pravilno zapisan.");
            Console.WriteLine("Vhod: stevilo = 3. Izhod:");
            int stevilo = 3;
            if (stevilo > 0)
            {
                Console.WriteLine("Število je pozitivno.");
            }

            Console.WriteLine("5.2 deljenje");
            Console.WriteLine("Težava: celoštevilsko deljenje izgubi decimalke. Popravek: pretvorba v double pred deljenjem.");
            Console.WriteLine("Vhod: 5 / 2. Izhod:");
            int vsota = 5;
            int delitelj = 2;
            double rezultat = (double)vsota / delitelj;
            Console.WriteLine("Pravilno deljenje: " + rezultat);

            Console.WriteLine("5.3 meja zanke");
            Console.WriteLine("Težava: indeks Length je zunaj tabele. Popravek: i < tocke.Length, saj se indeksi začnejo z 0.");
            Console.WriteLine("Vhod: { 10, 20, 30 }. Izhod:");
            int[] tocke = { 10, 20, 30 };
            for (int i = 0; i < tocke.Length; i++)
            {
                Console.WriteLine("Točke: " + tocke[i]);
            }

            Console.WriteLine("5.4 vrnjena vrednost");
            Console.WriteLine("Težava: prvotna void metoda poveča samo kopijo parametra. Popravek: metoda vrne novo vrednost, ki jo shranimo.");
            Console.WriteLine("Vhod: rezultatIgre = 10. Izhod:");
            int rezultatIgre = 10;
            rezultatIgre = DodajTocko(rezultatIgre);
            Console.WriteLine("Rezultat igre: " + rezultatIgre);
        }

        public static int DodajTocko(int tocke)
        {
            return tocke + 1;
        }
    }
}
