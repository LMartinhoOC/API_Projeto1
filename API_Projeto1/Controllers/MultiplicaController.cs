using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using API_Projeto1.Models;

namespace API_Projeto1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MultiplicaController : Controller
    {
        [HttpGet]
        public ActionResult Get(string numero)
        {
            int num = Convert.ToInt32(numero);

            return Ok(num * 2);
        }

        [HttpPost]
        public ActionResult Post([FromBody]POSTNumero numero)
        {
            int num = Convert.ToInt32(numero.Num);
            numero.Num = (num * 2).ToString();
            return Ok(numero.Num);
        }
    }
}