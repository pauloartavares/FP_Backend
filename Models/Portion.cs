using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PF_Backend.Models
{
    public class Portion
    {
        [Key]
        public int Id { get; set; }

        public int RecipesId { get; set; }

        [JsonIgnore]
        public Recipe? Recipe { get; set; }

        public Ingredient? Ingredient { get; set; }

        public string? Unity { get; set; }

        public decimal Quantity { get; set; }
    }
}
