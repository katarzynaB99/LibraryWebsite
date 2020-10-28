using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Application.Features.RentBook
{
    public class RentBookCommand
    {
        public int RecordId { get; set; }

        public RentBookCommand(int recordId) => RecordId = recordId;
    }
}
