namespace DogodkiOprema;

public class GlavnoOkno : Form
{
    private readonly Label lblIskanje = new Label()
    {
        Name = "lblIskanje",
        Text = "Iskanje po nazivu opreme",
        AutoSize = true,
        TabIndex = 0
    };

    private readonly TextBox txtIskanje = new TextBox()
    {
        Name = "txtIskanje",
        Dock = DockStyle.Fill,
        PlaceholderText = "Del naziva opreme",
        TabIndex = 1
    };

    private readonly CheckBox chkNaVoljo = new CheckBox()
    {
        Name = "chkNaVoljo",
        Text = "Samo oprema, ki je na voljo",
        AutoSize = true,
        TabIndex = 2
    };

    private readonly Button btnPoisci = new Button()
    {
        Name = "btnPoisci",
        Text = "Poišči",
        AutoSize = true,
        TabIndex = 3
    };

    private readonly ListBox lstOprema = new ListBox()
    {
        Name = "lstOprema",
        Dock = DockStyle.Fill,
        MinimumSize = new Size(0, 100),
        TabIndex = 4
    };

    private readonly Label lblRezultat = new Label()
    {
        Name = "lblRezultat",
        AutoSize = true,
        Dock = DockStyle.Fill,
        TabIndex = 5
    };

    private readonly Label lblIzbor = new Label()
    {
        Name = "lblIzbor",
        Text = "Izberite kos opreme.",
        AutoSize = true,
        Dock = DockStyle.Fill,
        TabIndex = 6
    };

    // Dopolnitev: namen, opozorilo in podatki pripravljenega osnutka.
    private readonly Label lblNamen = new Label()
    {
        Name = "lblNamen",
        Text = "Namen izposoje",
        AutoSize = true,
        TabIndex = 7
    };

    private readonly TextBox txtNamen = new TextBox()
    {
        Name = "txtNamen",
        Dock = DockStyle.Fill,
        TabIndex = 8
    };

    private readonly Label lblNapaka = new Label()
    {
        Name = "lblNapaka",
        AutoSize = true,
        Dock = DockStyle.Fill,
        ForeColor = Color.Firebrick,
        TabIndex = 9
    };

    private readonly Button btnPripravi = new Button()
    {
        Name = "btnPripravi",
        Text = "Pripravi osnutek",
        AutoSize = true,
        TabIndex = 10
    };

    private readonly Label lblPovzetek = new Label()
    {
        Name = "lblPovzetek",
        AutoSize = true,
        Dock = DockStyle.Fill,
        Visible = false,
        TabIndex = 11
    };

    private readonly Button btnPotrdi = new Button()
    {
        Name = "btnPotrdi",
        Text = "Potrdi osnutek",
        AutoSize = true,
        Enabled = false,
        TabIndex = 12
    };

    private readonly Label lblPotrditev = new Label()
    {
        Name = "lblPotrditev",
        AutoSize = true,
        Dock = DockStyle.Fill,
        Visible = false,
        TabIndex = 13
    };

    private readonly Label lblStevec = new Label()
    {
        Name = "lblStevec",
        Text = "Število pripravljenih osnutkov: 0",
        AutoSize = true,
        Dock = DockStyle.Fill,
        TabIndex = 14
    };

    private readonly Label lblZadnjiOsnutek = new Label()
    {
        Name = "lblZadnjiOsnutek",
        AutoSize = true,
        Dock = DockStyle.Fill,
        Visible = false,
        TabIndex = 15
    };

    private readonly Button btnPocisti = new Button()
    {
        Name = "btnPocisti",
        Text = "Počisti",
        AutoSize = true,
        TabIndex = 16
    };
    private int steviloOsnutkov = 0;

    public event EventHandler<OsnutekEventArgs>? OsnutekPripravljen;

    public GlavnoOkno()
    {
        Name = "GlavnoOkno";
        Text = "Izposoja opreme – dogodki";
        ClientSize = new Size(760, 720);
        MinimumSize = new Size(600, 650);
        StartPosition = FormStartPosition.CenterScreen;

        // Samo seznam porabi preostali prostor; druge vrstice sledijo vsebini.
        TableLayoutPanel razpored = new TableLayoutPanel()
        {
            Name = "razpored",
            TabIndex = 0,
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(16),
            ColumnCount = 1,
            RowCount = 17
        };
        razpored.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        for (int vrstica = 0; vrstica < 17; vrstica++)
        {
            if (vrstica == 4)
            {
                razpored.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            }
            else
            {
                razpored.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }

        razpored.Controls.Add(lblIskanje, 0, 0);
        razpored.Controls.Add(txtIskanje, 0, 1);
        razpored.Controls.Add(chkNaVoljo, 0, 2);
        razpored.Controls.Add(btnPoisci, 0, 3);
        razpored.Controls.Add(lstOprema, 0, 4);
        razpored.Controls.Add(lblRezultat, 0, 5);
        razpored.Controls.Add(lblIzbor, 0, 6);
        razpored.Controls.Add(lblNamen, 0, 7);
        razpored.Controls.Add(txtNamen, 0, 8);
        razpored.Controls.Add(lblNapaka, 0, 9);
        razpored.Controls.Add(btnPripravi, 0, 10);
        razpored.Controls.Add(lblPovzetek, 0, 11);
        razpored.Controls.Add(btnPotrdi, 0, 12);
        razpored.Controls.Add(lblPotrditev, 0, 13);
        razpored.Controls.Add(lblStevec, 0, 14);
        razpored.Controls.Add(lblZadnjiOsnutek, 0, 15);
        razpored.Controls.Add(btnPocisti, 0, 16);
        Controls.Add(razpored);

        // Povezava dogodka z metodo. Samo ime metode v C# ne vzpostavi povezave.
        btnPoisci.Click += PoisciKlik;
        chkNaVoljo.CheckedChanged += FilterSpremenjen;
        lstOprema.SelectedIndexChanged += IzborSpremenjen;
        txtIskanje.TextChanged += IskanjeSpremenjeno;
        txtNamen.TextChanged += NamenSpremenjen;
        btnPripravi.Click += PripraviKlik;
        btnPotrdi.Click += PotrdiKlik;
        btnPocisti.Click += PocistiKlik;
        OsnutekPripravljen += ObOsnutkuPripravljen;

        AcceptButton = btnPoisci; // Enter sproži privzeti gumb.
        OsveziSeznam();
    }

    // Isto pravilo uporabimo med urejanjem in pred pripravo.
    public static string PreveriNamen(string namen)
    {
        string ociscenNamen = namen.Trim();
        int dolzina = ociscenNamen.Length;
        if (dolzina < 5)
        {
            return "Namen izposoje mora imeti vsaj 5 znakov brez zunanjih presledkov.";
        }

        return "";
    }

    private void SkrijPovzetek()
    {
        btnPotrdi.Enabled = false;
        lblPotrditev.Text = "";
        lblPotrditev.Visible = false;
        lblPovzetek.Text = "";
        lblPovzetek.Visible = false;
        lblZadnjiOsnutek.Text = "";
        lblZadnjiOsnutek.Visible = false;
    }

    private void IskanjeSpremenjeno(object? sender, EventArgs e)
    {
        SkrijPovzetek();
    }

    private void NamenSpremenjen(object? sender, EventArgs e)
    {
        SkrijPovzetek();
        lblNapaka.Text = PreveriNamen(txtNamen.Text);
    }

    private void PripraviKlik(object? sender, EventArgs e)
    {
        SkrijPovzetek();
        string napakaNamena = PreveriNamen(txtNamen.Text);
        bool manjkaOprema = lstOprema.SelectedItem == null;
        if (manjkaOprema)
        {
            lblNapaka.Text = "Izberite kos opreme. " + napakaNamena;
        }
        else
        {
            lblNapaka.Text = napakaNamena;
        }
        if (manjkaOprema || napakaNamena != "")
        {
            if (manjkaOprema)
            {
                lstOprema.Focus();
            }
            else
            {
                txtNamen.Focus();
            }
            return;
        }

        string? izbranaOprema = Convert.ToString(lstOprema.SelectedItem);
        string oprema = "";
        if (izbranaOprema != null)
        {
            oprema = izbranaOprema;
        }
        OsnutekEventArgs podatki = new OsnutekEventArgs(oprema, txtNamen.Text.Trim());
        lblPovzetek.Text = $"Osnutek izposoje: {podatki.Oprema}. Namen: {podatki.Namen}";
        lblPovzetek.Visible = true;
        btnPotrdi.Enabled = true;
        OsnutekPripravljen?.Invoke(this, podatki);
    }

    private void PotrdiKlik(object? sender, EventArgs e)
    {
        if (!btnPotrdi.Enabled || !lblPovzetek.Visible)
        {
            return;
        }

        lblPotrditev.Text = "Osnutek je potrjen. To ni rezervacija in se ne shrani po zaprtju programa.";
        lblPotrditev.Visible = true;
        btnPotrdi.Enabled = false;
    }

    private void ObOsnutkuPripravljen(object? sender, OsnutekEventArgs e)
    {
        // Števec povečamo samo ob prejemu lastnega dogodka.
        steviloOsnutkov++;
        lblStevec.Text = $"Število pripravljenih osnutkov: {steviloOsnutkov}";
        lblZadnjiOsnutek.Text = $"Zadnji osnutek: {e.Oprema}, namen: {e.Namen}";
        lblZadnjiOsnutek.Visible = true;
    }

    private void PocistiKlik(object? sender, EventArgs e)
    {
        txtNamen.Clear();
        lstOprema.ClearSelected();
        lblNapaka.Text = "";
        SkrijPovzetek();
        steviloOsnutkov = 0;
        lblStevec.Text = "Število pripravljenih osnutkov: 0";
        txtNamen.Focus();
    }

    private void PoisciKlik(object? sender, EventArgs e)
    {
        OsveziSeznam();
    }

    private void FilterSpremenjen(object? sender, EventArgs e)
    {
        OsveziSeznam();
    }

    private void OsveziSeznam()
    {
        SkrijPovzetek();
        string iskano = txtIskanje.Text;
        bool samoNaVoljo = chkNaVoljo.Checked;
        List<KosOpreme> rezultat = Katalog.Poisci(iskano, samoNaVoljo);

        lstOprema.Items.Clear();
        foreach (KosOpreme kos in rezultat)
        {
            string stanje;
            if (kos.NaVoljo)
            {
                stanje = "na voljo";
            }
            else
            {
                stanje = "ni na voljo";
            }
            lstOprema.Items.Add($"{kos.Naziv} – {stanje}");
        }

        if (rezultat.Count == 0)
        {
            lblRezultat.Text = "Ni zadetkov. Spremenite iskalni pogoj.";
        }
        else
        {
            lblRezultat.Text = $"Število zadetkov: {rezultat.Count}";
        }
        lblIzbor.Text = "Izberite kos opreme.";
    }

    private void IzborSpremenjen(object? sender, EventArgs e)
    {
        SkrijPovzetek();
        // Dogodek se lahko sproži tudi ob programskem praznjenju seznama.
        if (lstOprema.SelectedItem == null)
        {
            lblIzbor.Text = "Izberite kos opreme.";
            return;
        }

        lblIzbor.Text = $"Izbrano: {lstOprema.SelectedItem}";
    }
}
