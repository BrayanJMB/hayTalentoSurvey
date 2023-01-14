using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Controllers
{
    public class CityCountryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CityCountryController(ApplicationDbContext context)
        {
            _context = context;
        }
        //agregar ciudades 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCity( List<City> City)
        {
            if (ModelState.IsValid)
            {
                await _context.AddRangeAsync(City);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        //agregar Paises
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCountry(List<Country> Country)
        {
            if (ModelState.IsValid)
            {
                await _context.AddRangeAsync(Country);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
