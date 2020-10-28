using System;

namespace AtosLibrary.Presentation.Book
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public string Genre { get; set; } 

        public string Author { get; set; }

        public int PageNumber { get; set; }

        public int PublicationYear { get; set; }

        public string Publisher { get; set; }
    }
}