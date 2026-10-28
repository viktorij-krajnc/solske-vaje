# Vaja002 – izposoja opreme

Windows Forms aplikacija v C# za iskanje opreme, pripravo in potrditev osnutka izposoje. Temelji na šolskem začetnem primeru.

## Zagon

Potrebujete Windows in .NET 8 Windows Forms razvojno okolje. V Visual Studiu odprite `DogodkiOprema.csproj` in zaženite projekt. Iz te mape lahko uporabite tudi `dotnet run --project DogodkiOprema.csproj`.

## Zgradba kode

Pogoji so zapisani z `if/else`, tipi z `new TextBox()` oziroma ustreznim tipom, lastnosti gradnikov so v ločenih vrsticah. Besedila z vstavljenimi vrednostmi uporabljajo interpolacijo `$"...{vrednost}..."`. Lasten dogodek s podatki povezuje pripravo osnutka z obdelovalnikom in števcem. Podrobnosti in rezultati preverjanj so v dokumentaciji.

## Dopolnitev

- Namen izposoje: najmanj pet znakov po odstranitvi zunanjih presledkov.
- Preverjanje med urejanjem in ob pripravi osnutka.
- Lasten dogodek `OsnutekPripravljen` s podatki opreme in namena.
- Števec uspešnih priprav, povzetek in gumb Počisti.
- Gumb Potrdi osnutek, ki je omogočen šele po uspešni pripravi. Potrditev ne poveča števca pripravljenih osnutkov.

## Uporaba

Izberite opremo, vnesite namen in kliknite Pripravi osnutek. Preberite povzetek ter kliknite Potrdi osnutek. Pojavi se potrditev, gumb pa se onemogoči. Sprememba namena, izbora, iskanja ali filtra odstrani stari osnutek in potrditev. Za nov postopek uporabite Počisti.

Tudi potrjeni osnutek ni prava rezervacija in se ne shrani po zaprtju aplikacije. Razpoložljivost opreme ostane nespremenjena.

[Dokumentacija, preizkusi in razhroščevanje](dokumentacija.md).

Slike razhroščevanja prikazujejo prave ustavitve Windows procesa prek terminalskega odjemalca DAP, ne Visual Studia. Pri pripravi projekta, dokumentacije in preverjanj je bila uporabljena pomoč AI.
