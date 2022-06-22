using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _logger;
        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }


       [HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var somar = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);
                return Ok(somar.ToString());
            }
            return BadRequest("Entrada Inválida");
        }

        [HttpGet("subtracao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtracao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var subtrair = ConvertToDecimal(primeiroNumero) - ConvertToDecimal(segundoNumero);
                return Ok(subtrair.ToString());
            }
            return BadRequest("Entrada Inválida");
        }

        [HttpGet("multiplicacao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Multiplicacao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var multiplicacao = ConvertToDecimal(primeiroNumero) * ConvertToDecimal(segundoNumero);
                return Ok(multiplicacao.ToString());
            }
            return BadRequest("Entrada Inválida");
        }



        [HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Divisao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var multiplicacao = ConvertToDecimal(primeiroNumero) / ConvertToDecimal(segundoNumero);
                return Ok(multiplicacao.ToString());
            }
            return BadRequest("Entrada Inválida");
        }


        [HttpGet("media/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Media(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var soma = (ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero))/2;
                return Ok(soma.ToString());
            }
            return BadRequest("Entrada Inválida");
        }


        [HttpGet("raiz/{primeiroNumero}")]
        public IActionResult Raiz(string primeiroNumero)
        {
            if (IsNumeric(primeiroNumero))
            {
                var raiz = Math.Sqrt((double)ConvertToDecimal(primeiroNumero));
                return Ok(raiz.ToString());
            }
            return BadRequest("Entrada Inválida");
        }

        private bool IsNumeric(string strNumber)
        {
            double numero;
            bool ehNumero = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out numero);
            return ehNumero;
        }


        private decimal ConvertToDecimal(string strNumero)
        {
            decimal decValue;
            if (decimal.TryParse(strNumero, out decValue))
            {
                return decValue;
            }
            return 0;
        }




    }
}
