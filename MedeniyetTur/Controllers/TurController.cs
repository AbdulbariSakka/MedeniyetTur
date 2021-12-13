using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedeniyetTur.Models;
using MedeniyetTur.Utils;
using System.IO;

namespace MedeniyetTur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurController : ControllerBase
    {
        SqlDbHelper turDb = new SqlDbHelper();

        [HttpGet("{id}")]
        public ActionResult<Tur> GetTur(int id)
        {
            Tur tur = turDb.GetTur(id);

            return tur;
        }

        [HttpGet("/image/{id}")]
        public ActionResult<Tur> GetImage(string id)
        {

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", id);
            MemoryStream stream = new MemoryStream();
           
            using (var fs = System.IO.File.Open(path, FileMode.Open))
            {
                fs.CopyTo(stream);
            }
        
            stream.Position = 0; //reset memory stream position.

            return File(stream, "image/jpeg");
        }

        [HttpGet]
        public ActionResult<List<Tur>> GetTurs()
        {
            List<Tur> turs = new List<Tur>();
            turs = turDb.GetTurs();
            /*List<Tur> turs = new List<Tur>()
            {
                new Tur()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                },
                new Tur()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                },
                new Tur()
                {
                    Price = 10,
                    Description = "test test test",
                    Img = "photo"
                }
            };*/
            return turs;
        }

        [HttpPost]
        public IActionResult AddTur([FromForm] Tur tur)
        {
            if (tur.ImageFile != null)
            {
                string imageName = SaveImage(tur.ImageFile);
                tur.Image = imageName;
            }

            int result = turDb.AddTur(tur);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTur([FromForm] Tur tur)
        {
            if (tur.ImageFile != null)
            {
                string imageName = SaveImage(tur.ImageFile);
                tur.Image = imageName;
            }
            int result = turDb.UpdateTur(tur);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteTur(int id)
        {
            int result = turDb.DeleteTur(id);
            return Ok(result);
        }


        private string SaveImage(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                string imageName = $"{Guid.NewGuid().ToString()}-{file.FileName}";

                string path = Path.Combine(dir, imageName);

                Directory.CreateDirectory(dir);

                System.IO.File.WriteAllBytes(path, fileBytes);

                return imageName;
            }
        }
    }
}
