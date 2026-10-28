# Preverjanje Vaja003

## Obnašanje statistike

V `Statistika.cs` metodi `Povprecje` in `Najvecja` pri praznem polju ali `null` vrneta `double.NaN` (rezultat ni določen), `PrestejNad` pa 0. Metode uporabljajo zanke, ne spreminjajo vhodnega polja ter nimajo konzolnega vnosa/izpisa ali skupnega spremenljivega stanja.

Metode za čas, dostavo in preverjanje testnega cilja igre uporabljajo izjeme za neveljavne argumente. Statistične metode obravnavajo prazne vhodne podatke z zgoraj določenimi povratnimi vrednostmi.

## Dejansko preverjeno

- .NET SDK 8.0.425, Linux, cilj `net8.0`.
- Release gradnja: 0 opozoril in 0 napak.
- Zbirka 250 preverjanj: uspešna. Preverjeni so tudi `double.IsNaN` pri manjkajočih podatkih in ničelno štetje.
- Zajeto: normalne in robne vrednosti časa/dostave, statistika, negativne meritve, enočlensko in prazno polje, `null`, stroga meja in nespremenjen vhod; vrnjena točka; igra z znanim ciljem, neveljavni vnosi, sedem poskusov, EOF in razpolavljanje za vseh 100 ciljev.
- Preverjen celotni meni: posamezne izbire 1–5, odsotnost izpisov drugih podnalog, vračanje, izhod 0, neznane izbire ter EOF med igro in po nalogi.
- Prava naključna igra skozi `Program.Main` je bila rešena s sledenjem namigom in po zmagi pravilno vrnjena v meni.

Število 250 je število avtomatizirano preverjenih trditev, ne 250 neodvisnih ročnih preizkusov. Preverjevalni program ni del oddajne aplikacije in preverjanja niso uradno ocenjevanje.

## Kaj pomeni NaN?

```csharp
if (meritve == null || meritve.Length == 0)
{
    return double.NaN;
}
```

Če podatkov ni, izračuna ne nadaljujemo. `NaN` je posebna vrednost tipa `double`, ne besedilo in ne izjema. V klicni kodi jo preverimo z `double.IsNaN(rezultat)`. Ni pravilno uporabiti `rezultat == double.NaN`.

Vhodni NaN in neskončnosti niso posebej obravnavani. Decimalno ločilo je odvisno od nastavitev okolja.
