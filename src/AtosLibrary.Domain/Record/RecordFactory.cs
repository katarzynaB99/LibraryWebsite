using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Domain.Record
{
    public class RecordFactory : IRecordFactory
    {
        public Record Create(int commandReaderId, int commandBookId)
        {
            return new Record(commandReaderId, commandBookId);
        }
    }
}
