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
        public IActionResult Pay([FromForm] User user)
        {
            int result = turDb.AddUser(user);
            return Ok(result);
        }
    }
}
