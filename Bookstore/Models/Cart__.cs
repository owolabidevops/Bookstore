using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Models
{
    public class Cart__
    {
        public RecentBook RecentBook { get; set; }
        public int Quantity { get; set; }
        public Cart__(RecentBook recentBook, int quantity)
        {
            RecentBook = recentBook;
            Quantity = quantity;
        }
    }
    }