using ListaCompra.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ListaCompra.DAO
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           base.OnModelCreating(modelBuilder);
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Compra>().ToTable("Compra");
            modelBuilder.Entity<CompraProduto>().ToTable("CompraProduto");
        }
        */

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraProduto> CompraProduto { get; set; }
    }
}