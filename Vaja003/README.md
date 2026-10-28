# Vaja003 — pregledna različica z menijem

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

**To niso šest ločenih projektov.** Vse ostane v enem konzolnem projektu `Vaja003`, koda pa je razporejena po datotekah. Meni je dodatek za preglednost, ne sprememba zahtev naloge. Tretja in četrta izbira uporabljata iste metode: četrta naloga je predvsem ureditev kode v ponovno uporaben modul.

## Napoved izpisa pri 1. nalogi

Izvorni izsek iz navodil izpiše po vrsti `10`, `3` in `3,5` (oziroma `3.5`, odvisno od nastavitev okolja). Spremenljivka `b` ohrani kopijo vrednosti 10, čeprav se `a` pozneje spremeni. Izraz `7 / 2` deli dve celi števili, zato je rezultat 3. Pri `7 / 2.0` je en operand tipa `double`, zato je rezultat 3,5.

## Zakaj pri 6. nalogi zadošča sedem poskusov?

Pri strategiji razpolavljanja vedno ugibamo sredino preostalega območja. Če je ugib premajhen, nadaljujemo z večjimi števili; če je prevelik, z manjšimi. Tako po vsakem napačnem ugibu izločimo približno polovico možnosti. Sedem poskusov zadošča za vsa števila od 1 do 100: `2^6 = 64 < 100`, `2^7 = 128 >= 100`. Na primer: če je iskano število 42, lahko ugibamo 50, 25, 37, 43, 40, 41 in 42.

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
| `Povprecje` | `double[] meritve` | `double`: 20 | `ArgumentException` |
| `Najvecja` | `double[] meritve` | `double`: 23 | `ArgumentException` |
| `PrestejNad` | `double[] meritve`, `double meja` = 20 | `int`: 1 | 0 |

Vse tri pri `null` sprožijo `ArgumentNullException`. Meritve naj bodo običajna končna števila; `NaN` in neskončnosti niso dodatno obravnavane. `public` pomeni dostopnost drugi kodi; `static` omogoča klic prek imena razreda brez ustvarjanja objekta. Primer uporabe iz druge aplikacije, ki referencira ta projekt:

```csharp
double[] temperature = { -8, -3, -5 };
double najvecja = Vaja003.Statistika.Najvecja(temperature);
```

V igri neveljavni vnosi ne porabijo poskusa. Ob koncu vhoda (`null`) se konča celoten program brez dodatnega menija; po normalnem koncu igre se lahko vrneš v meni. Za ponovljiv preizkus lahko začasno zamenjaš naključno izbrano število v `Ugibanje.Zazeni` z `42`; po testiranju vrni `new Random().Next(1, 101)`. Oddajna koda uporablja naključno izbiro.

Izvorne napake, vzroki in popravki so opisani v `Napake.md`.

Predavanje `003-predavanje.md` ni bilo priloženo. Decimalno ločilo pri izpisu je odvisno od nastavitev računalnika.
