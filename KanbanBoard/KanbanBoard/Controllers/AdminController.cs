using KanbanBoard.Data;
using KanbanBoard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<KanbanBoardUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<KanbanBoardUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index()
        {
            var kanbanBoarcdUsers = _context.KanbanBoardUsers;
            return View(await kanbanBoarcdUsers.ToListAsync());
        }

  
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.KanbanBoardUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.KanbanBoardUsers.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user); // Delete user
                // Search for all projects owned by the user and delete them
                var projects = _context.Projects
                    .Include(p => p.KanbanBoardUser)
                    .Where(p => p.ProjectOwnerId == user.Id)
                    .ToList();
                _context.Projects.RemoveRange(projects); 
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
