using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace  Bookstore.Controllers
{
    public class Product_singleController : Controller
    {
        BookstoreEntities db = new BookstoreEntities();
        // GET: Product_single
        public ActionResult product_single(int? id)
        {
            var Recommendlist = db.RecommendBooks.OrderBy(x => x.Id).ToList();
            ViewData["recent"] = Recommendlist;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecommendBook recom = db.RecommendBooks.Find(id);
            if (recom == null)
            {
                return HttpNotFound();
            }
            return View(recom);

           

        }
        public ActionResult product_single_(int? id)
        {
            var Recommendlist = db.RecommendBooks.OrderBy(x => x.Id).ToList();
            ViewData["recent"] = Recommendlist;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecentBook recom = db.RecentBooks.Find(id);
            if (recom == null)
            {
                return HttpNotFound();
            }
            return View(recom);



        }



    }
}