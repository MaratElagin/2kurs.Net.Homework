using HW11.Models;
using HW11.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            AnswerModel model;
            var result = _calculator.Calculate(expression);
            if (result.Type is TypeAnswer.Error)
                model = new AnswerModel($"Error: {result.Error}");
            else model = new AnswerModel($"Result: {result.Success}");
            return View(model);
        }
    }
}