using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Metodo_Entrega")]
public partial class MetodoEntrega
{
    [Key]
    [Column("idMetodoEntrega")]
    public int IdMetodoEntrega { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string Metodo { get; set; } = null!;

    [InverseProperty("IdMetodoEntregaNavigation")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
