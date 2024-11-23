using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Tipo_Perfume")]
public partial class TipoPerfume
{
    [Key]
    [Column("idTipoPerfume")]
    public int IdTipoPerfume { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Tipo { get; set; } = null!;

    [InverseProperty("IdTipoPerfumeNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
