using BookInventoryMangmentEF.Context;
using BookInventoryMangmentEF.Repositories;
using BookInventoryMangmentEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcBookInventoryMangment.Models
{
    public class BookInventoryViewModel
    {
        private BookInventoryRepository _repo;

        public List<BookInventory> BooklList { get; set; }

        public BookInventory CurrentBook { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public BookInventoryViewModel(BookInventroyDbContext context)
        {
            _repo = new BookInventoryRepository(context);
            BooklList = GetAllBooks();
            CurrentBook = BooklList.FirstOrDefault();
        }

        public BookInventoryViewModel(BookInventroyDbContext context, int bookId)
        {
            _repo = new BookInventoryRepository(context);
            BooklList = GetAllBooks();

            if (bookId > 0)
            {
                CurrentBook = GetBook(bookId);
            }
            else
            {
                CurrentBook = new BookInventory();
            }
        }

        public void SaveAccount(BookInventory book)
        {
            if (book.BookId > 0)
            {
                _repo.Update(book);
            }
            else
            {
                book.BookId = _repo.Create(book);
            }

            BooklList = GetAllBooks();
            CurrentBook = GetBook(book.BookId);
        }

        public void RemoveBrand(int bookId)
        {
            _repo.Delete(bookId);
            BooklList = GetAllBooks();
            CurrentBook = BooklList.FirstOrDefault();
        }

        public List<BookInventory> GetAllBooks()
        {
            return _repo.GetAllBooks();
        }

        public BookInventory GetBook(int bookId)
        {
            return _repo.GetBookById(bookId);
        }
    }
}

