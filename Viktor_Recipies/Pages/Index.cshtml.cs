using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Net;
using Viktor_Recipies.Model;
using Viktor_Recipies.Services;
using Recipies = Viktor_Recipies.Model.Recipies;



namespace Viktor_Recipies.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public RecipieService RecipieService;
        public IEnumerable<Recipies> Recipies { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, RecipieService recipieService)
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
