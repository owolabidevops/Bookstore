using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.Models;
using PagedList;

namespace  Bookstore.Controllers
{
    public class HomeController : Controller
        
    {
        BookstoreEntities db = new BookstoreEntities();
        // GET: Home
        public ActionResult index(int? page)

        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var Recommendlist = db.RecommendBooks.OrderBy(x => x.Id).ToList();
            //var Recommendlist = db.RecommendBooks.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
            var Recentlist = db.RecentBooks.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
            ViewData["recent"] = Recommendlist;

            return View(Recentlist);
        }
    }
}