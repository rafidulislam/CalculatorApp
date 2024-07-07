using CalculatorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Index(CalculatorModel model)
        {
            model.Result = Calculate(model.FirstNumber, model.SecondNumber, model.Operator);
            return View(model);
        }

        private double Calculate(double firstNumber, double secondNumber, string operatorUsed)
        {
            return operatorUsed switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                _ => throw new InvalidOperationException("Invalid operator"),
            };
        }
    }
}
