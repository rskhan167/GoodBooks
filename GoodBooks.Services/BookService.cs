namespace GoodBooks.Services
{
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext DbContext;
        public BookService(GoodBooksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        void IBookService.AddBook(Book book)
        {
            DbContext.Add(book);
            DbContext.SaveChanges();
        }

        void IBookService.DeleteBook(int bookId)
        {
            var bookToDelete = DbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            if (bookToDelete != null)
            {
                DbContext.Remove(bookToDelete);
            }
            throw new InvalidOperationException("Can't delete book that doesn't exists.");
        }

        List<Book> IBookService.GetAllBooks()
        {
            return DbContext.Books.ToList();
        }

        Book IBookService.GetBook(int bookId)
        {
            return DbContext.Books.FirstOrDefault(x => x.BookId == bookId);
        }
    }
}
