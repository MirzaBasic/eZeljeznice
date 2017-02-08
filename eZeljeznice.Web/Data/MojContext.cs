using System.Data.Entity;
using eZeljeznice.Data.Model;
using System.Data.Entity.ModelConfiguration.Conventions;

using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace eZeljeznice.Web
{
    class MojContext : DbContext 
    {
        public MojContext()
            : base("Name=MojConnectionString")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //one-to-(zero or one)
            //    modelBuilder.Entity<Korisnik>().HasOptional(x => x.Student).WithRequired(x => x.Korisnik);
            //    modelBuilder.Entity<Korisnik>().HasOptional(x => x.Nastavnik).WithRequired(x => x.Korisnik);
            // modelBuilder.Entity<Korisnik>().HasOptional(x => x.Referent).WithRequired(x => x.Korisnik);

            //many-to-one


            modelBuilder.Entity<Zaposlenik>().HasRequired(x => x.TipZaposlenika).WithMany().HasForeignKey(x=>x.TipZaposlenikaId);
            modelBuilder.Entity<Zaposlenik>().HasRequired(x => x.Grad).WithMany().HasForeignKey(x => x.GradId);

            modelBuilder.Entity<Korisnik>().HasRequired(x => x.Grad).WithMany().HasForeignKey(x => x.GradId);
            modelBuilder.Entity<UlogeKorisnika>().HasRequired(x => x.Korisnik).WithMany().HasForeignKey(x => x.KorisnikId);
            modelBuilder.Entity<UlogeKorisnika>().HasRequired(x => x.Uloga).WithMany().HasForeignKey(x => x.UlogaId);
         


            modelBuilder.Entity<Karta>().HasRequired(x => x.TipKarte).WithMany().HasForeignKey(x=>x.TipKarteId);
            modelBuilder.Entity<Karta>().HasRequired(x => x.Zaposlenik).WithMany().HasForeignKey(x => x.ZaposlenikId);
            modelBuilder.Entity<Karta>().HasRequired(x => x.LinijaVoznje).WithMany().HasForeignKey(x => x.LinijaVoznjeId);
            modelBuilder.Entity<Karta>().HasRequired(x => x.Zaposlenik).WithMany().HasForeignKey(x=>x.ZaposlenikId);
            modelBuilder.Entity<Karta>().HasOptional(x => x.Rezervacija).WithMany().HasForeignKey(x => x.RezervacijaId);

            modelBuilder.Entity<Grad>().HasRequired(x => x.Kanton).WithMany().HasForeignKey(x => x.KantonId);
            modelBuilder.Entity<Kanton>().HasRequired(x => x.Drzava).WithMany().HasForeignKey(x => x.DrzavaId);

            modelBuilder.Entity<Stanica>().HasRequired(x => x.TipStanice).WithMany().HasForeignKey(x => x.TipStaniceId);
            modelBuilder.Entity<Stanica>().HasRequired(x => x.Grad).WithMany().HasForeignKey(x => x.GradId);

            modelBuilder.Entity<LinijaVoznje>().HasRequired(x => x.Voz).WithMany().HasForeignKey(x => x.VozId);
            modelBuilder.Entity<LinijaVoznje>().HasRequired(x => x.TipLinije).WithMany().HasForeignKey(x => x.TipLinijeId);

            modelBuilder.Entity<StanicaLinije>().HasRequired(x => x.LinijaVoznje).WithMany().HasForeignKey(x => x.LinijaVoznjeId);
            modelBuilder.Entity<StanicaLinije>().HasRequired(x => x.Stanica).WithMany().HasForeignKey(x => x.StanicaId);

            modelBuilder.Entity<Vagon>().HasRequired(x => x.TipVagona).WithMany().HasForeignKey(x => x.TipVagonaId);
            modelBuilder.Entity<VagoniVoza>().HasRequired(x => x.Voz).WithMany().HasForeignKey(x => x.VozId);
            modelBuilder.Entity<VagoniVoza>().HasRequired(x => x.Vagon).WithMany().HasForeignKey(x => x.VagonId);

            modelBuilder.Entity<Lokomotiva>().HasRequired(x => x.TipLokomotive).WithMany().HasForeignKey(x => x.TipLokomotiveId);

            modelBuilder.Entity<Voz>().HasRequired(x => x.Lokomotiva).WithMany().HasForeignKey(x => x.LokomotivaId);

            modelBuilder.Entity<Rezervacija>().HasRequired(x => x.Korisnik).WithMany().HasForeignKey(x => x.KorisnikId);
            modelBuilder.Entity<Rezervacija>().HasRequired(x => x.LinijaVoznje).WithMany().HasForeignKey(x => x.LinijaVoznjeId);

            modelBuilder.Entity<PodkategorijeProizvoda>().HasRequired(x => x.KategorijeProizvoda).WithMany().HasForeignKey(x => x.KategorijeProizvodaId);

            modelBuilder.Entity<Dobavljac>().HasRequired(x => x.Grad).WithMany().HasForeignKey(x => x.GradId);

            modelBuilder.Entity<Skladiste>().HasRequired(x => x.Grad).WithMany().HasForeignKey(x => x.GradId);

            modelBuilder.Entity<Nabavka>().HasRequired(x => x.Zaposlenik).WithMany().HasForeignKey(x => x.ZaposlenikId);

            modelBuilder.Entity<Nabavka>().HasRequired(x => x.Skladiste).WithMany().HasForeignKey(x => x.SkladisteId);

            modelBuilder.Entity<Nabavka>().HasRequired(x => x.Dobavljac).WithMany().HasForeignKey(x => x.DobavljacId);

            modelBuilder.Entity<StavkeNabavke>().HasRequired(x => x.Nabavka).WithMany().HasForeignKey(x => x.NabavkaId);
            modelBuilder.Entity<StavkeNabavke>().HasRequired(x => x.Proizvod).WithMany().HasForeignKey(x => x.ProizvodId);

            modelBuilder.Entity<Kvar>().HasRequired(x => x.KategorijaKvara).WithMany().HasForeignKey(x => x.KategorijaKvaraId);
            modelBuilder.Entity<Kvar>().HasRequired(x => x.Zaposlenik).WithMany().HasForeignKey(x => x.ZaposlenikId);
            modelBuilder.Entity<Kvar>().HasOptional(x => x.Voz).WithMany().HasForeignKey(x => x.VozId);

            modelBuilder.Entity<Obavijest>().HasRequired(x => x.Zaposlenik).WithMany().HasForeignKey(x => x.ZaposlenikId);







            //http://blogs.msdn.com/b/adonet/archive/2010/12/14/ef-feature-ctp5-fluent-api-samples.aspx
        }
        public DbSet<Nabavka> Nabavke { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { set; get; }
        public DbSet<TipZaposlenika> TipoviZaposlenika { set; get; }
        public DbSet<UlogeKorisnika> UlogeKorisnika { set; get; }
        public DbSet<Uloga> Uloge { set; get; }
        public DbSet<Korisnik> Korisnici { set; get; }
        public DbSet<Karta> Karte { set; get; }
        public DbSet<TipKarte> TipoviKarte { set; get; }
        public DbSet<Grad> Gradovi { set; get; }
        public DbSet<Kanton> Kantoni { set; get; }
        public DbSet<Drzava> Drzave { set; get; }
        public DbSet<Stanica> Stanice { get; set; }
        public DbSet<TipStanice> TipStanice { get; set; }
        public DbSet<LinijaVoznje> LinijeVoznje { get; set; }
        public DbSet<StanicaLinije> StaniceLinije { get; set; }
        public DbSet<TipLinije> TipoviLinije { get; set; }
        public DbSet<Voz> Vozovi { get; set; }
        public DbSet<Vagon> Vagoni { get; set; }
        public DbSet<TipVagona> TipoviVagona { get; set; }
        public DbSet<VagoniVoza> VagoniVoza { get; set; }
        public DbSet<Lokomotiva> Lokomotive { get; set; }
        public DbSet<TipLokomotive> TipoviLokomotiva { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<KategorijeProizvoda> KategorijeProizvoda { get; set; }
        public DbSet<PodkategorijeProizvoda> PodkategorijeProizvoda { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<Skladiste> Skladista { get; set; }
        public DbSet<StavkeNabavke> StavkeNabavke { get; set; }
        public DbSet<KategorijaKvara> KategorijeKvarova { get; set; }
        public DbSet<Kvar> Kvarovi { get; set; }
        public DbSet<Obavijest> Obavijesti { get; set; }

    }
}
