using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace APIRest.Models
{
    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo1")
        {
        }

        public  DbSet<PEDIDOS> PEDIDOS { get; set; }
        public DbSet<PRODUCTOS> PRODUCTOS { get; set; }
        public  DbSet<USUARIOS> USUARIOS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PEDIDOS>()
                .Property(e => e.pedVrUnit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PEDIDOS>()
                .Property(e => e.PedSubtot)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PEDIDOS>()
                .Property(e => e.PedTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.ProDesc)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTOS>()
                .Property(e => e.ProValor)
                .HasPrecision(19, 4);

            //modelBuilder.Entity<PRODUCTOS>()
            //    .HasMany(e => e.PEDIDOS)
            //    .WithOptional(e => e.PRODUCTOS)
            //    .HasForeignKey(e => e.pedPro);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.UsuNombre)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIOS>()
                .Property(e => e.UsuPass)
                .IsUnicode(false);

            //modelBuilder.Entity<USUARIOS>()
            //    .HasMany(e => e.PEDIDOS)
            //    .WithOptional(e => e.USUARIOS)
            //    .HasForeignKey(e => e.PedUsu);
        }
    }
}
