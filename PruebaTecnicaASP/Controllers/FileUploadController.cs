using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaTecnica1.Models;
using System.Drawing;

namespace PruebaTecnicaASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : Controller
    {
        [HttpPost]
        public bool GuardarRegistroArticulo([FromBody] file imagen)
        {

            try
            {
                byte[] bytes = Convert.FromBase64String(imagen.Base64);

                using (var imageFile = new FileStream("ClientApp/src/assets/images/"+imagen.Codigo+imagen.Extension,System.IO.FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
