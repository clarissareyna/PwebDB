using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Orden")]
public partial class Orden
{
    [Key]
    [Column("idOrden")]
    public int IdOrden { get; set; }

    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [Column("idMetodoPago")]
    public int IdMetodoPago { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Total { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [Column("idDireccion")]
    public int IdDireccion { get; set; }

    [Column("idMetodoEntrega")]
    public int IdMetodoEntrega { get; set; }

    [InverseProperty("IdOrdenNavigation")]
    public virtual ICollection<DetalleOrden> DetalleOrdens { get; set; } = new List<DetalleOrden>();

    [ForeignKey("IdDireccion")]
    [InverseProperty("Ordens")]
    public virtual Direccion IdDireccionNavigation { get; set; } = null!;

    [ForeignKey("IdMetodoEntrega")]
    [InverseProperty("Ordens")]
    public virtual MetodoEntrega IdMetodoEntregaNavigation { get; set; } = null!;

    [ForeignKey("IdMetodoPago")]
    [InverseProperty("Ordens")]
    public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Ordens")]
    public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
}
