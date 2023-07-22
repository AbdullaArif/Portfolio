using Microsoft.AspNetCore.Mvc;
using Portfolio.DAL;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(Contact contact)
        {
            Contact newMessage = new Contact()
            {
                FullName = contact.FullName,
                Phone = contact.Phone,
                Message = contact.Message,
                Email = contact.Email,
            };
            if (string.IsNullOrEmpty(contact.Email))
            {
                ModelState.AddModelError(nameof(contact.Email), "Email is required.");
                return View(contact);
            }

            await _context.Contacts.AddAsync(newMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}