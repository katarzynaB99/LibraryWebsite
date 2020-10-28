using System;

namespace AtosLibrary.Domain.Book
{
    public interface IBookFactory
    {
        Book Create(string commandName, string commandDescription, int commandNumber,
            string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher);

        Book Create(int commandId, string commandName, string commandDescription, int commandNumber,
            string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher);

        Book Create(int bookId, IBookRepository bookRepository);

        Book Create(string bookName, IBookRepository bookRepository);
    }
}