using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy_Calculadora.Controllers
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

        [HttpGet("sum/{firstNumer}/{secondNumber}")]
        public IActionResult Get(string firstNumer, string secondNumber)
        {
            return CalculatorValue(firstNumer, secondNumber, Operation.sum);
        }

        [HttpGet("sub/{firstNumer}/{secondNumber}")]
        public IActionResult GetSub(string firstNumer, string secondNumber)
        {
            return CalculatorValue(firstNumer, secondNumber, Operation.sub);
        }
        [HttpGet("mult/{firstNumer}/{secondNumber}")]
        public IActionResult GetMult(string firstNumer, string secondNumber)
        {
            return CalculatorValue(firstNumer, secondNumber, Operation.mult);
        }

        [HttpGet("div/{firstNumer}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumer, string secondNumber)
        {
            return CalculatorValue(firstNumer, secondNumber, Operation.div);
        }

        private IActionResult CalculatorValue(string firstNumer, string secondNumber, Operation operation)
        {
            bool isNumber = IsNumeric(firstNumer) && IsNumeric(secondNumber);

            if (isNumber)
            {
                var value = 0m;

                if (operation == Operation.div)
                    value = ConvertToDecimal(firstNumer) / ConvertToDecimal(secondNumber);
                else if (operation == Operation.mult)
                    value = ConvertToDecimal(firstNumer) * ConvertToDecimal(secondNumber);
                else if (operation == Operation.sum)
                    value = ConvertToDecimal(firstNumer) + ConvertToDecimal(secondNumber);
                else if (operation == Operation.sub)
                    value = ConvertToDecimal(firstNumer) - ConvertToDecimal(secondNumber);

                return Ok(value.ToString());
            }

            return BadRequest("Invalid Input");
        }
        private bool IsNumeric(string firstNumer)
        {
            double number;
            bool isNumber = double.TryParse(
                firstNumer,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

            throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string firstNumer)
        {
            decimal decimalValue;

            if (decimal.TryParse(firstNumer, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

    }

    public enum Operation
    {
        div,
        mult,
        sum,
        sub
    }
}