﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PF_Backend.Data;
using PF_Backend.Models;

namespace PF_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly PF_BackendContext _context;

        public IngredientsController(PF_BackendContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);

            if (ingredients == null)
            {
                return NotFound();
            }

            return ingredients;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredients(int id, Ingredient ingredients)
        {
            if (id != ingredients.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredients(Ingredient ingredients)
        {
            _context.Ingredients.Add(ingredients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredients", new { id = ingredients.Id }, ingredients); // Fica
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredients(int id)
        {
            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredients);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientsExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
