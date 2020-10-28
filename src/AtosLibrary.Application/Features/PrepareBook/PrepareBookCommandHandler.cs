using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Record;

namespace AtosLibrary.Application.Features.PrepareBook
{
    public class PrepareBookCommandHandler : ICommandHandler<PrepareBookCommand>
    {
        private readonly IRecordRepository _recordRepository;

        public PrepareBookCommandHandler(IRecordRepository recordRepository) =>
            _recordRepository = recordRepository;

        public void Handle(PrepareBookCommand command)
        {
            var record = _recordRepository.Get(command.RecordId);
            record.Status = "In preparation";

            _recordRepository.Edit(record);
        }
    }
}
