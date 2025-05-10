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
    }
}
