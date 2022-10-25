using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SoftBookShop.Models;

namespace SoftBookShop.Models.Data
{
    public partial class SoftBookShopContext : DbContext
    {
        public SoftBookShopContext()
        {
        }

        public SoftBookShopContext(DbContextOptions<SoftBookShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; } = null!;
        public virtual DbSet<Detalleventum> Detalleventa { get; set; } = null!;
        public virtual DbSet<Metodopago> Metodopagos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Categoria");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Detalleventum>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PRIMARY");

                entity.ToTable("detalleventa");

                entity.HasIndex(e => e.IdProducto, "FK_DETALLE_VENTA_PRODUCTOS");

                entity.HasIndex(e => e.IdVenta, "FK_DETALLE_VENTA_VENTAS");

                entity.Property(e => e.IdDetalleVenta)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_DetalleVenta");

                entity.Property(e => e.Cantidad).HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Producto");

                entity.Property(e => e.IdVenta)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Venta");

                entity.Property(e => e.PrecioUnitario).HasColumnType("double(8,2)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLE_VENTA_PRODUCTOS");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Detalleventa)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DETALLE_VENTA_VENTAS");
            });

            modelBuilder.Entity<Metodopago>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPago)
                    .HasName("PRIMARY");

                entity.ToTable("metodopago");

                entity.Property(e => e.IdMetodoPago)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MetodoPago");

                entity.Property(e => e.Descripcion).HasMaxLength(80);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("productos");

                entity.HasIndex(e => e.IdCategoria, "FK_PRODUCTOS_CATEGORIAS");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Producto");

                entity.Property(e => e.Descripcion).HasMaxLength(80);

                entity.Property(e => e.Estado).HasColumnType("bit(1)");

                entity.Property(e => e.IdCategoria)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Categoria");

                entity.Property(e => e.Imagen).HasMaxLength(200);

                entity.Property(e => e.Precio).HasColumnType("double(8,2)");

                entity.Property(e => e.Stock).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCTOS_CATEGORIAS");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PRIMARY");

                entity.ToTable("ventas");

                entity.HasIndex(e => e.IdMetodoPago, "FK_VENTAS_METODOPAGO");

                entity.Property(e => e.IdVenta)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_Venta");

                entity.Property(e => e.Fecha)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IdMetodoPago)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_MetodoPago");

                entity.Property(e => e.Total).HasColumnType("double(8,2)");

                entity.HasOne(d => d.IdMetodoPagoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdMetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VENTAS_METODOPAGO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
