using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PF_Backend.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public List<Portion>? Portions { get; set; } = []; 
    }
}
