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
    public class MovieController : Controller
    {


        public ActionResult GetList()
        {
            using (MovieDal db = new MovieDal())
            {
                List<Movie> empList = db.MOVIES.ToList<Movie>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }


        /*public ActionResult DisplayMovieGallery(MovieViewModel model)
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult DisplayMovieGallery()
        {
            MovieDal dal = new MovieDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else
                return View("Movie");
        }*/


        public ActionResult ManageMovie(MovieViewModel model)
        {
            MovieDal dal = new MovieDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.MOVIES.ToList();
            mvm.Movie = new Movie();
            mvm.Movies = movies;
            return View(mvm);
        }

        [HttpPost]
        public ActionResult ManageMovie()
        {
            MovieDal dal = new MovieDal();
            if (ModelState.IsValid)
            {
                var data = dal.MOVIES.ToList();
                return View();
            }
            else

                return View("Movie/ManageMovie");
        }



        [HttpGet]
        public ActionResult Save(string id)
        {
            using (MovieDal dc = new MovieDal())
            {
                var v = dc.MOVIES.Where(a => a.ID == id).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult Save(Movie emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MovieDal dc = new MovieDal())
                {
                    if (emp.ID != null)
                    {
                        //Edit 
                        var v = dc.MOVIES.Where(a => a.ID == emp.ID).FirstOrDefault();
                        if (v != null)
                        {
                            v.moviePicture = emp.moviePicture;
                            v.name = emp.name;
                            v.price = emp.price;
                            v.SALLE = emp.SALLE;
                            v.showtime = emp.showtime;
                            v.ageLimitation = emp.ageLimitation;
                        }
                    }
                    else
                    {
                        //Save
                        dc.MOVIES.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("ManageMovie");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (MovieDal dc = new MovieDal())
            {
                var v = dc.MOVIES.Where(a => a.ID == id).FirstOrDefault();
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

            using (MovieDal dc = new MovieDal())
            {
                var v = dc.MOVIES.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.MOVIES.Remove(v);
                    dc.SaveChanges();
                    return View("ManageMovie");

                }
            }
            return View("ManageMovie");
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            Movie obj = new Movie();
            obj.Delete(id);
            return RedirectToAction("DisplayMovieGallery");
        }




    }
}









