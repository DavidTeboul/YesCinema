using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;
using ProjectCinema.Dal;
using ProjectCinema.ViewModel;

namespace ProjectCinema.Controllers
{
    public class AdminController : Controller

    {
        public ActionResult GetList()
        {
            using (HallDal db = new HallDal())
            {
                List<Hall> empList = db.Halls.ToList<Hall>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SlideMenu()
        {

            List<MenuItem> list = new List<MenuItem>();

            list.Add(new MenuItem { Link = "Movie/ManageMovie", LinkName = "ManageMovie" });
            list.Add(new MenuItem { Link = "Admin/ManageHall", LinkName = "ManageHall" });
            list.Add(new MenuItem { Link = "Admin/ManageSeat", LinkName = "ManageSeat" });
            list.Add(new MenuItem { Link = "Admin/Admin", LinkName = "Create new worker" });



            return PartialView("SlideMenu", list);
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(Admin obj)

        {
            if (ModelState.IsValid)
            {
                AdminDal AD = new AdminDal();
                AD.Admin.Add(obj);
                AD.SaveChanges();
                return RedirectToAction("SlideMenu", "Admin");

            }
            return View("Admin", obj);
        }

        public ActionResult ManageSeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageSeat(Seat obj)

        {
            if (ModelState.IsValid)
            {
                SeatDal dal = new SeatDal();
                HallDal Haldal = new HallDal();
                if (Haldal.Halls.Where(s => s.IDHall.Equals(obj.Hall)).Count() > 0)
                {
                    dal.Seats.Add(obj);
                    dal.SaveChanges();
                    return View("SlideMenu");

                }
                else
                {
                    return RedirectToAction("ManageSeat");
                }

            }
            return View("SlideMenu");

        }

        public ActionResult ManageHall()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManageHall(Hall obj)

        {
            if (ModelState.IsValid)
            {

                HallDal Haldal = new HallDal();

                Haldal.Halls.Add(obj);
                Haldal.SaveChanges();

                return RedirectToAction("HallGallery");

            }
            return View();
        }


        public ActionResult HallGallery(MovieViewModel model)
        {
            HallDal Halldal = new HallDal();
            HallViewModel mvm = new HallViewModel();
            List<Hall> HALLS = Halldal.Halls.ToList();
            mvm.Hall = new Hall();
            mvm.Halls = HALLS;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult HallGallery()
        {
            HallDal dal = new HallDal();
            if (ModelState.IsValid)
            {
                var data = dal.Halls.ToList();
                return View();
            }
            else

                return View("Admin/HallGallery");
        }

        [HttpGet]
        public ActionResult Save(string id)
        {
            using (HallDal dc = new HallDal())
            {
                var v = dc.Halls.Where(a => a.IDHall == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Hall emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (HallDal dc = new HallDal())
                {
                    if (emp.IDHall != null)
                    {
                        //Edit 
                        var v = dc.Halls.Where(a => a.IDHall == emp.IDHall).FirstOrDefault();
                        if (v != null)
                        {

                            v.NumberOfseat = emp.NumberOfseat;
                        }
                    }
                    else
                    {
                        //Save
                        dc.Halls.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("HallGallery");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (HallDal dc = new HallDal())
            {
                var v = dc.Halls.Where(a => a.IDHall == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMovie(string id)
        {

            using (HallDal dc = new HallDal())
            {
                var v = dc.Halls.Where(a => a.IDHall == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Halls.Remove(v);
                    dc.SaveChanges();
                    return View("HallGallery");

                }
            }
            return View("HallGallery");
        }

        public ActionResult GetListSeat()
        {
            using (SeatDal db = new SeatDal())
            {
                List<Seat> empList = new List<Seat>();
                for (int i = 0; i < db.Seats.ToList<Seat>().Count(); i++)
                {
                    if (db.Seats.ToList<Seat>()[i].reserve == false)
                    {
                        empList.Add(db.Seats.ToList<Seat>()[i]);
                    }

                }
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}