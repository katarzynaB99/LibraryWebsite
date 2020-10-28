namespace AtosLibrary.Application.Features.RegistrationBook
{
    public class RegistrationBookCommand
    {
        public RegistrationBookCommand(string name, string description, int number, string genre,
            string author, int pageNumber, int publicationYear, string publisher)
        {
            Name = name;
            Description = description;
            Number = number;
            Genre = genre;
            Author = author;
            PageNumber = pageNumber;
            PublicationYear = publicationYear;
            Publisher = publisher;
        }

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