using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaTecnica1.Models;
using PruebaTecnicaASP.Data;

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDCarritoCompraController : Controller
    {

        private readonly ApplicationDbContext VentaDBContext;
        private readonly ApplicationDbContext ContabilidadDBContext;
        public CRUDCarritoCompraController(ApplicationDbContext VentaDBContext, ApplicationDbContext ContabilidadDBContext)
        {
            this.VentaDBContext = VentaDBContext;
            this.ContabilidadDBContext = ContabilidadDBContext;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarRegistroCarrito([FromBody] List<ventasArticulos> articulos)
        {

            try
            {
                foreach (ventasArticulos articulo in articulos)
                {
                    await VentaDBContext.AddAsync(articulo);
                    await VentaDBContext.SaveChangesAsync();
                }
                
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }
        [Route("contabilidad")]
        [HttpPost]
        public async Task<IActionResult> GuardarRegistroCarrito([FromBody] ContabilidadSimple contabilidad)
        {

            try
            {
                
                   await ContabilidadDBContext.AddAsync(contabilidad);
                   await ContabilidadDBContext.SaveChangesAsync();
                   

            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        
    }
}
