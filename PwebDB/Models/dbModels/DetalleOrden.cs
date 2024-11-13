using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[PrimaryKey("IdOrden", "IdProducto")]
[Table("Detalle_Orden")]
public partial class DetalleOrden
{
    [Key]
    [Column("idOrden")]
    public int IdOrden { get; set; }

    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecioUnitario { get; set; }

    [ForeignKey("IdOrden")]
    [InverseProperty("DetalleOrdens")]
    public virtual Orden IdOrdenNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("DetalleOrdens")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
