using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Bookstore.Controllers
{
    public class CartController : Controller
    {
        BookstoreEntities db = new BookstoreEntities();
        // GET: Cart
        public ActionResult cart()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["Cart"] == null)
            {
                List<Cart> IsCart = new List<Cart>
                {
                 new Cart(db.RecommendBooks.Find(id),1)

                };
                Session["Cart"] = IsCart;
            }
            else
            {
                List<Cart> IsCart = (List<Cart>)Session["Cart"];
                int check = IsExistingCheck(id);
                if (check == -1)
                    IsCart.Add(new Cart(db.RecommendBooks.Find(id), 1));

                else
                    IsCart[check].Quantity++;
                //IsCart.Add(new Cart(db.Products.Find(id), 1));
                Session["Cart"] = IsCart;

            }

            return View("cart");
        }

        public int IsExistingCheck(int? id)

        {

            List<Cart> IsCart = (List<Cart>)Session["Cart"];
            for (int i = 0; i < IsCart.Count; i++)
            {
                if (IsCart[i].RecommendBook.Id== id) return i;
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
            List<Cart> IsCart = (List<Cart>)Session["Cart"];
            IsCart.RemoveAt(check);
            return View("Cart");
        }

    }
}