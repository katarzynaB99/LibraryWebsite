using System;

namespace AtosLibrary.Application.Features.EditBook
{
    public class EditBookCommand
    {
        public EditBookCommand(int bookId, string name, string description, int number,
            string genre, string author, int pageNumber, int publicationYear, string publisher)
        {
            BookId = bookId;
            Name = name;
            Description = description;
            Number = number;
            Genre = genre;
            Author = author;
            PageNumber = pageNumber;
            PublicationYear = publicationYear;
            Publisher = publisher;
        }

        public int BookId { get; set; }

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
