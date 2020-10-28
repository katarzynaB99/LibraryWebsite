using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AtosLibrary.Domain.Book
{
    public class BookDto
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
