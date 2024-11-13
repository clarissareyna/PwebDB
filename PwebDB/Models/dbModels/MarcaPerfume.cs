using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Marca_Perfume")]
public partial class MarcaPerfume
{
    [Key]
    [Column("idMarcaPerfume")]
    public int IdMarcaPerfume { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Marca { get; set; } = null!;

    [InverseProperty("IdMarcaPerfumeNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
