using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Record;

namespace AtosLibrary.Application.Features.RentBook
{
    public class RentBookCommandHandler : ICommandHandler<RentBookCommand>
    {
        private readonly IRecordRepository _recordRepository;

        public RentBookCommandHandler(IRecordRepository recordRepository) =>
            _recordRepository = recordRepository;

        public void Handle(RentBookCommand command)
        {
            var record = _recordRepository.Get(command.RecordId);
            record.Status = "Rented";
            record.RentStart = DateTime.Today;
            record.RentEnd = DateTime.Today.AddMonths(6);

            _recordRepository.Edit(record);
        }
    }
}
