using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Ticketing_System.Data;
using Ticketing_System.Interfaces;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly ITicket Ticket;
        private readonly ICategory category;
        private readonly ISeverity severity;
        private readonly IStatus status;

        public TicketsController(ApplicationDbContext context, ITicket ticket , ICategory category , ISeverity severity,IStatus status)
        {
            Context = context;
            this.Ticket = ticket;
            this.category = category;
            this.severity = severity;
            this.status = status;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            return View(Ticket.GetAll());
        }


        // GET: Tickets/Details/5
        public ActionResult Details(int id)
        {
            
            return View(Ticket.GetById(id));
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(category.GellAll(),"CategoryId","CategoryName");
            ViewBag.status = new SelectList(status.GellAll(), "StatusId", "StatusName");
            ViewBag.severity = new SelectList(severity.GellAll(), "SeverityId", "SeverityName");

            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            try
            {
                ticket.CreatorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Ticket.Insert(ticket);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.category = new SelectList(category.GellAll(), "CategoryId", "CategoryName");
            ViewBag.status = new SelectList(status.GellAll(), "StatusId", "StatusName");
            ViewBag.severity = new SelectList(severity.GellAll(), "SeverityId", "SeverityName");
            return View(Ticket.GetById(id));
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Ticket.GetById(id));
        }

        // POST: Tickets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ticket ticket )
        {
            try
            {
                Ticket.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
