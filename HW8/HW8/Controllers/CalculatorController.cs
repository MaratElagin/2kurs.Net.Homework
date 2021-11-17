using System;
using HW8.Calculator;
using HW8.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HW8.Controllers
{
    public class CalculatorController : Controller
    {
        public string Calculate([FromServices] ICalculator calculator,
            string val1,
            string operation,
            string val2)
        {
            var isDouble1 = double.TryParse(val1, out var v1);
            var isDouble2 = double.TryParse(val2, out var v2);
            if (!isDouble1 || !isDouble2) return $"{val1} или {val2} не являются числами. Введите числа";

            var isOperation = Enum.TryParse<Operation>(operation, true, out var op);
            if (!isOperation)
                return $"{operation} - недопустимая операция. Допустимые: plus, minus, multiply или divide";

            return op switch
            {
                Operation.Plus => calculator.Plus(v1, v2),
                Operation.Minus => calculator.Minus(v1, v2),
                Operation.Multiply => calculator.Multiply(v1, v2),
                Operation.Divide => calculator.Divide(v1, v2),
            };
        }
        
        public IActionResult Index()
        {
            return Content(
                "Fill val1, operation(plus, minus, multiply, divide) and val2 here '/calculator/calculate?val1= &operation= &val2= '\n" +
                "and add it to address line.");
        }
    }
}