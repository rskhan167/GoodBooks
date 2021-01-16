namespace GoodBooks.Data.Models
{
    using System;

    public class Book
    {
        public int BookId { get; set; }
        
        public string Title { get; set; }
        
        public string BookAuthor { get; set; }
        
        public decimal Price { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
