using Microsoft.AspNetCore.Mvc;
using MvcBookInventoryMangment.Controllers;
using BookInventoryMangment.Models;
using BookInventoryMangmentEF;
using BookInventoryMangmentEF.Models;
using BookInventoryMangmentEF.Context;
using MvcBookInventoryMangment.Models;

namespace MvcBookInventoryMangment.Controllers
{
    public class BookInventoryController : Controller
    {
        private readonly BookInventroyDbContext _context;

        public BookInventoryController(BookInventroyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BookInventoryViewModel model = new BookInventoryViewModel(_context);
            return View(model);
        }

        [HttpPost]
        //the comand below from brand.cs
        public IActionResult Index(int bookId,string bookName, decimal price, int quantity, string author)
        {
            BookInventoryViewModel model = new BookInventoryViewModel(_context);

            BookInventory brand = new (bookId,bookName, price,quantity,author);

            model.SaveAccount(brand);
            model.IsActionSuccess = true;
            model.ActionMessage = "Account has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            BookInventoryViewModel model = new BookInventoryViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            BookInventoryViewModel model = new BookInventoryViewModel(_context);

            if (id > 0)
            {
                model.RemoveBrand(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Brand has been deleted successfully";
            return View("Index", model);
        }
    }
}
    

