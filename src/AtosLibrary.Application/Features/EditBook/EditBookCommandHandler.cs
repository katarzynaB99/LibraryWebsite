using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Application.Features.EditBook
{
    public class EditBookCommandHandler : ICommandHandler<EditBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFactory _bookFactory;

        public EditBookCommandHandler(IBookRepository bookRepository, IBookFactory bookFactory)
        {
            _bookRepository = bookRepository;
            _bookFactory = bookFactory;
        }

        public void Handle(EditBookCommand command)
        {
            var book = _bookFactory.Create(command.BookId, command.Name, command.Description,
                command.Number, command.Genre, command.Author, command.PageNumber,
                command.PublicationYear, command.Publisher);
            book.Edit(_bookRepository);
        }
    }
}
