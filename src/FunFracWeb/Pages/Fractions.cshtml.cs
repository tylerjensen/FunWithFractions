using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FracFunLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FunFracWeb.Pages
{
    public class FractionsModel : PageModel
    {
        private readonly ILogger<FractionsModel> _logger;

        public string FractionInput { get; set; }
        public string ResultMessage { get; set; }

        public FractionsModel(ILogger<FractionsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            FractionInput = "Enter your fraction equation here.";
            ResultMessage = string.Empty;
        }

        public void OnPost()
        {
            try
            {
                FractionInput = Request.Form[nameof(FractionInput)];

                IParser parser = new Parser();
                ICalculator calculator = new Calculator(parser);
                var result = calculator.Calculate(FractionInput);
                ResultMessage = $"The answer is: {result}";
            }
            catch (Exception e)
            {
                ResultMessage = e.Message;
            }
        }
    }
}
