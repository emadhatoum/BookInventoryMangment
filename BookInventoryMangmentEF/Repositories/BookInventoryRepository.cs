using BookInventoryMangmentEF.Context;
using BookInventoryMangmentEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryMangmentEF.Repositories
{
    public class BookInventoryRepository
    {
        private BookInventroyDbContext _dbContext;

        public BookInventoryRepository(BookInventroyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(BookInventory book)
        {

            _dbContext.Add(book);
            _dbContext.SaveChanges();

            return (int)book.BookId;
        }

        public int Update(BookInventory book)
        {
            BookInventory existingBook = _dbContext.BookInventory.Find(book.BookId);

            existingBook.BookId = book.BookId;
            existingBook.Price = book.Price;
            existingBook.Author=book.Author;
            existingBook.Quantity=book.Quantity;
            existingBook.BookName=book.BookName;

            _dbContext.SaveChanges();

            return (int)existingBook.BookId;
        }

        public bool Delete(int brandId)
        {
            BookInventory book = _dbContext.BookInventory.Find(brandId);
            _dbContext.Remove(book);
            _dbContext.SaveChanges();

            return true;
        }

        public List<BookInventory> GetAllBooks()
        {
            List<BookInventory> brandsList = _dbContext.BookInventory.ToList();

            return brandsList;
        }

        public BookInventory GetBookById(int bookID)
        {
            BookInventory book = _dbContext.BookInventory.Find(bookID);

            return book;
        }
    }
}
