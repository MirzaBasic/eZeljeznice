namespace eZeljeznice.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dobavljacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        NazivFirme = c.String(),
                        KontaktOsoba = c.String(),
                        Telefon = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Opis = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Grads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        PostanskiBroj = c.Int(nullable: false),
                        KantonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kantons", t => t.KantonId)
                .Index(t => t.KantonId);
            
            CreateTable(
                "dbo.Kantons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Oznaka = c.String(),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzavas", t => t.DrzavaId)
                .Index(t => t.DrzavaId);
            
            CreateTable(
                "dbo.Drzavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Oznaka = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        SerijskiBroj = c.String(),
                        VrijemePolaska = c.DateTime(nullable: false),
                        CijenaSaPDV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CijenaBezPDV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Popust = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kolicina = c.Int(nullable: false),
                        BrojSjedista = c.Int(nullable: false),
                        DatumKupovine = c.DateTime(nullable: false),
                        DatumIstekaKarte = c.DateTime(nullable: false),
                        TipKarteId = c.Int(nullable: false),
                        ZaposlenikId = c.Int(nullable: false),
                        LinijaVoznjeId = c.Int(nullable: false),
                        RezervacijaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinijaVoznjes", t => t.LinijaVoznjeId)
                .ForeignKey("dbo.Rezervacijas", t => t.RezervacijaId)
                .ForeignKey("dbo.TipKartes", t => t.TipKarteId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.TipKarteId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.LinijaVoznjeId)
                .Index(t => t.RezervacijaId);
            
            CreateTable(
                "dbo.LinijaVoznjes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        NazivLinije = c.String(),
                        VrijemePolaska = c.DateTime(nullable: false),
                        VrijemeDolaska = c.DateTime(nullable: false),
                        Napomena = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        VozId = c.Int(nullable: false),
                        TipLinijeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipLinijes", t => t.TipLinijeId)
                .ForeignKey("dbo.Vozs", t => t.VozId)
                .Index(t => t.VozId)
                .Index(t => t.TipLinijeId);
            
            CreateTable(
                "dbo.TipLinijes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vozs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                        DatumKreiranja = c.DateTime(nullable: false),
                        KretanjeVoza = c.Boolean(nullable: false),
                        LokomotivaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lokomotivas", t => t.LokomotivaId)
                .Index(t => t.LokomotivaId);
            
            CreateTable(
                "dbo.Lokomotivas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        DatumProizvodnje = c.DateTime(nullable: false),
                        SerijskiBroj = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        TipLokomotiveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipLokomotives", t => t.TipLokomotiveId)
                .Index(t => t.TipLokomotiveId);
            
            CreateTable(
                "dbo.TipLokomotives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumRezervacije = c.DateTime(nullable: false),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kolicina = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        LinijaVoznjeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .ForeignKey("dbo.LinijaVoznjes", t => t.LinijaVoznjeId)
                .Index(t => t.KorisnikId)
                .Index(t => t.LinijaVoznjeId);
            
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        JMBG = c.String(),
                        BrojKreditenKartice = c.String(),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        DatumRodjenja = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Adresa = c.String(),
                        Email = c.String(),
                        DatumIzmjene = c.DateTime(nullable: false),
                        NazivFirme = c.String(),
                        Telefon = c.String(),
                        Fax = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.TipKartes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Popust = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Zaposleniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        JMBG = c.String(),
                        BrojKreditenKartice = c.String(),
                        KorisnickoIme = c.String(),
                        Lozinka = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        DatumRodjenja = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Adresa = c.String(),
                        Email = c.String(),
                        DatumIzmjene = c.DateTime(nullable: false),
                        Telefon = c.String(),
                        Fax = c.String(),
                        TipZaposlenikaId = c.Int(nullable: false),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .ForeignKey("dbo.TipZaposlenikas", t => t.TipZaposlenikaId)
                .Index(t => t.TipZaposlenikaId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.TipZaposlenikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KategorijaKvaras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KategorijeProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kvars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        VrijemeKvara = c.DateTime(nullable: false),
                        OpisKvara = c.String(),
                        Napomena = c.String(),
                        Popravljeno = c.Boolean(nullable: false),
                        VrijemePopravke = c.DateTime(),
                        ZaposlenikId = c.Int(nullable: false),
                        VozId = c.Int(),
                        KategorijaKvaraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KategorijaKvaras", t => t.KategorijaKvaraId)
                .ForeignKey("dbo.Vozs", t => t.VozId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId)
                .Index(t => t.VozId)
                .Index(t => t.KategorijaKvaraId);
            
            CreateTable(
                "dbo.Nabavkas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        CijenaBezPDV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CijenaSaPDV = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumKreiranja = c.DateTime(nullable: false),
                        DatumIsporuke = c.DateTime(nullable: false),
                        Isporuceno = c.Boolean(nullable: false),
                        Odobreno = c.Boolean(nullable: false),
                        Ponisteno = c.Boolean(nullable: false),
                        DobavljacId = c.Int(nullable: false),
                        SkladisteId = c.Int(nullable: false),
                        ZaposlenikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacId)
                .ForeignKey("dbo.Skladistes", t => t.SkladisteId)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.DobavljacId)
                .Index(t => t.SkladisteId)
                .Index(t => t.ZaposlenikId);
            
            CreateTable(
                "dbo.Skladistes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Adresa = c.String(),
                        GradId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .Index(t => t.GradId);
            
            CreateTable(
                "dbo.Obavijests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        DatumKreiranja = c.DateTime(nullable: false),
                        Opis = c.String(),
                        Sadrzaj = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        ZaposlenikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Zaposleniks", t => t.ZaposlenikId)
                .Index(t => t.ZaposlenikId);
            
            CreateTable(
                "dbo.PodkategorijeProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        KategorijeProizvodaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KategorijeProizvodas", t => t.KategorijeProizvodaId)
                .Index(t => t.KategorijeProizvodaId);
            
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Sifta = c.String(),
                        Cijena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Opis = c.String(),
                        Kolicina = c.Int(nullable: false),
                        PodkategorijeProizvodaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PodkategorijeProizvodas", t => t.PodkategorijeProizvodaId)
                .Index(t => t.PodkategorijeProizvodaId);
            
            CreateTable(
                "dbo.Stanicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        NazivStanice = c.String(),
                        Oznaka = c.String(),
                        Broj = c.String(),
                        Aktivan = c.Boolean(nullable: false),
                        Adresa = c.String(),
                        GradId = c.Int(nullable: false),
                        TipStaniceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grads", t => t.GradId)
                .ForeignKey("dbo.TipStanices", t => t.TipStaniceId)
                .Index(t => t.GradId)
                .Index(t => t.TipStaniceId);
            
            CreateTable(
                "dbo.TipStanices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StanicaLinijes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        VrijemeDolaska = c.DateTime(nullable: false),
                        VrijemePolaska = c.DateTime(nullable: false),
                        LinijaVoznjeId = c.Int(nullable: false),
                        StanicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LinijaVoznjes", t => t.LinijaVoznjeId)
                .ForeignKey("dbo.Stanicas", t => t.StanicaId)
                .Index(t => t.LinijaVoznjeId)
                .Index(t => t.StanicaId);
            
            CreateTable(
                "dbo.StavkeNabavkes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        NabavkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nabavkas", t => t.NabavkaId)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId)
                .Index(t => t.ProizvodId)
                .Index(t => t.NabavkaId);
            
            CreateTable(
                "dbo.TipVagonas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ulogas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UlogeKorisnikas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumKreiranja = c.DateTime(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        UlogaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .ForeignKey("dbo.Ulogas", t => t.UlogaId)
                .Index(t => t.KorisnikId)
                .Index(t => t.UlogaId);
            
            CreateTable(
                "dbo.Vagons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        SerijskiBroj = c.String(),
                        DatumProizvodnje = c.DateTime(nullable: false),
                        BrojSjedista = c.Int(nullable: false),
                        Aktivan = c.Boolean(nullable: false),
                        TipVagonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipVagonas", t => t.TipVagonaId)
                .Index(t => t.TipVagonaId);
            
            CreateTable(
                "dbo.VagoniVozas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumKreiranja = c.DateTime(nullable: false),
                        RedniBroj = c.Int(nullable: false),
                        VagonId = c.Int(nullable: false),
                        VozId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vagons", t => t.VagonId)
                .ForeignKey("dbo.Vozs", t => t.VozId)
                .Index(t => t.VagonId)
                .Index(t => t.VozId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VagoniVozas", "VozId", "dbo.Vozs");
            DropForeignKey("dbo.VagoniVozas", "VagonId", "dbo.Vagons");
            DropForeignKey("dbo.Vagons", "TipVagonaId", "dbo.TipVagonas");
            DropForeignKey("dbo.UlogeKorisnikas", "UlogaId", "dbo.Ulogas");
            DropForeignKey("dbo.UlogeKorisnikas", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.StavkeNabavkes", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.StavkeNabavkes", "NabavkaId", "dbo.Nabavkas");
            DropForeignKey("dbo.StanicaLinijes", "StanicaId", "dbo.Stanicas");
            DropForeignKey("dbo.StanicaLinijes", "LinijaVoznjeId", "dbo.LinijaVoznjes");
            DropForeignKey("dbo.Stanicas", "TipStaniceId", "dbo.TipStanices");
            DropForeignKey("dbo.Stanicas", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Proizvods", "PodkategorijeProizvodaId", "dbo.PodkategorijeProizvodas");
            DropForeignKey("dbo.PodkategorijeProizvodas", "KategorijeProizvodaId", "dbo.KategorijeProizvodas");
            DropForeignKey("dbo.Obavijests", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Nabavkas", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Nabavkas", "SkladisteId", "dbo.Skladistes");
            DropForeignKey("dbo.Skladistes", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Nabavkas", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.Kvars", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Kvars", "VozId", "dbo.Vozs");
            DropForeignKey("dbo.Kvars", "KategorijaKvaraId", "dbo.KategorijaKvaras");
            DropForeignKey("dbo.Kartas", "ZaposlenikId", "dbo.Zaposleniks");
            DropForeignKey("dbo.Zaposleniks", "TipZaposlenikaId", "dbo.TipZaposlenikas");
            DropForeignKey("dbo.Zaposleniks", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Kartas", "TipKarteId", "dbo.TipKartes");
            DropForeignKey("dbo.Kartas", "RezervacijaId", "dbo.Rezervacijas");
            DropForeignKey("dbo.Rezervacijas", "LinijaVoznjeId", "dbo.LinijaVoznjes");
            DropForeignKey("dbo.Rezervacijas", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.Korisniks", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Kartas", "LinijaVoznjeId", "dbo.LinijaVoznjes");
            DropForeignKey("dbo.LinijaVoznjes", "VozId", "dbo.Vozs");
            DropForeignKey("dbo.Vozs", "LokomotivaId", "dbo.Lokomotivas");
            DropForeignKey("dbo.Lokomotivas", "TipLokomotiveId", "dbo.TipLokomotives");
            DropForeignKey("dbo.LinijaVoznjes", "TipLinijeId", "dbo.TipLinijes");
            DropForeignKey("dbo.Dobavljacs", "GradId", "dbo.Grads");
            DropForeignKey("dbo.Grads", "KantonId", "dbo.Kantons");
            DropForeignKey("dbo.Kantons", "DrzavaId", "dbo.Drzavas");
            DropIndex("dbo.VagoniVozas", new[] { "VozId" });
            DropIndex("dbo.VagoniVozas", new[] { "VagonId" });
            DropIndex("dbo.Vagons", new[] { "TipVagonaId" });
            DropIndex("dbo.UlogeKorisnikas", new[] { "UlogaId" });
            DropIndex("dbo.UlogeKorisnikas", new[] { "KorisnikId" });
            DropIndex("dbo.StavkeNabavkes", new[] { "NabavkaId" });
            DropIndex("dbo.StavkeNabavkes", new[] { "ProizvodId" });
            DropIndex("dbo.StanicaLinijes", new[] { "StanicaId" });
            DropIndex("dbo.StanicaLinijes", new[] { "LinijaVoznjeId" });
            DropIndex("dbo.Stanicas", new[] { "TipStaniceId" });
            DropIndex("dbo.Stanicas", new[] { "GradId" });
            DropIndex("dbo.Proizvods", new[] { "PodkategorijeProizvodaId" });
            DropIndex("dbo.PodkategorijeProizvodas", new[] { "KategorijeProizvodaId" });
            DropIndex("dbo.Obavijests", new[] { "ZaposlenikId" });
            DropIndex("dbo.Skladistes", new[] { "GradId" });
            DropIndex("dbo.Nabavkas", new[] { "ZaposlenikId" });
            DropIndex("dbo.Nabavkas", new[] { "SkladisteId" });
            DropIndex("dbo.Nabavkas", new[] { "DobavljacId" });
            DropIndex("dbo.Kvars", new[] { "KategorijaKvaraId" });
            DropIndex("dbo.Kvars", new[] { "VozId" });
            DropIndex("dbo.Kvars", new[] { "ZaposlenikId" });
            DropIndex("dbo.Zaposleniks", new[] { "GradId" });
            DropIndex("dbo.Zaposleniks", new[] { "TipZaposlenikaId" });
            DropIndex("dbo.Korisniks", new[] { "GradId" });
            DropIndex("dbo.Rezervacijas", new[] { "LinijaVoznjeId" });
            DropIndex("dbo.Rezervacijas", new[] { "KorisnikId" });
            DropIndex("dbo.Lokomotivas", new[] { "TipLokomotiveId" });
            DropIndex("dbo.Vozs", new[] { "LokomotivaId" });
            DropIndex("dbo.LinijaVoznjes", new[] { "TipLinijeId" });
            DropIndex("dbo.LinijaVoznjes", new[] { "VozId" });
            DropIndex("dbo.Kartas", new[] { "RezervacijaId" });
            DropIndex("dbo.Kartas", new[] { "LinijaVoznjeId" });
            DropIndex("dbo.Kartas", new[] { "ZaposlenikId" });
            DropIndex("dbo.Kartas", new[] { "TipKarteId" });
            DropIndex("dbo.Kantons", new[] { "DrzavaId" });
            DropIndex("dbo.Grads", new[] { "KantonId" });
            DropIndex("dbo.Dobavljacs", new[] { "GradId" });
            DropTable("dbo.VagoniVozas");
            DropTable("dbo.Vagons");
            DropTable("dbo.UlogeKorisnikas");
            DropTable("dbo.Ulogas");
            DropTable("dbo.TipVagonas");
            DropTable("dbo.StavkeNabavkes");
            DropTable("dbo.StanicaLinijes");
            DropTable("dbo.TipStanices");
            DropTable("dbo.Stanicas");
            DropTable("dbo.Proizvods");
            DropTable("dbo.PodkategorijeProizvodas");
            DropTable("dbo.Obavijests");
            DropTable("dbo.Skladistes");
            DropTable("dbo.Nabavkas");
            DropTable("dbo.Kvars");
            DropTable("dbo.KategorijeProizvodas");
            DropTable("dbo.KategorijaKvaras");
            DropTable("dbo.TipZaposlenikas");
            DropTable("dbo.Zaposleniks");
            DropTable("dbo.TipKartes");
            DropTable("dbo.Korisniks");
            DropTable("dbo.Rezervacijas");
            DropTable("dbo.TipLokomotives");
            DropTable("dbo.Lokomotivas");
            DropTable("dbo.Vozs");
            DropTable("dbo.TipLinijes");
            DropTable("dbo.LinijaVoznjes");
            DropTable("dbo.Kartas");
            DropTable("dbo.Drzavas");
            DropTable("dbo.Kantons");
            DropTable("dbo.Grads");
            DropTable("dbo.Dobavljacs");
        }
    }
}
