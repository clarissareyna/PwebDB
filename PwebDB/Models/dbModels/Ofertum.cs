using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

public partial class Ofertum
{
    [Key]
    [Column("idOferta")]
    public int IdOferta { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Descuento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaInicio { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaFin { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [ForeignKey("IdOferta")]
    [InverseProperty("IdOferta")]
    public virtual ICollection<Categorium> IdCategoria { get; set; } = new List<Categorium>();
}
