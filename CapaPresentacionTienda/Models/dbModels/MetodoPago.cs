using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Metodo_Pago")]
public partial class MetodoPago
{
    [Key]
    [Column("idMetodoPago")]
    public int IdMetodoPago { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Metodo { get; set; } = null!;

    [InverseProperty("IdMetodoPagoNavigation")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
