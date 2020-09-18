using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class CarttController : Controller
    {
        BookstoreEntities db = new BookstoreEntities();
        // GET: Cartt
        public ActionResult cartt()
        {
            return View();
        }
        public ActionResult OrderNow1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["Cart"] == null)
            {
                List<Cart__> IsCart = new List<Cart__>
                {
                 new Cart__(db.RecentBooks.Find(id),1)

                };
                Session["Cart"] = IsCart;
            }
            else
            {
                List<Cart__> IsCart = (List<Cart__>)Session["Cart"];
                int check = IsExistingCheck(id);
                if (check == -1)
                    IsCart.Add(new Cart__(db.RecentBooks.Find(id), 1));

                else
                    IsCart[check].Quantity++;
                //IsCart.Add(new Cart(db.Products.Find(id), 1));
                Session["Cart"] = IsCart;

            }

            return View("cartt");
        }

        public int IsExistingCheck(int? id)

        {

            List<Cart__> IsCart = (List<Cart__>)Session["Cart"];
            for (int i = 0; i < IsCart.Count; i++)
            {
                if (IsCart[i].RecentBook.Id == id) return i;
            }


            return -1;

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            int check = IsExistingCheck(id);
            List<Cart__> IsCart = (List<Cart__>)Session["Cart"];
            IsCart.RemoveAt(check);
            return View("cartt");
        }

    }
}