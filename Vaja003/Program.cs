using System;

namespace Vaja003
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n========== VAJA 003 ==========");
                Console.WriteLine("1 - Spremenljivke in pretvorba časa");
                Console.WriteLine("2 - Cena dostave");
                Console.WriteLine("3 - Obdelava meritev");
                Console.WriteLine("4 - Modul statistike");
                Console.WriteLine("5 - Poišči in popravi napake");
                Console.WriteLine("6 - Ugibanje števila");
                Console.WriteLine("0 - Izhod");
                Console.Write("Izbira: ");
                string? izbira = Console.ReadLine();
                if (izbira == null)
                {
                    return;
                }

                switch (izbira)
                {
                    case "0": return;
                    case "1": Naloga1(); break;
                    case "2": Naloga2(); break;
                    case "3": Naloga3(); break;
                    case "4": Naloga4(); break;
                    case "5": Naloga5(); break;
                    case "6":
                        if (!Naloga6())
                        {
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Neznana izbira. Vnesi število od 0 do 6.");
                        continue;
                }

                Console.Write("Pritisni Enter za meni: ");
                if (Console.ReadLine() == null)
                {
                    return;
                }
            }
        }

        public static void Naloga1()
        {
            Console.WriteLine("\n1. Spremenljivke in pretvorba časa");
            Console.WriteLine("Zahteva: prikaz kopiranja vrednosti, celoštevilskega in realnega deljenja ter pretvorbe sekund.");
            Console.WriteLine("Vhod: a = 10, b = a, a = a + 5; 7 / 2; 7 / 2.0; 7322 sekund.");
            int a = 10;
            int b = a;
            a = a + 5;
            Console.WriteLine("Izhod: a = " + a + ", b = " + b);
            Console.WriteLine("7 / 2 = " + (7 / 2));
            Console.WriteLine("7 / 2.0 = " + (7 / 2.0));
            Console.WriteLine("OblikujTrajanje(7322) = " + PretvorbaCasa.OblikujTrajanje(7322));
            Console.WriteLine("Razlog: b ohrani kopijo 10; celoštevilsko deljenje odreže decimalke, 7322 = 2 * 3600 + 2 * 60 + 2.");
        }

        public static void Naloga2()
        {
            Console.WriteLine("\n2. Dostava");
            Console.WriteLine("Zahteva: izračun cene dostave glede na maso in prednostno dostavo.");
            Console.WriteLine("Vhod: masaKg = 2m, prednostno = true.");
            Console.WriteLine("Izhod: " + Dostava.CenaDostave(2m, true) + " EUR");
            Console.WriteLine("Razlog: (0, 1] kg: 3 EUR; (1, 5] kg: 5 EUR; (5, 20] kg: 9 EUR; prednostno +2 EUR, zato 5 + 2 = 7.");
        }

        public static void Naloga3()
        {
            Console.WriteLine("\n3. Statistika");
            Console.WriteLine("Zahteva: izračun povprečja, največje vrednosti in števila meritev strogo nad mejo 20.");
            double[] meritve = { 18, 20, 19, 23, 20 };
            Console.WriteLine("Vhod: { 18, 20, 19, 23, 20 }, meja = 20.");
            Console.WriteLine("Izhod:");
            Console.WriteLine("Povprečje: " + Statistika.Povprecje(meritve));
            Console.WriteLine("Največja: " + Statistika.Najvecja(meritve));
            Console.WriteLine("Število nad 20: " + Statistika.PrestejNad(meritve, 20));
            Console.WriteLine("Razlog: povprečje je vsota 100 / 5; največja meritev je 23; samo 23 je strogo več kot 20.");
        }

        public static void Naloga4()
        {
            Console.WriteLine("\n4. Modul Statistika");
            Console.WriteLine("Zahteva: vhodni podatki in izpis so v Program.cs, izračuni pa v modulu Statistika.");
            Console.WriteLine("public omogoča dostop iz Program; static omogoča klic brez ustvarjanja objekta.");
            Console.WriteLine("Modul samo računa in vrača vrednosti, zato ne uporablja Console.");
            double[] meritve = { 18, 20, 19, 23, 20 };
            double meja = 20;
            Console.WriteLine("Vhod: { 18, 20, 19, 23, 20 }, meja = 20.");
            Console.WriteLine("Izhod Povprecje: " + Statistika.Povprecje(meritve));
            Console.WriteLine("Povprecje: vhod tabela; izhod povprečje (double); prazna tabela vrne NaN, ker rezultat ni določen.");
            Console.WriteLine("Izhod Najvecja: " + Statistika.Najvecja(meritve));
            Console.WriteLine("Najvecja: vhod tabela; izhod največja vrednost (double); prazna tabela vrne NaN, ker rezultat ni določen.");
            Console.WriteLine("Izhod PrestejNad: " + Statistika.PrestejNad(meritve, meja));
            Console.WriteLine("PrestejNad: vhod tabela in meja; izhod število vrednosti > meja (int); prazna tabela vrne 0.");
            Console.WriteLine("Razlog: iste metode ponovno uporabimo brez podvajanja izračunov. Pri null je obnašanje enako kot pri prazni tabeli.");
        }

        public static void Naloga5()
        {
            Console.WriteLine("\n5. Popravki");
            Console.WriteLine("Zahteva: popravljeni oklepaj, deljenje, meja zanke in uporaba vrnjene vrednosti.");
            Popravki.Prikazi();
        }

        public static bool Naloga6()
        {
            Console.WriteLine("\n6. Ugibanje");
            Console.WriteLine("Zahteva: ugibanje naključnega celega števila od 1 do 100 v največ sedmih veljavnih poskusih.");
            Console.WriteLine("Vhod: celo število od 1 do 100 v vsakem poskusu.");
            Console.WriteLine("Izhod: premajhno, preveliko, pravilno ali poraz z rešitvijo.");
            Console.WriteLine("Razlog: namig primerja ugib z rešitvijo; neveljaven vnos ne porabi poskusa.");
            return Ugibanje.Zazeni();
        }
    }
}
