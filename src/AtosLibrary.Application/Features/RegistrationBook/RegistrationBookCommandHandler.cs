using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Application.Features.RegistrationBook
{
    public class RegistrationBookCommandHandler : ICommandHandler<RegistrationBookCommand>
    {
        private readonly IBookFactory _bookFactory;
        private readonly IBookRepository _bookRepository;

        public RegistrationBookCommandHandler(IBookFactory bookFactory, IBookRepository bookRepository)
        {
            _bookFactory = bookFactory;
            _bookRepository = bookRepository;
        }

        public void Handle(RegistrationBookCommand command)
        {
            var book = _bookFactory.Create(command.Name, command.Description, command.Number,
                command.Genre, command.Author, command.PageNumber, command.PublicationYear,
                command.Publisher);
            book.Register(_bookRepository);
        }
    }
}