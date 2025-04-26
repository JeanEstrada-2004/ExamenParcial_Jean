using Microsoft.AspNetCore.Mvc;
using ExamenParcial_Jean.Data;
using ExamenParcial_Jean.Models;

namespace ExamenParcial_Jean.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Player/Create
        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        // POST: /Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Teams = _context.Teams.ToList();
            return View(player);
        }
    }
}
