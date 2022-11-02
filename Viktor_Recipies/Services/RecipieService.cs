using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Viktor_Recipies.Model;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Xml.Linq;

namespace Viktor_Recipies.Services
{
    public class RecipieService
    {
        //Startar en värd för webbmiljö
        public RecipieService(IWebHostEnvironment webHostEnviorment)
        {
            WebHostEnviorment = webHostEnviorment;
        }

        public IWebHostEnvironment WebHostEnviorment { get; }

        private string JsonFileName => Path.Combine(WebHostEnviorment.WebRootPath, "data", "recipies.json");


        public IEnumerable<Recipies> GetRecipies()
        {
            //
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Recipies[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
        }
        public List<Recipies> GetWeeklyRecipies(int numberOfDays)
        {
            List<Recipies> weeklyRecipiesList = new List<Recipies>();
            
            Random random = new Random();
            // read file into a string and deserialize JSON to a type
            List<Recipies> allRecipies = JsonConvert.DeserializeObject<List<Recipies>>(File.ReadAllText("wwwroot/data/recipies.json"));

            for (int i = 0; i < numberOfDays; i++ )
            {
                int recipieID = random.Next(1,allRecipies.Count)-1;
                weeklyRecipiesList.Add(allRecipies[recipieID]);
            }

            File.WriteAllText("wwwroot/data/randomRecipies.json", JsonConvert.SerializeObject(weeklyRecipiesList, Formatting.Indented));

            List<Recipies> selectedRecipies = JsonConvert.DeserializeObject<List<Recipies>>(File.ReadAllText("wwwroot/data/randomRecipies.json"));

            return selectedRecipies;
        }
    }
}