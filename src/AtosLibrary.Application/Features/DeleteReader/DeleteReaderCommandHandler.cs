using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Reader;

namespace AtosLibrary.Application.Features.DeleteReader
{
    public class DeleteReaderCommandHandler : ICommandHandler<DeleteReaderCommand>
    {
        private readonly IReaderRepository _readerRepository;
        public DeleteReaderCommandHandler(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public void Handle(DeleteReaderCommand command)
        {
            _readerRepository.Delete(command.ReaderId);
        }
    }
}
