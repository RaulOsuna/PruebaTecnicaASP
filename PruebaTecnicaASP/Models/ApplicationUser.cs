using Microsoft.AspNetCore.Identity;
using ProyectoPruebaTecnica1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaASP.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string? lastName { get; set; }
        public string? Location { get; set; }
        public virtual ICollection<ventasArticulos>? VentasArticulo { get; set; }
    }
}