using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[PrimaryKey("IdUsuario", "IdProducto")]
[Table("Carrito")]
public partial class Carrito
{
    [Key]
    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("Carritos")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Carritos")]
    public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
}
