using System;

namespace AtosLibrary.Application.Features.DeleteReader
{
    public class DeleteReaderCommand
    {
        public DeleteReaderCommand(int readerId)
        {
            ReaderId = readerId;
        }

        public int ReaderId { get; set; }
    }
}
