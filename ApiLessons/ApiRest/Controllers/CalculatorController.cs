using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                decimal sum = decimal.Parse(firstNumber) + decimal.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtration(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                decimal sum = decimal.Parse(firstNumber) - decimal.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplicatiom(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                decimal sum = decimal.Parse(firstNumber) * decimal.Parse(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                try
                {
                    decimal sum = decimal.Parse(firstNumber) / decimal.Parse(secondNumber);
                    return Ok(sum.ToString());

                } catch (DivideByZeroException)
                {
                    return BadRequest("Division by zero");
                }
            }
            return BadRequest("Invalid Input");
        }
        [HttpGet("square/{firstNumber}")]
        public IActionResult GetSquareRoot(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                double sum = Math.Sqrt(double.Parse(firstNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        private bool isNumeric (string number)
        {
            if (String.IsNullOrEmpty(number))
                return false;

            if (decimal.TryParse(number, System.Globalization.NumberStyles.None, System.Globalization.NumberFormatInfo.InvariantInfo,out decimal result))
                return true;
       
            return false;
        }
    }
}
