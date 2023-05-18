using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lab2CoffeeShop.Models;

public partial class DbcoffeeShopContext : DbContext
{
    public DbcoffeeShopContext()
    {
    }

    public DbcoffeeShopContext(DbContextOptions<DbcoffeeShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoffeeRoast> CoffeeRoasts { get; set; }

    public virtual DbSet<CoffeeType> CoffeeTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-978U9AM\\SQLEXPRESS;Database=DBCoffeeShop;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoffeeRoast>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(30);
                //.IsFixedLength();
        });

        modelBuilder.Entity<CoffeeType>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(30);
                //.IsFixedLength();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(100);
                //.IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(50);
            //.IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50);
            //.IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50);
                //.IsFixedLength();
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(60);
                //.IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.Manufacturers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Manufacturers_Countries");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Orders_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50);
                //.IsFixedLength();
            entity.Property(e => e.Price).HasColumnType("smallmoney");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK_Products_Manufacturers");

            entity.HasOne(d => d.Roast).WithMany(p => p.Products)
                .HasForeignKey(d => d.RoastId)
                .HasConstraintName("FK_Products_CoffeeRoasts");

            entity.HasOne(d => d.Type).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_Products_CoffeeTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
