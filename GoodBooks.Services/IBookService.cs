namespace GoodBooks.Services
{
    using System.Collections.Generic;
    using Data.Models;

    public interface IBookService
    {
         public Book GetBook(int bookId);
         
         public void AddBook(Book book);
         
         public void DeleteBook(int bookId);

         public List<Book> GetAllBooks(); 
    }
}
