using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AtosLibrary.Application.Infrastructure;
using AtosLibrary.Domain.Record;

namespace AtosLibrary.Application.Features.ReturnBook
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand>
    {
        private readonly IRecordRepository _recordRepository;

        public ReturnBookCommandHandler(IRecordRepository recordRepository) =>
            _recordRepository = recordRepository;

        public void Handle(ReturnBookCommand command)
        {
            var record = _recordRepository.Get(command.RecordId);
            record.Status = "Returned";
            record.RentEnd = DateTime.Today;

            _recordRepository.Edit(record);
        }
    }
}
