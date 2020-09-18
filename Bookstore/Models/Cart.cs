using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;

namespace Bookstore.Models
{
   
    public class Cart
    {
      
        public RecommendBook RecommendBook { get; set; }
        public int Quantity { get; set; }
        public Cart(RecommendBook recommendBook, int quantity)
        {
            RecommendBook = recommendBook;
            Quantity = quantity;
        }

    }
}