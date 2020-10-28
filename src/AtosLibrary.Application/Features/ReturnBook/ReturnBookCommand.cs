using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Application.Features.ReturnBook
{
    public class ReturnBookCommand
    {
        public int RecordId { get; set; }

        public ReturnBookCommand(int recordId) => RecordId = recordId;
    }
}
