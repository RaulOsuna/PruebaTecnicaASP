using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaTecnica1.Models;
using PruebaTecnicaASP.Data;

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDInventarioController : Controller
    {
        private readonly ApplicationDbContext ArticuloDbContext;
        public CRUDInventarioController(ApplicationDbContext ArticuloDbContext)
        {
            this.ArticuloDbContext = ArticuloDbContext;
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarStockArticulo([FromBody] List<ventasArticulos> articulos)
        {

            Articulos result = new Articulos();
            try
            {
                foreach (var articulo in articulos)
                {
                    result = ArticuloDbContext.Articulos.Where(s => s.Id == articulo.ArticuloId).First();
                    result.Stock = result.Stock - articulo.Cantidad;
                    await ArticuloDbContext.SaveChangesAsync();
                }
                
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }
    }
}
