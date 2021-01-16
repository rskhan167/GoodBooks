namespace GoodBooks.Data.Models
{
    using System;

    public class BookReview
    {
        public int Id { get; set; }
        
        public string ReviewContent { get; set; }
        
        public string ReviewAuthor { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        public Book Book { get; set; }
    }
}
