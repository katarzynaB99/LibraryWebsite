using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Record
{
    public class Record
    {
        private readonly int _id;
        private readonly int _commandReaderId;
        private readonly int _commandBookId;
        private readonly string _commandStatus;
        private readonly DateTime? _commandRentStart;
        private readonly DateTime? _commandRentEnd;

        internal Record(int commandReaderId, int commandBookId)
        {
            _commandReaderId = commandReaderId;
            _commandBookId = commandBookId;
            _commandStatus = "Waiting for action";
        }

        internal Record(int commandReaderId, int commandBookId, string commandStatus,
            DateTime commandRentStart, DateTime commandRentEnd)
        {
            _commandReaderId = commandReaderId;
            _commandBookId = commandBookId;
            _commandStatus = commandStatus;
            _commandRentStart = commandRentStart;
            _commandRentEnd = commandRentEnd;
        }

        internal Record(int commandId, int commandReaderId, int commandBookId, string commandStatus)
        {
            _id = commandId;
            _commandReaderId = commandReaderId;
            _commandBookId = commandBookId;
            _commandStatus = commandStatus;
        }

        public void Edit(IRecordRepository recordRepository)
        {
            recordRepository.Add(new RecordDto
            {
                RecordId = _id,
                ReaderId = _commandReaderId,
                BookId = _commandBookId,
                Status = _commandStatus,
                RentStart = _commandRentStart,
                RentEnd = _commandRentEnd
            });
        }

        public void Register(IRecordRepository recordRepository)
        {
            recordRepository.Edit(new RecordDto
            {
                RecordId = _id,
                BookId = _commandBookId,
                ReaderId = _commandReaderId,
                Status = _commandStatus,
                RentStart = _commandRentStart,
                RentEnd = _commandRentEnd
            });
        }
    }
}
