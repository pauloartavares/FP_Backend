using Microsoft.EntityFrameworkCore;
using PF_Backend.Data;
using PF_Backend.Models;

namespace PF_Backend.Repositories
{
    public class RecipesRepository : IRepository<Recipe>
    {
        private readonly PF_BackendContext context;

        public RecipesRepository(PF_BackendContext context)
        {
            this.context = context;
        }

        public Recipe Add(Recipe value)
        {
            context.Recipes.Add(value);
            context.SaveChanges();

            return value;
        }
        

        public void Delete(int id)
        {
            var recipe = Get(id);

            if (recipe != null)
            {
                context.Recipes.Remove(recipe);
                context.SaveChanges();
            }
        }

        public Recipe? Get(int id)
        {

            return context
                .Recipes
                .FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return context
                .Recipes
                .ToList();
        }

        public void Update(Recipe value)
        {
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
