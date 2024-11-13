using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[PrimaryKey("IdUsuario", "IdProducto")]
[Table("Calificacion")]
public partial class Calificacion
{
    [Key]
    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    [Column("Calificacion")]
    public int Calificacion1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCalificacion { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("Calificacions")]
    public virtual required Producto IdProductoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("Calificacions")]
    public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
}
