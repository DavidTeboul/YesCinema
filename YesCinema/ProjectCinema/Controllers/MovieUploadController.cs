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
    public class MovieUploadController : Controller
    {
        // GET: ImageUpload
        public ActionResult NewMovie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFiles(Movie MyMovie,HttpPostedFileBase moviePicture)
        { 
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
            
                    MovieDal dal = new MovieDal();
                    MyMovie.moviePicture = moviePicture.FileName;
                    dal.MOVIES.Add(MyMovie);
                    dal.SaveChanges();
               
                }
                try
                {

                    //Method 2 Get file details from HttpPostedFileBase class    

                    if (moviePicture != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(moviePicture.FileName));
                        moviePicture.SaveAs(path);
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }
            return RedirectToAction("NewMovie");
        }

    }
}
