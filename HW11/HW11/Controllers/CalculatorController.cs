using System;
using HW11.Exceptions;
using HW11.Models;
using HW11.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;

        public CalculatorController(ICalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
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
            try
            {
                var result = _calculator.Calculate(expression);
                model = new AnswerModel($"Result: {result}");
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e);
                model = new AnswerModel($"Error: {e.Message}");
            }
            return View(model);
        }
    }
}