# Naloga 5: iskanje in popravljanje napak

Vsak izsek je obravnavan ločeno. Izvorna napačna koda je namenoma samo v tem dokumentu, ne v izvedljivem projektu. Rezultati spodaj so preverjeni z .NET SDK 8.0.425 na Linuxu. Pri primerih 2 in 4 je bil za opazovanje dodan izpis rezultata; to ne spreminja izračuna.

## 1. Manjkajoči oklepaj

Izvorni izsek:
```csharp
int stevilo = 3;
if (stevilo > 0
{
    Console.WriteLine("Število je pozitivno.");
}
```

**Napoved:** program se ne prevede, ker pogoj ni zaključen z `)`.

**Dejansko preverjeno:** prevajanje ni uspelo; `error CS1026: ) expected`. Program se ne more zagnati.

**Popravek:**
```csharp
int stevilo = 3;
if (stevilo > 0)
{
    Console.WriteLine("Število je pozitivno.");
}
```
Popravljeni projekt izpiše `Število je pozitivno.`

## 2. Napačna vrsta deljenja

Izvorni izsek:
```csharp
int vsota = 5;
int stevilo = 2;
double rezultat = vsota / stevilo;
```

**Napoved:** v `rezultat` se shrani vrednost 2, ne 2,5. Prirejanje v `double` ne spremeni že opravljenega deljenja dveh `int`.

**Dejansko preverjeno:** z dodanim `Console.WriteLine(rezultat);` se izpiše `2`, program se konča brez napake.

**Popravek:**
```csharp
int vsota = 5;
int stevilo = 2;
double rezultat = (double)vsota / stevilo;
Console.WriteLine(rezultat);
```
Pretvorimo operand **pred deljenjem**. Popravljeni projekt izpiše `Pravilno deljenje: 2.5` v testnem okolju; v slovenskem okolju je lahko `2,5`. V skupni demonstracijski metodi je drugi `stevilo` preimenovan v `delitelj`, da ne podvojimo lokalnega imena iz prvega primera.

## 3. Napačna meja zanke

Izvorni izsek:
```csharp
int[] tocke = { 10, 20, 30 };
for (int i = 0; i <= tocke.Length; i++)
{
    Console.WriteLine(tocke[i]);
}
```

**Napoved:** izpiše 10, 20 in 30, nato poskusi prebrati neobstoječi element na indeksu 3.

**Dejansko preverjeno:** izpis `10`, `20`, `30`, nato `System.IndexOutOfRangeException`; program se konča z napako.

**Popravek:**
```csharp
int[] tocke = { 10, 20, 30 };
for (int i = 0; i < tocke.Length; i++)
{
    Console.WriteLine(tocke[i]);
}
```
Pri dolžini 3 obstajajo indeksi 0, 1 in 2. Zato uporabimo `<`, ne `<=`. Popravljeni projekt izpiše vse tri vrednosti brez izjeme.

## 4. Spreminjanje kopije namesto rezultata

Izvorni izsek:
```csharp
static void DodajTocko(int tocke)
{
    tocke++;
}

int rezultatIgre = 10;
DodajTocko(rezultatIgre);
Console.WriteLine(rezultatIgre);
```

**Napoved:** izpiše 10, ker metoda prejme kopijo vrednosti `int`.

**Dejansko preverjeno:** izpis `10`, zaključek brez napake. Povečana je samo lokalna kopija `tocke`.

**Popravek:**
```csharp
static int DodajTocko(int tocke)
{
    return tocke + 1;
}

int rezultatIgre = 10;
rezultatIgre = DodajTocko(rezultatIgre);
Console.WriteLine(rezultatIgre);
```
Metoda vrne novo vrednost, klicatelj jo shrani. Popravljeni projekt izpiše `Rezultat igre: 11`. Ne uporabljamo `ref` ali skupne spremenljivke. V projektu je metoda član razreda `Popravki`, klic pa v `Prikazi`; zgornja samostojna oblika je primerna tudi za datoteko z vrhnjimi stavki.
