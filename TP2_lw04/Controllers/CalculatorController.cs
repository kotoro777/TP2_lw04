using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP2_lw04.Models;
using Microsoft.AspNetCore.Http;

namespace TP2_lw04.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorModel model, string action)
        {

            if (action == "Calculate")
            {
                if (ModelState.IsValid)
                {
                    switch (model.Operation)
                    {
                        case "+":
                            model.Result = model.Operand1 + model.Operand2;
                            break;
                        case "-":
                            model.Result = model.Operand1 - model.Operand2;
                            break;
                        case "*":
                            model.Result = model.Operand1 * model.Operand2;
                            break;
                        case "/":
                            model.Result = model.Operand1 / model.Operand2;
                            break;
                    }

                    
                }
                else
                {
                    ModelState.AddModelError("Operand1", "Ошибка ввода операнда 1");
                    ModelState.AddModelError("Operand2", "Ошибка ввода операнда 2");
                }
                

                ViewBag.TargetValue = 0;

            }
            else if (action == "Clear")
            {
           
                    model.Operand1 = 0;
                    model.Operand2 = 0;
                    model.Operation = "+";
                    model.Result = 0;
                

            }
            Response.Cookies.Append("Calculation", $"{model.Operand1} {model.Operation} {model.Operand2} = {model.Result}");
            return View("Result", model);
        }

        public ActionResult SecondCalculation()
        {
            
            var calculation = Request.Cookies["Calculation"];

            calculation = calculation.Replace("+", "плюс").Replace("-", "минус").Replace("*", "умножить").Replace("/", "разделить");

            calculation = calculation.PadRight(20);

            ViewBag.Calculation = calculation;

            return View();
        }
    }
}
