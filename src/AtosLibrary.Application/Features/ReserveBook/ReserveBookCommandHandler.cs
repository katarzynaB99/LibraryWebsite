using System;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Domain.Record;

namespace AtosLibrary.Application.Features.ReserveBook
{
    public class ReserveBookCommandHandler : ICommandHandler<ReserveBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactory _bookFactory;
        private readonly IReaderRepository _readerRepository;
        private readonly IReaderFactory _readerFactory;
        private readonly IRecordRepository _recordRepository;

        public ReserveBookCommandHandler(IBookRepository bookRepository, IBookFactory bookFactory,
            IReaderRepository readerRepository, IReaderFactory readerFactory,
            IRecordRepository recordRepository)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
            _readerRepository = readerRepository;
            _readerFactory = readerFactory;
            _recordRepository = recordRepository;
        }

        public void Handle(ReserveBookCommand command)
        {
            var reader = _readerRepository.GetByName(command.ReaderName, command.ReaderSurname);
            var book = _bookFactory.Create(command.BookName, _bookRepository);

            if (reader is null)
            {
                throw new Exception("Reader not found");
            }

            if (book is null)
            {
                throw new Exception("Book not found");
            }

            book.Reserve(reader.Id,_bookRepository, _readerRepository, _recordRepository);
        }
    }
}