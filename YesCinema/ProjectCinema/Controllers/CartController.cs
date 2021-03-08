using ProjectCinema.Dal;
using ProjectCinema.Models;
using ProjectCinema.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCinema.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShoppingCart( int id, itemCartViewModel model)
        {
            string name;
            ItemCartDal itemDal = new ItemCartDal();
            TicketsDal dal = new TicketsDal();
            var item = dal.TicketsList.Where(a => a.ID == id).FirstOrDefault();
            itemCartViewModel mvm = new itemCartViewModel();
            List<ItemCart> cart = new List<ItemCart>();
            mvm.ItemCart = new ItemCart();
            mvm.ITEMS = cart;
            if (Session["cart"] == null)
            {
                //List<ItemCart> cart = new List<ItemCart>();
                mvm.ITEMS.Add(new ItemCart {
                    ID = item.ID,
                    MOVIENAME = item.MOVIENAME,
                    SHOWTIME = item.SHOWTIME,
                    SEAT = item.SEAT,
                    COST=item.COST,
                    Quantity = 1 }) ;
                //itemDal.itemsCart.Add(mvm.ITEMS[index]);
                //index++;
                Session["cart"] = mvm.ITEMS;
            }
            else
            {
                //List<ItemCart> cart = (List<ItemCart>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    //cart[index].Quantity++;
                    mvm.ITEMS[index].Quantity++;
                }
                else
                {
                    mvm.ITEMS.Add(new ItemCart
                    {
                        ID = item.ID,
                        MOVIENAME = item.MOVIENAME,
                        SHOWTIME = item.SHOWTIME,
                        SEAT = item.SEAT,
                        COST = item.COST,
                        Quantity = 1
                    });
                }
                Session["cart"] = mvm;
            }
            return View(mvm);


        }

        [HttpPost]
        public ActionResult ShoppingCart(itemCartViewModel mvm)
        {
            itemCartViewModel test = new itemCartViewModel();
            test = mvm;
            //TicketsDal dal = new TicketsDal();
            if (ModelState.IsValid)
            {
                return View(mvm);
            }
            else

                return View("MovieGallery");
        }

        public ActionResult Remove(int id)
        {
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TicketsDal dal = new TicketsDal();

            var item = dal.TicketsList.Where(a => a.ID == id).FirstOrDefault();
            MovieDal dal2 = new MovieDal();
            var item2 = dal2.MOVIES.Where(a => a.name == item.MOVIENAME && a.showtime == item.SHOWTIME).FirstOrDefault();
            dal.TicketsList.Remove(item);
            dal.SaveChanges();
            return RedirectToAction("~/Home/SeatGalleryUser", new { id = item2.ID });

        }


        private int isExist(int id)
        {
            /*List<ItemCart> cart = (List<ItemCart>)Session["cart"];*/
           // itemCartViewModel mvm = new itemCartViewModel();
            List<ItemCart> cart = (List<ItemCart>)Session["cart"];
           // mvm.ItemCart = new ItemCart();
           // mvm.ITEMS = cart;
            for (int i = 0; i <cart.Count; i++)
                if (cart[i].ID.Equals(id))
                    return i;
            return -1;
        }
    }
}