using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PwebDB.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {

        [Column(TypeName = "datetime")]
        public DateTime FechaRegistro { get; set; }

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

}
}
