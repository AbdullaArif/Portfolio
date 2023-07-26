using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Portfolio.DAL;
using Portfolio.Models;
using System.Data;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Contact> contacts = await _context.Contacts.ToListAsync();
            return View(contacts);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Contact contacts = await _context.Contacts.FirstOrDefaultAsync(s => s.Id == id);

            if (contacts is null) return NotFound();
            _context.Contacts.Remove(contacts);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
