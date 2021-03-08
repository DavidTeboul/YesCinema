using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectCinema.Dal;
using ProjectCinema.Models;

namespace ProjectCinema.ViewModel
{
    public class TicketsViewModel
    {
        public Tickets Tickets { get; set; }
        public List<Tickets> TicketsList { get; set; }

        public List<Tickets> findAll()
        {
            return this.TicketsList;
        }
        public Tickets find(string id)
        {
            return this.TicketsList.Single(p => p.ID.Equals(id));
        }
    }
}