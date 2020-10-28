using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Application.Features.EditReader
{
    public class EditReaderCommandHandler : ICommandHandler<EditReaderCommand>
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IReaderFactory _readerFactory;

        public EditReaderCommandHandler(IReaderRepository readerRepository, IReaderFactory readerFactory)
        {
            _readerRepository = readerRepository;
            _readerFactory = readerFactory;
        }

        public void Handle(EditReaderCommand command)
        {
            var reader = _readerFactory.Create(command.ReaderId, command.Name, command.Surname,
                command.Gender, command.Birthday, command.Email, command.PhoneNumber,
                command.Country, command.City);
            reader.Edit(_readerRepository);
        }
    }
}
