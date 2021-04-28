using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("substract/{firstNumber}/{secondNumber}")]
        public IActionResult Substract(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var substract = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(substract.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Inputs");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var decimalSecondNumber = ConvertToDecimal(secondNumber);
                if(CanDivide(decimalSecondNumber))
                {
                    var division = ConvertToDecimal(firstNumber) / decimalSecondNumber;
                    return Ok(division.ToString());
                }
                return BadRequest("Can't divide by zero");
            }
            return BadRequest("Invalid Inputs");

        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var numberSum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                var average = numberSum / 2;
                return Ok(average.ToString());
            }
            return BadRequest("Invalid Inputs");

        }

        [HttpGet("square/{stringNumber}")]
        public IActionResult Square(string stringNumber)
        {
            if (IsNumeric(stringNumber))
            {
                var square = Math.Sqrt((double)ConvertToDecimal(stringNumber)) ;
                return Ok(square.ToString());
            }
            return BadRequest("Invalid Inputs");

        }

        private bool CanDivide(decimal secondNumber)
        {
            if(secondNumber != 0)
            {
                return true;
            }
            return false;
        }

        private decimal ConvertToDecimal(string stringNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(stringNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

   

        private bool IsNumeric(string stringNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                stringNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }
    }
}
