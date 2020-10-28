using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Application.Features.DeleteBook
{
    public class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Handle(DeleteBookCommand command)
        {
            _bookRepository.Delete(command.BookId);
        }
    }
}
