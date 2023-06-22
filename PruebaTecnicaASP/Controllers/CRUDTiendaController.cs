using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProyectoPruebaTecnica1.Models;
using PruebaTecnicaASP.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaTecnicaASP.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CRUDTiendaController : Controller
    {
        private readonly ApplicationDbContext TiendaDbContext;
        public CRUDTiendaController(ApplicationDbContext TiendaDbContext)
        {
            this.TiendaDbContext = TiendaDbContext;
        }
        // POST:
        [HttpPost]
        public async Task<IActionResult> GuardarRegistroTienda([FromBody] Tienda nuevaTienda)
        {
            
            try
            {
                await TiendaDbContext.AddAsync(nuevaTienda);
                await TiendaDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
            return Ok();
        }
        // POST:
        [HttpGet]
        public List<Tienda> ObtenerRegistroTienda()
        {
            List<Tienda>result=new List<Tienda>();
            try
            {
                result = TiendaDbContext.Tienda.Where(s => s.Estatus == true).ToList();
                                       
                
            }
            catch (Exception)
            {

                return result;
            }

            return result;
        }
        [Route("Id")]
        [HttpPost]
        public Tienda ActualizarRegistroTiendaPorId([FromBody]Tienda Tienda)
        {
            Tienda result = new Tienda();
            try
            {
                result = TiendaDbContext.Tienda.Where(s => s.Id ==Tienda.Id ).First();
                return result;

            }
            catch (Exception)
            {

                return result;
            }
        }


        // GET: CRUDTiendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUDTiendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CRUDTiendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRUDTiendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
