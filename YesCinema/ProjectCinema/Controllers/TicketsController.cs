using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using ProjectCinema.Dal;
using System.Data.Entity;
using System.IO;

namespace ProjectCinema.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayTickets(TicketsViewModel model)
        {
            TicketsDal dal = new TicketsDal();
            TicketsViewModel mvm = new TicketsViewModel();
            List<Tickets> ticketss = dal.TicketsList.ToList();
            mvm.Tickets = new Tickets();
            mvm.TicketsList = ticketss;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult ManageMovie()
        {
            TicketsDal dal = new TicketsDal();
            if (ModelState.IsValid)
            {
                var data = dal.TicketsList.ToList();
                return View();
            }
            else

                return View("Tickets/DisplayTickets");
        }


    }
}