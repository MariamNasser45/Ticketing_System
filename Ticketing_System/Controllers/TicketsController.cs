using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Exchange.WebServices.Data;
using System.Data;
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
        private readonly UserManager<IdentityUser> userManager;

        public TicketsController(ApplicationDbContext context, ITicket ticket , ICategory category , ISeverity severity,IStatus status,UserManager<IdentityUser> userManager)
        {
            Context = context;
            this.Ticket = ticket;
            this.category = category;
            this.severity = severity;
            this.status = status;
            this.userManager = userManager;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            if(User.IsInRole("Reporter"))
            {
                return View(Ticket.GetAllForUser(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            }
            else if (User.IsInRole("Technician"))
            {
                return View(Ticket.GetByStatus(2));

            }
            else if (User.IsInRole("Manager"))
            {
                return View(Ticket.GetByStatus(1));
                //return View();

            }
            else
                return View("/Home"); 
        }


        // GET: Tickets/Details/5
        public ActionResult Details(int id)
        {
            return View(Ticket.GetById(id));
        }

        // GET: Tickets/Create
        [Authorize(Roles = "Reporter")]
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(category.GetAll(),"CategoryId","CategoryName");
            ViewBag.status = new SelectList(status.GetAll(), "StatusId", "StatusName");
            ViewBag.severity = new SelectList(severity.GetAll(), "SeverityId", "SeverityName");

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
                Details(ticket.TicketId);
                return View("Details");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Tickets/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.category = new SelectList(category.GetAll(), "CategoryId", "CategoryName");
            ViewBag.status = new SelectList(status.GetAll(), "StatusId", "StatusName");
            ViewBag.Mstatus = new SelectList(status.GetAllForMan(), "StatusId", "StatusName");
            ViewBag.severity = new SelectList(severity.GetAll(), "SeverityId", "SeverityName");
            
            return View(Ticket.GetById(id));
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                ticket.LastUpdatedBy = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Ticket.Update(ticket);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles ="Reporter")]
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
