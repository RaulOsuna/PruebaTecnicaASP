using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaTecnica1.Models;
using PruebaTecnicaASP.Data;

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDArticuloController : Controller
    {

        private readonly ApplicationDbContext ArticuloDbContext;
        public CRUDArticuloController(ApplicationDbContext ArticuloDbContext)
        {
            this.ArticuloDbContext = ArticuloDbContext;
        }

        [HttpPost]
        public async Task<string> GuardarRegistroArticulo([FromBody] Articulos articulo)
        {

            try
            {
                await ArticuloDbContext.AddAsync(articulo);
                await ArticuloDbContext.SaveChangesAsync();
                string id = articulo.Id.ToString();
                return id;
            }
            catch (Exception)
            {

                return "0";
            }

        }
        [HttpPut]
        public async Task<IActionResult> EditarrRegistroArticulo([FromBody] Articulos articulo)
        {
            Articulos result = new Articulos();
            try
            {
                result = ArticuloDbContext.Articulos.Where(s => s.Id == articulo.Id).First();
                result.Descripcion=articulo.Descripcion;
                result.Codigo=articulo.Codigo;
                result.Precio=articulo.Precio;
                result.Stock=articulo.Stock;
                await ArticuloDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public List<Articulos> ObtenerArticulosDisponibles()
        {
            List<Articulos> result = new List<Articulos>();
            try
            {
                result = ArticuloDbContext.Articulos.Where(s => s.Estatus == true && s.Stock>0).ToList();


            }
            catch (Exception)
            {

                return result;
            }

            return result;
        }
        [Route("Id")]
        [HttpPost]
        public Articulos ObtenerArticuloPorId([FromBody] Articulos articulo)
        {
            Articulos result = new Articulos();
            try
            {
                result = ArticuloDbContext.Articulos.Where(s => s.Id == articulo.Id).First();


            }
            catch (Exception)
            {

                return result;
            }

            return result;
        }

        // GET: CRUDArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        
    }
}
