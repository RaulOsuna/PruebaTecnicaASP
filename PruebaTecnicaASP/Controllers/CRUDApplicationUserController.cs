using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaTecnica1.Models;
using System.Security.Claims;

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDApplicationUserController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        // GET: CRUDApplicationUserController
        public CRUDApplicationUserController(IHttpContextAccessor httpContextAccessor )
        {
            _httpContextAccessor = httpContextAccessor;
           
            
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRUDApplicationUserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //[HttpGet]
        //public string ObtenerUsuarioIdActivo()
        //{
            
        //    try
        //    {
               
        //    }
        //    catch (Exception)
        //    {
        //        var id="";
        //        return id;
        //    }
        //}

    }
}
