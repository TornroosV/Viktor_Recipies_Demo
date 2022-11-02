using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Viktor_Recipies.Model
{
    public class Recipies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<string> Ingredients { get; set; }
        public override string ToString() => JsonSerializer.Serialize<Recipies>(this);
    }
}
