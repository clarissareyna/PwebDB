using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

public partial class PerfimeDatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public PerfimeDatabaseContext()
    {
    }

    public PerfimeDatabaseContext(DbContextOptions<PerfimeDatabaseContext> options)
        : base(options) { }


    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<DetalleOrden> DetalleOrdens { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<MarcaPerfume> MarcaPerfumes { get; set; }

    public virtual DbSet<MetodoEntrega> MetodoEntregas { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Ofertum> Oferta { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<TipoPerfume> TipoPerfumes { get; set; }

 


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdProducto }).HasName("PK__Califica__542869B5F9F060F8");

            entity.Property(e => e.FechaCalificacion).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Calificacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__idPro__5535A963");


        });

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdProducto }).HasName("PK__Carrito__542869B5D445A0F4");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Carritos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Carrito__idProdu__5CD6CB2B");


        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240C40695A0F");

            entity.HasOne(d => d.CategoriaPadreNavigation).WithMany(p => p.InverseCategoriaPadreNavigation).HasConstraintName("FK__Categoria__Categ__3D5E1FD2");
        });

        modelBuilder.Entity<DetalleOrden>(entity =>
        {
            entity.HasKey(e => new { e.IdOrden, e.IdProducto }).HasName("PK__Detalle___F8D5BCE08BDF820E");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.DetalleOrdens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_O__idOrd__656C112C");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleOrdens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_O__idPro__66603565");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__B49878C9DC842296");


        });

        modelBuilder.Entity<MarcaPerfume>(entity =>
        {
            entity.HasKey(e => e.IdMarcaPerfume).HasName("PK__Marca_Pe__1A5431A9EB381E9C");
        });

        modelBuilder.Entity<MetodoEntrega>(entity =>
        {
            entity.HasKey(e => e.IdMetodoEntrega).HasName("PK__Metodo_E__568616F927F6EE4D");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__Metodo_P__817BFC3274C1E7AB");
        });

        modelBuilder.Entity<Ofertum>(entity =>
        {
            entity.HasKey(e => e.IdOferta).HasName("PK__Oferta__05A1245E466F9DC2");

            entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdOferta)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriaOfertum",
                    r => r.HasOne<Categorium>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__idCat__59063A47"),
                    l => l.HasOne<Ofertum>().WithMany()
                        .HasForeignKey("IdOferta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Categoria__idOfe__5812160E"),
                    j =>
                    {
                        j.HasKey("IdOferta", "IdCategoria").HasName("PK__Categori__DD02F61E8F0D1A99");
                        j.ToTable("Categoria_Oferta");
                        j.IndexerProperty<int>("IdOferta").HasColumnName("idOferta");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("idCategoria");
                    });
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK__Orden__C8AAF6F3720A15DF");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Ordens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden__idDirecci__619B8048");

            entity.HasOne(d => d.IdMetodoEntregaNavigation).WithMany(p => p.Ordens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden__idMetodoE__628FA481");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.Ordens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden__idMetodoP__60A75C0F");


        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__07F4A1328E40ADD3");

            entity.Property(e => e.FechaAgregado).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__idCate__4F7CD00D");

            entity.HasOne(d => d.IdMarcaPerfumeNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__idMarc__4E88ABD4");

            entity.HasOne(d => d.IdTipoPerfumeNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__idTipo__4D94879B");
        });

        modelBuilder.Entity<TipoPerfume>(entity =>
        {
            entity.HasKey(e => e.IdTipoPerfume).HasName("PK__Tipo_Per__C5B903FDEB6FC3D0");
        });

       

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
