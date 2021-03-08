using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using ProjectCinema.Dal;
using System.Data.Entity;
using System.IO;



namespace ProjectCinema.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult BookingSeat()
        {
            return View();
        }

        public ActionResult GetImage(string id)
        {
            var dir = Server.MapPath("/Content/Images");
            var path = Path.Combine(dir, id + ".jpg");
            return base.File(path, "image/jpeg");
        }

        public ActionResult MovieGallery(MovieViewModel model)
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult MovieGallery()
        {
            MovieDal dal = new MovieDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else

                return View("MovieGallery");
        }


        public ActionResult BookTicket(string idSeat)
        {
            /*TicketsDal dal = new TicketsDal();
            MovieDal movieDal = new MovieDal();
            TicketsViewModel mvm = new TicketsViewModel();
            var item = movieDal.MOVIES.Where(a => a.ID == id).FirstOrDefault(); ;
            List<Tickets> tickets = dal.TicketsList.ToList();
            mvm.Tickets = new Tickets();
            mvm.TicketsList = tickets;
            return View(mvm);*/
            Tickets mvm = new Tickets();
            ItemCart itemCart = new ItemCart();
            MovieDal dal = new MovieDal();
            SeatDal seatDal = new SeatDal();
            var itemSeat2 = seatDal.Seats.Where(a => a.IdSeat == idSeat).FirstOrDefault();
            var itemsMovie3 = dal.MOVIES.Where(a => a.SALLE == itemSeat2.Hall && a.showtime == itemSeat2.date).FirstOrDefault();

            //var item = dal.MOVIES.Where(a => a.ID == itemsMovie3.ID).FirstOrDefault();
            //var itemSeat = seatDal.Seats.Where(a => a.IdSeat == id).FirstOrDefault();
            mvm.MOVIENAME = itemsMovie3.name;
            mvm.SHOWTIME = itemsMovie3.showtime;
            mvm.COST = itemsMovie3.price;
            mvm.SEAT = itemSeat2.Number;


            return View(mvm);
        }

        [HttpPost]
        public ActionResult BookTicket(Tickets obj)
        {
           
            if (ModelState.IsValid)
            {

                TicketsDal dal = new TicketsDal();
                //MovieDal movieDal = new MovieDal();
                SeatDal seatDal = new SeatDal();
                if (seatDal.Seats.Where(s => s.Number.Equals(obj.SEAT)).Count()>0)
                {
                    //var data = dal.TicketsList.ToList();
                    dal.TicketsList.Add(obj);
                    dal.SaveChanges();
                    return View("DetailsTickets",obj) ;            
                }
                else
                {
                    return RedirectToAction("BookTicket");
                }

            }
            return View("MovieGallery");

        }

        public ActionResult DetailsTickets()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult DetailsTickets(ItemCart obj)
        {   
            if (ModelState.IsValid)
            {
                ItemCartDal itemDal = new ItemCartDal();
                /*if (itemDal.itemsCart.Where(s => s.MOVIENAME.Equals(obj.MOVIENAME) && s.SHOWTIME.Equals(obj.SHOWTIME)).Count() > 0)
                {
                    itemDal.itemsCart
                }*/
                //var data = dal.itemsCart.ToList();
                //return View();
                itemDal.itemsCart.Add(obj);
                itemDal.SaveChanges();
                return View("ShoppingCart","Cart");
            }

           return View();

        }

        [HttpGet]
        public ActionResult SeatGalleryUser(string id)
        {
            SeatDal dal = new SeatDal();
            MovieDal dal2 = new MovieDal();
            userSeatViewModel mvm2 = new userSeatViewModel();
            SeatViewModel mvm = new SeatViewModel();
            List<Seat> Seatss = new List<Seat>();
            var item = dal2.MOVIES.Where(a => a.ID == id).FirstOrDefault();
            for (int i = 0; i < dal.Seats.ToList().Count(); i++)
            {
                if (dal.Seats.ToList()[i].Hall == item.SALLE && dal.Seats.ToList()[i].date == item.showtime)
                {
                    Seatss.Add(dal.Seats.ToList()[i]);
                }

            }
            mvm2.Seat = new Seat();
            mvm2.Seats = Seatss;
            return View(mvm2);
        }

        [HttpPost]
        public ActionResult SeatGalleryUser()
        {
            SeatDal dal = new SeatDal();
            if (ModelState.IsValid)
            {
                var data = dal.Seats.ToList();
                return View();
            }
            else

                return View("Home/MovieGallery");
        }

        [HttpGet]
        public ActionResult Reserve(string id)
        {
            using (SeatDal dc = new SeatDal())
            {
                var v = dc.Seats.Where(a => a.IdSeat == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Reserve(Seat emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (SeatDal dc = new SeatDal())
                {
                    if (emp.IdSeat != null && emp.reserve==false)
                    {
                        //Edit 
                        var v = dc.Seats.Where(a => a.IdSeat == emp.IdSeat).FirstOrDefault();
                        if (v != null)
                        {

                            v.reserve = true;
                        }
                    }
                    else
                    {
                        //Save
                        return View("AlreadyOccuped");
                    }
                    dc.SaveChanges();
                    
                    status = true;

                    MovieDal dal2 = new MovieDal();
                    var item = dal2.MOVIES.Where(a => a.SALLE == emp.Hall && a.showtime == emp.date).FirstOrDefault();
                    //return View("BookTicket");

                    return RedirectToAction("BookTicket",new { idSeat = emp.IdSeat });

                }
            }
            return new JsonResult { Data = new { status = status } };
        }

    }




}
