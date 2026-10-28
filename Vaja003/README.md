# Vaja003 — konzolne naloge

**Ime in priimek:** Viktorij Krajnc
**Oddajna datoteka:** `Krajnc_Viktorij_Vaja003.zip`

## Zagon

V Visual Studiu s podporo za .NET 8 odpri `Vaja003.csproj` in zaženi projekt. Ali uporabi terminal:

```sh
dotnet run --project Vaja003.csproj
```

Ob zagonu se prikaže meni. Vpiši številko naloge in pritisni Enter. Program izvede samo izbrano nalogo. Po ogledu rezultatov pritisni Enter za vrnitev v meni. Z izbiro `0` program končaš. Izračuni uporabljajo jasno prikazane vzorčne podatke; v tej različici jih razen ugibov v igri ne vnašaš ročno.

## Kaj je zahtevalo šest podnalog?

| Izbira | Zahteva iz navodil | Kaj pokaže program |
| --- | --- | --- |
| 1 | Napoved izpisov spremenljivk in deljenja; funkcija za pretvorbo sekund s konstantami, deljenjem in ostankom. | Ločene rezultate primera in pretvorbo 7322 sekund. |
| 2 | Funkcija za ceno dostave po ceniku in doplačilo za prednostno dostavo. | Vhodno maso, izbiro dostave in izračunano ceno. |
| 3 | Tri funkcije za povprečje, maksimum in število meritev strogo nad mejo; zanke, brez LINQ in spreminjanja polja. | Vhodno polje in posebej označen rezultat vsake funkcije. |
| 4 | Funkcije iz tretje naloge prestaviti v `Statistika.cs`, narediti javne statične metode, pojasniti vhode/izhode in prazno polje. | Ponovno uporabo istega modula, iste rezultate ter pomen `public` in `static`. |
| 5 | Pri vsakem od štirih izsekov napovedati posledico, preveriti, razložiti vzrok in popraviti kodo. | Štiri ločeno označene popravke; izvorna koda in opažanja so tudi v `Napake.md`. |
| 6 | Igra ugibanja naključnega števila 1–100, največ sedem veljavnih poskusov, pravilno preverjanje vnosov. | Samostojno igro z navodili in povratnimi informacijami. |

Vseh šest nalog je v enem konzolnem projektu `Vaja003`, koda pa je razporejena po datotekah. Meni omogoča ločen prikaz posameznih nalog. Tretja in četrta izbira uporabljata iste metode: četrta naloga predstavlja ureditev kode v ponovno uporaben modul.

## Razporeditev kode

- `Program.cs`: meni, prikaz namena, priprava vhodnih podatkov in klici posameznih nalog.
- `PretvorbaCasa.cs`: izračun trajanja.
- `Dostava.cs`: izračun cene.
- `Statistika.cs`: tri statistične metode; brez konzolnega vnosa in izpisa ali skupnega spremenljivega stanja.
- `Popravki.cs`: štirje ločeno označeni popravljeni primeri.
- `Ugibanje.cs`: naključna izbira in izvajanje igre.

## Pomembni robni primeri

Negativno trajanje sproži `ArgumentOutOfRangeException`. Masa mora biti večja od 0 in največ 20 kg, sicer metoda sproži `ArgumentOutOfRangeException`. Ure trajanja lahko presegajo 24.

| Metoda | Vhod | Rezultat pri polju 18, 20, 19, 23, 20 | Prazno polje |
| --- | --- | --- | --- |
| `Povprecje` | `double[] meritve` | `double`: 20 | `double.NaN` – rezultat ni določen |
| `Najvecja` | `double[] meritve` | `double`: 23 | `double.NaN` – rezultat ni določen |
| `PrestejNad` | `double[] meritve`, `double meja` = 20 | `int`: 1 | 0 |

Pri `null` je obnašanje enako kot pri praznem polju. `double.NaN` pomeni »Not a Number«: za prazno polje povprečje in največja vrednost nista določena. Ničla pri teh dveh metodah ni ustrezna oznaka manjkajočega rezultata, ker je tudi veljaven izračunan rezultat. Za preverjanje se uporablja `double.IsNaN(rezultat)`, ne primerjava `rezultat == double.NaN`. Prikaz s podanimi meritvami izpiše 20, 23 in 1.

Metode obravnavajo običajna končna števila; vhodni `NaN` in neskončnosti niso posebej obravnavani. Metode za čas, dostavo in preverjanje testnega cilja igre uporabljajo izjeme za neveljavne argumente. `public` pomeni dostopnost drugi kodi; `static` omogoča klic prek imena razreda brez ustvarjanja objekta. Primer uporabe iz druge aplikacije, ki referencira ta projekt:

```csharp
double[] temperature = { -8, -3, -5 };
double najvecja = Vaja003.Statistika.Najvecja(temperature);
```

V igri neveljavni vnosi ne porabijo poskusa. Ob koncu vhoda (`null`) se konča celoten program brez dodatnega menija; po normalnem koncu igre sledi vrnitev v meni. Število je izbrano naključno z `new Random().Next(1, 101)`.

Izvorne napake in vzroki: `Napake.md`. Dejanska preverjanja in omejitve: `Preverjanje.md`. Dokumentacijski viri: `Viri.md`.

Decimalno ločilo pri izpisu je odvisno od nastavitev računalnika.
