using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProyectoPruebaTecnica1.Models;
using PruebaTecnicaASP.Models;
using System.Reflection.Metadata;

namespace PruebaTecnicaASP.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }
        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<ApplicationUser> AplicationUser { get; set; }
        public DbSet<ventasArticulos> ventaArticulos { get; set; }
        public DbSet<ContabilidadSimple> ContabilidadSimple { get; set; }
        

    }
    

}