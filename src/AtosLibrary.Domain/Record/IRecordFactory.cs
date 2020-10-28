using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Domain.Record
{
    public interface IRecordFactory
    {
        Record Create(int commandReaderId, int commandBookId);
    }
}
