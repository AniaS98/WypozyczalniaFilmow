namespace WypozyczalniaFilmow
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BazaDanych : DbContext
    {
        // Your context has been configured to use a 'BazaDanych' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WypozyczalniaFilmowTests.BazaDanych' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BazaDanych' 
        // connection string in the application configuration file.
        public BazaDanych()
            : base("name=BazaDanych")
        {
        }

        public virtual DbSet <SystemKont> systemBaza { get; set; }
        public virtual DbSet <ListaFilmowDostepnych> listaFilmowDostepnychBaza { get; set; }
        public virtual DbSet <Klient> klientBaza { get; set; }
        public virtual DbSet <Film> filmBaza { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}