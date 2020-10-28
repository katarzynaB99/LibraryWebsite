using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Application.Features.PrepareBook
{
    public class PrepareBookCommand
    {
        public int RecordId { get; set; }

        public PrepareBookCommand(int recordId)
        {
            RecordId = recordId;
        }
    }
}
