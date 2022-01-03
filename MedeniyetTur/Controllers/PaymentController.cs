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
    public class PaymentController : ControllerBase
    {
        SqlDbHelper turDb = new SqlDbHelper();

        [HttpPost]
        public IActionResult Pay([FromBody] User user)
        {
            int result = turDb.AddUser(user);
            return Ok(result);
        }

        [HttpPost("{id}")]
        [Route("[action]")]
        public IActionResult pay1([FromBody] Card card)
        {

            int result = turDb.AddCard(card);
            return Ok(result);
        }
    }
}
