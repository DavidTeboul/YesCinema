using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectCinema.Models;
using System.Security.Cryptography;
using ProjectCinema.Dal;


namespace ProjectCinema.Controllers
{
    public class RegistrationController : Controller
    {
        public object WebSecurity { get; private set; }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)


        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                AdminDal addal = new AdminDal();
                if (dal.Users.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).Count() > 0)
                {
                    //add session
                    Session["USERNAME"] = dal.Users.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).FirstOrDefault().USERNAME;
                    Session["PASSWORD"] = dal.Users.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).FirstOrDefault().PASSWORD;
                    return RedirectToAction("Home", "Home");
                }
                else if (addal.Admin.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).Count() > 0)
                {
                    Session["USERNAME"] = addal.Admin.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).FirstOrDefault().USERNAME;
                    Session["PASSWORD"] = addal.Admin.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).FirstOrDefault().PASSWORD;
                    return RedirectToAction("SlideMenu", "Admin");
                }
            }

            return View();
        }
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User obj)

        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                dal.Users.Add(obj);
                dal.SaveChanges();
                return View("Login");

            }
            return View();
        }


        // Post: /Account/ForgotPassword

        [HttpGet]
        public ActionResult ForgetPassWord(string dt)
        {
            using (UserDal dc = new UserDal())
            {
                var v = dc.Users.Where(a => a.USERNAME == dt).FirstOrDefault();
                return View(v);
            }
        }

        [HttpPost]
        public ActionResult ForgetPassWord(User userT)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (UserDal dc = new UserDal())
                {
                    if (userT.USERID != null)
                    {
                        //Edit 
                        var v = dc.Users.Where(a => a.USERID == userT.USERID).FirstOrDefault();
                        if (v != null)
                        {
                            v.PASSWORD = userT.PASSWORD;
                            v.CONFIRMPASS = userT.CONFIRMPASS;

                        }
                    }
                    else
                    {
                        //Save
                        dc.Users.Add(userT);
                    }
                    dc.SaveChanges();
                    status = true;
                    return View("Login");

                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}