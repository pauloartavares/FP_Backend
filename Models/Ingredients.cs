using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PF_Backend.Models
{
    public class Ingredients
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public List<Recipes>? Recipes { get; } = [];
    }
}
