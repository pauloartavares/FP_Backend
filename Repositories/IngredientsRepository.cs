using Microsoft.EntityFrameworkCore;
using PF_Backend.Data;
using PF_Backend.Models;
using System.Security.Cryptography.X509Certificates;

namespace PF_Backend.Repositories
{
    public class IngredientsRepository : IRepository<Ingredient>
    {
        private readonly PF_BackendContext Context;

        public IngredientsRepository(PF_BackendContext context)
        {
            Context = context;
        }   

        public IEnumerable<Ingredient> GetAll() 
        {
            return Context
                .Ingredients
                .Include(x => x.Portions)
                .ToList();   
            
        }

        public Ingredient Get(int id)
        {
            return Context
                .Ingredients
                .Include(x => x.Portions)
                .FirstOrDefault(x => x.Id == id)!;

        }

        public Ingredient Add(Ingredient value) 
        {
            Context.Ingredients.Add(value);
            Context.SaveChanges();

            return value;
        }
        
        public void Update(Ingredient value)
        {
            Context.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id) 
        {
            var value = Get(id);
            if (value != null)
            {
                Context.Ingredients.Remove(value);
                Context.SaveChanges();
            }


        }
        
        public IEnumerable<Ingredient> All()
        {
            throw new NotImplementedException();
        }
    }
}
