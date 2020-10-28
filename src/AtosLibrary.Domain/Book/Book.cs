using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Record;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Book
{
    public class Book
    {
        private readonly int _commandId;
        private readonly string _commandName;
        private readonly string _commandDescription;
        private readonly int _commandNumber;
        private readonly string _commandGenre;
        private readonly string _commandAuthor;
        private readonly int _commandPageNumber;
        private readonly int _commandPublicationYear;
        private readonly string _commandPublisher;

        internal Book(string bookName, IBookRepository bookRepository)
        {
            _commandName = bookName;

            var result = bookRepository.GetByName(_commandName);

            _commandId = result.Id;
            _commandDescription = result.Description;
            _commandNumber = result.Number;
            _commandGenre = result.Genre;
            _commandAuthor = result.Author;
            _commandPageNumber = result.PageNumber;
            _commandPublicationYear = result.PublicationYear;
            _commandPublisher = result.Publisher;
        }

        internal Book(int bookCommandId, IBookRepository bookRepository)
        {
            _commandId = bookCommandId;
            var result = bookRepository.Get(bookCommandId);
            _commandName = result.Name;
            _commandDescription = result.Description;
            _commandNumber = result.Number;
            _commandGenre = result.Genre;
            _commandAuthor = result.Author;
            _commandPageNumber = result.PageNumber;
            _commandPublicationYear = result.PublicationYear;
            _commandPublisher = result.Publisher;
        }

        internal Book(string commandName, string commandDescription, int commandNumber,
            string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher)
        {
            _commandName = commandName;
            _commandDescription = commandDescription;
            _commandNumber = commandNumber;
            _commandGenre = commandGenre;
            _commandAuthor = commandAuthor;
            _commandPageNumber = commandPageNumber;
            _commandPublicationYear = commandPublicationYear;
            _commandPublisher = commandPublisher;
        }

        internal Book(int commandId, string commandName, string commandDescription,
            int commandNumber, string commandGenre, string commandAuthor, int commandPageNumber,
            int commandPublicationYear, string commandPublisher)
        {
            _commandId = commandId;
            _commandName = commandName;
            _commandDescription = commandDescription;
            _commandNumber = commandNumber;
            _commandGenre = commandGenre;
            _commandAuthor = commandAuthor;
            _commandPageNumber = commandPageNumber;
            _commandPublicationYear = commandPublicationYear;
            _commandPublisher = commandPublisher;
        }

        public void Register(IBookRepository bookRepository)
        {
            bookRepository.Add(new BookDto
            {
                Id = _commandId,
                Name = _commandName,
                Description = _commandDescription,
                Number = _commandNumber,
                Genre = _commandGenre,
                Author = _commandAuthor,
                PageNumber = _commandPageNumber,
                PublicationYear = _commandPublicationYear,
                Publisher = _commandPublisher
            });
        }

        public void Edit(IBookRepository bookRepository)
        {
            bookRepository.Edit(new BookDto
            {
                Id = _commandId,
                Name = _commandName,
                Description = _commandDescription,
                Number = _commandNumber,
                Genre = _commandGenre,
                Author = _commandAuthor,
                PageNumber = _commandPageNumber,
                PublicationYear = _commandPublicationYear,
                Publisher = _commandPublisher
            });
        }

        public void Reserve(int readerId, IBookRepository bookRepository,
            IReaderRepository readerRepository, IRecordRepository recordRepository)
        {
            var readerRecords = recordRepository.GetAll()
                .Where(x =>
                    x.BookId == _commandId && x.ReaderId == readerId &&
                    (x.Status.Equals("New") || x.Status.Equals("In preparation") ||
                     x.Status.Equals("Rented"))).ToList();
            if (!readerRecords.Any())
            {
                var bookRecords = recordRepository.GetAll().Where(x =>
                    x.BookId == _commandId &&
                    (x.Status.Equals("New") || x.Status.Equals("In preparation") ||
                     x.Status.Equals("Rented")));
                if (bookRecords.Count() >= _commandNumber)
                {
                    throw  new Exception("All copies are reserved or rented. Please try later");
                }
                else
                {
                    //rent book
                    recordRepository.Add(new RecordDto
                    {
                        BookId = _commandId,
                        ReaderId = readerId,
                        Status = "New"
                    });
                }
            }
            else
            {
                throw new Exception("Is reserved by this reader");
            }
        }

        //public void Reserve(Guid readerId, IBookRepository bookRepository)
        //{
        //    if (_commandReaders.Contains(readerId))
        //    {
        //        throw new Exception("Is reserved by you.");
        //    }

        //    if (_commandNumber == _commandReaders.Count)
        //    {
        //        throw new Exception("All copies are reserved or rented. Please try later.");
        //    }

        //    _commandReaders.Add(readerId);

        //    bookRepository.UpdateReservation(_commandId, _commandReaders);
        //}
    }
}