using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

public partial class Categorium
{
    [Key]
    [Column("idCategoria")]
    public int IdCategoria { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    public int? CategoriaPadre { get; set; }

    [ForeignKey("CategoriaPadre")]
    [InverseProperty("InverseCategoriaPadreNavigation")]
    public virtual Categorium? CategoriaPadreNavigation { get; set; }

    [InverseProperty("CategoriaPadreNavigation")]
    public virtual ICollection<Categorium> InverseCategoriaPadreNavigation { get; set; } = new List<Categorium>();

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("IdCategoria")]
    public virtual ICollection<Ofertum> IdOferta { get; set; } = new List<Ofertum>();
}
