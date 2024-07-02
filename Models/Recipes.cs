using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PF_Backend.Models
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Difficulty { get; set; }

        public string Category { get; set; }

        public int Duration { get; set; }

        [JsonIgnore]
        public List<Ingredients>? Ingredients { get; } = [];
    }
}
