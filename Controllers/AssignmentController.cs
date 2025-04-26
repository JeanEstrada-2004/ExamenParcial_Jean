using Microsoft.AspNetCore.Mvc;
using ExamenParcial_Jean.Data;
using ExamenParcial_Jean.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenParcial_Jean.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Assignment/Asociar
        public IActionResult Asociar()
        {
            ViewBag.Players = _context.Players.ToList();
            ViewBag.Teams = _context.Teams.ToList();

            var asociaciones = _context.Assignments
                .Include(a => a.Player)
                .Include(a => a.Team)
                .ToList();

            return View(asociaciones); // ← esto manda la lista a la vista
        }


        // POST: /Assignment/Asociar
        [HttpPost]
        public IActionResult Asociar(int playerId, int teamId)
        {
            var existe = _context.Assignments
                .Any(a => a.PlayerId == playerId && a.TeamId == teamId);

            if (!existe)
            {
                var asignacion = new Assignment
                {
                    PlayerId = playerId,
                    TeamId = teamId
                };

                _context.Assignments.Add(asignacion);
                _context.SaveChanges();
            }

            return RedirectToAction("Asociar");
        }

        // GET: /Assignment/Lista
        public IActionResult Lista()
        {
            var data = _context.Assignments
                .Include(a => a.Player)
                .Include(a => a.Team)
                .Select(a => new
                {
                    Jugador = a.Player.Name,
                    Equipo = a.Team.Name
                })
                .ToList();

            return Json(data); // Puedes cambiar a View(data) si prefieres HTML
        }
    }
}
