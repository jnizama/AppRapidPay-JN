using Microsoft.EntityFrameworkCore;
using RapidPay.Entities.Model;
using RapidPay.Persistency.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Persistency
{
    public class RapidPayContext : DbContext
    {
        public RapidPayContext(DbContextOptions<RapidPayContext> options)
            : base(options) { }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Payment> PaymentHistory { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Card>()
            //    .Property(p => p.Balance)
            //    .HasColumnType("decimal(18,2)");

            //modelBuilder.Entity<Payment>()
            //    .Property(p => p.Balance)
            //    .HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Payment>()
            //    .Property(p => p.Fee)
            //    .HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Payment>()
            //    .Property(p => p.Amount)
            //    .HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<Payment>()
            //    .Property(p => p.PreviusBalance)
            //    .HasColumnType("decimal(18,2)");
        }

    }
}
