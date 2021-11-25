using HW9.Calculator;
using HW9.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW9.Controllers
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
            var result = _calculator.Calculate(expression);
            AnswerModel model;
            if (result.Type is TypeAnswer.Success)
                model = new AnswerModel($"Result: {result.Success}");
            else
                model = new AnswerModel($"Error: {result.Error}");
            return View(model);
        }
    }
}