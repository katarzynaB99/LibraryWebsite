using System;

namespace AtosLibrary.Domain.Book
{
    public class BookFactory : IBookFactory
    {
        public Book Create(string commandName, string commandDescription, int commandNumber,
            string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher)
        {
            return new Book(commandName, commandDescription, commandNumber, commandGenre,
                commandAuthor, commandPageNumber, commandPublicationYear, commandPublisher);
        }

        public Book Create(int commandId, string commandName, string commandDescription,
            int commandNumber, string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher)
        {
            return new Book(commandId, commandName, commandDescription, commandNumber, commandGenre,
                commandAuthor, commandPageNumber, commandPublicationYear, commandPublisher);
        }

        public Book Create(int bookId, IBookRepository bookRepository)
        {
            return new Book(bookId, bookRepository);
        }

        public Book Create(string bookName, IBookRepository bookRepository)
        {
            return new Book(bookName, bookRepository);
        }
    }
}