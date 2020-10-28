using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Application.Features.ReadyBook
{
    public class ReadyBookCommand
    {
        public int RecordId { get; set; }

        public ReadyBookCommand(int recordId) => RecordId = recordId;
    }
}
