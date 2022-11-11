using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryMangmentEF.Models
{
   public class BookInventory
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public BookInventory(int bookId,string bookname ,decimal price, int quantity, string author)
        {
            BookId = bookId;
            Price = price;
            Quantity = quantity;
            Author = author;
            BookName=bookname;
        }
        public BookInventory()
        {

        }
    }
}
