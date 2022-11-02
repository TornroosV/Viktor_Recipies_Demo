using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viktor_Recipies.Model;
using Viktor_Recipies.Services;
using Microsoft.AspNetCore.Mvc;

namespace Viktor_Recipies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class RecipiesController : ControllerBase
        {
            public RecipiesController(RecipieService RecipieService) => this.RecipieService = RecipieService;

            public RecipieService RecipieService { get; }

            [HttpGet]
            public IEnumerable<Recipies> Get() => RecipieService.GetRecipies();

            [HttpGet]
            public IEnumerable<Recipies> GetWeeklyRecipies() => RecipieService.GetWeeklyRecipies(5);

    }
    
}
