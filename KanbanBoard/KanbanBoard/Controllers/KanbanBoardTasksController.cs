using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KanbanBoard.Data;
using KanbanBoard.Models;
using Microsoft.AspNetCore.Identity;

namespace KanbanBoard.Controllers
{
    public class KanbanBoardTasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<KanbanBoardUser> _userManager;

        public KanbanBoardTasksController(ApplicationDbContext context, UserManager<KanbanBoardUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: KanbanBoardTasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KanbanBoardTasks.Include(k => k.KanbanBoardUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KanbanBoardTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanbanBoardTask = await _context.KanbanBoardTasks
                .Include(k => k.KanbanBoardUser)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (kanbanBoardTask == null)
            {
                return NotFound();
            }

            return View(kanbanBoardTask);
        }

        // GET: KanbanBoardTasks/Create
        public IActionResult Create()
        {
            ViewData["TaskAssignedUserId"] = new SelectList(_context.Users, "Id", "Id");
            var userId = _userManager.GetUserId(User);
            var kanbanBoardTask = new KanbanBoardTask
            {
                TaskAssignedUserId = userId
            };
            return View(kanbanBoardTask);
        }

        // POST: KanbanBoardTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,TaskDescription,TaskAssignedUserId")] KanbanBoardTask kanbanBoardTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kanbanBoardTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskAssignedUserId"] = new SelectList(_context.Users, "Id", "Id", kanbanBoardTask.TaskAssignedUserId);
            return View(kanbanBoardTask);
        }

        // GET: KanbanBoardTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanbanBoardTask = await _context.KanbanBoardTasks.FindAsync(id);
            if (kanbanBoardTask == null)
            {
                return NotFound();
            }
            ViewData["TaskAssignedUserId"] = new SelectList(_context.Users, "Id", "Id", kanbanBoardTask.TaskAssignedUserId);
            return View(kanbanBoardTask);
        }

        // POST: KanbanBoardTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,TaskDescription,TaskAssignedUserId")] KanbanBoardTask kanbanBoardTask)
        {
            if (id != kanbanBoardTask.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kanbanBoardTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KanbanBoardTaskExists(kanbanBoardTask.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskAssignedUserId"] = new SelectList(_context.Users, "Id", "Id", kanbanBoardTask.TaskAssignedUserId);
            return View(kanbanBoardTask);
        }

        // GET: KanbanBoardTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kanbanBoardTask = await _context.KanbanBoardTasks
                .Include(k => k.KanbanBoardUser)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (kanbanBoardTask == null)
            {
                return NotFound();
            }

            return View(kanbanBoardTask);
        }

        // POST: KanbanBoardTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kanbanBoardTask = await _context.KanbanBoardTasks.FindAsync(id);
            if (kanbanBoardTask != null)
            {
                _context.KanbanBoardTasks.Remove(kanbanBoardTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KanbanBoardTaskExists(int id)
        {
            return _context.KanbanBoardTasks.Any(e => e.TaskId == id);
        }
    }
}
