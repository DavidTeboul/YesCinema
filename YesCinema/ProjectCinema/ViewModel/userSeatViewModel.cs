using ProjectCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCinema.ViewModel
{
    public class userSeatViewModel
    {
        public Seat Seat { get; set; }
        public List<Seat> Seats { get; set; }

    }
}