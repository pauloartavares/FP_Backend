using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PF_Backend.Models
{
    public class Portions
    {
        [Key]
        public int Id { get; set; }

        public int IdRecipes { get; set; }

        [JsonIgnore]
        public List<Recipes>? Recipes { get; set; } = null!;

        public int IdIngredients { get; set; }

        [JsonIgnore]
        public List<Ingredients>? Ingredients { get; set; } = null!;

        public string? Unity { get; set; }

        public decimal Quantity { get; set; }
    }
}
