using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Record;

namespace AtosLibrary.Application.Features.ReadyBook
{
    public class ReadyBookCommandHandler : ICommandHandler<ReadyBookCommand>
    {
        private readonly IRecordRepository _recordRepository;

        public ReadyBookCommandHandler(IRecordRepository recordRepository) =>
            _recordRepository = recordRepository;


        public void Handle(ReadyBookCommand command)
        {
            var record = _recordRepository.Get(command.RecordId);
            record.Status = "Ready";

            _recordRepository.Edit(record);
        }
    }
}
