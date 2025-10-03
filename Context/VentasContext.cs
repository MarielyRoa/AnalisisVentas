using Microsoft.EntityFrameworkCore;
using readcsv.Class;
using System.Collections.Generic;
using System.Linq;

namespace readcsv.Context
{
    public class VentasContext : DbContext
    {
        private readonly string _conexionString;

        public VentasContext(string conexionString)
        {
            _conexionString = conexionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conexionString);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<order_details>()
                .HasKey(od => new { od.OrderID, od.ProductID });

            base.OnModelCreating(modelBuilder);
        }

        #region "Entidades"
        public DbSet<customers> Clientes { get; set; }
        public DbSet<products> Productos { get; set; }
        public DbSet<orders> Ordenes { get; set; }
        public DbSet<order_details> DetalleOrdenes { get; set; }
        #endregion


    }

}