using PruebaTecnicaASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using static AutoMapper.Internal.ExpressionFactory;
using Microsoft.EntityFrameworkCore;

namespace ProyectoPruebaTecnica1.Models
{
    public class Articulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string? Descripcion { get; set; }
        public float Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int Stock { get; set; }
        public int? TiendaId { get; set; } 
        public Tienda? Tienda { get; set; } = null!;
        public virtual ICollection<ventasArticulos>? VentasArticulo { get; set; }

        public Boolean Estatus { get; set; } = true;
    }
    public class ventasArticulos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ArticuloId { get; set; } 
        public string UserId { get; set; } = null!;
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public byte[]? image { get; set; }
    }
    public class ContabilidadSimple
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public float Total { get; set; }
    }

    public class file
    {
        public string Base64 { get; set; }
        public string Extension { get; set; }
        public string Codigo { get; set; }

    }
}

