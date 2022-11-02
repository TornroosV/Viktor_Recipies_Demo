using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viktor_Recipies.Model;
using Viktor_Recipies.Services;
using Recipies = Viktor_Recipies.Model.Recipies;



namespace Viktor_Recipies.Pages
{
    public class RecipiesModel : PageModel
    {
        private readonly ILogger<RecipiesModel> _logger;
        public RecipieService RecipieService;
        public IEnumerable<Recipies> Recipies { get; private set; }

        public RecipiesModel(ILogger<RecipiesModel> logger, RecipieService recipieService)
        {
            _logger = logger;
            RecipieService = recipieService;
        }
        int numberOfDays = 0;
        public void OnGet()
        {
            //ToDo Should be user selected from WebSite
            Recipies = RecipieService.GetWeeklyRecipies(5);
        }

    }
}