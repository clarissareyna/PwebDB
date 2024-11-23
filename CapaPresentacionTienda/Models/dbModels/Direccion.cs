using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PwebDB.Models.dbModels;

[Table("Direccion")]
public partial class Direccion
{
    [Key]
    [Column("idDireccion")]
    public int IdDireccion { get; set; }

    [Column("idUsuario")]
    public int IdUsuario { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Calle { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string Colonia { get; set; } = null!;

    public int NumeroExt { get; set; }

    public int? NumeroInt { get; set; }

    [StringLength(45)]
    [Unicode(false)]
    public string Ciudad { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    [Column("CP")]
    [StringLength(10)]
    [Unicode(false)]
    public string Cp { get; set; } = null!;

    [ForeignKey("IdUsuario")]
    [InverseProperty("Direccions")]
    public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;

    [InverseProperty("IdDireccionNavigation")]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();
}
