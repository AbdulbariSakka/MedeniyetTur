using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedeniyetTur.Models;
using MedeniyetTur.Utils;

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
            int result = turDb.AddTur(tur);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTur([FromForm] Tur tur)
        {
            int result = turDb.UpdateTur(tur);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteTur(int id)
        {
            int result = turDb.DeleteTur(id);
            return Ok(result);
        }

    }
}
