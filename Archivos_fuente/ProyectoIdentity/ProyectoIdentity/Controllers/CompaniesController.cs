using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CompaniesController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }



        // GET: Companies
        
        public async Task<IActionResult> Index()
        {
              return View(await _context.Company.ToListAsync());
        }

        // GET: Companies/Details/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {

            if (ModelState.IsValid)
            {
                company.UserName = company.Email;
                var resultado = await _userManager.CreateAsync(company, company.PasswordHash);

                if (resultado.Succeeded)
                {
                    
                    await _signInManager.SignInAsync(company, isPersistent: false);
                    return RedirectToAction(nameof(Index));
                    
                }

                ValidarErrores(resultado);
            }

            return View(company);
            
            
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _userManager.FindByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Company company)
        {
            var user =(Company) await _userManager.FindByIdAsync(id);
            if (id != company.Id || user==null )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    
                user.UserName = company.Email;
                user.Email= company.Email;
                user.PhoneNumber=company.PhoneNumber;
                user.PersonFullName = company.PersonFullName;
                
                var result= await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        ValidarErrores(result);
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'AppDbContext.Company'  is null.");
            }
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(string id)
        {
          return _context.Company.Any(e => e.Id == id);
        }

        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }
    }
}
