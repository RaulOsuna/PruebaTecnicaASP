using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPruebaTecnica1.Models
{
    
    public class Tienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Sucursal { get; set; }
        public string? Direccion { get; set; }
        public ICollection<Articulos> Articulo { get; } = new List<Articulos>();
        public Boolean Estatus { get; set; } = true;
    }

}
