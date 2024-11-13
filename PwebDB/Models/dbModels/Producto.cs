using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Producto")]
public partial class Producto
{
    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("idMarcaPerfume")]
    public int IdMarcaPerfume { get; set; }

    [Column("idCategoria")]
    public int IdCategoria { get; set; }

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Column("VolumenEnML")]
    public int? VolumenEnMl { get; set; }

    public int Stock { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Imagen { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaAgregado { get; set; }

    [Column("idTipoPerfume")]
    public int IdTipoPerfume { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Productos")]
    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    [ForeignKey("IdMarcaPerfume")]
    [InverseProperty("Productos")]
    public virtual MarcaPerfume IdMarcaPerfumeNavigation { get; set; } = null!;

    [ForeignKey("IdTipoPerfume")]
    [InverseProperty("Productos")]
    public virtual TipoPerfume IdTipoPerfumeNavigation { get; set; } = null!;
}
