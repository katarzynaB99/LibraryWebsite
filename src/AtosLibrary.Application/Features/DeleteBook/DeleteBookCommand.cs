using System;

namespace AtosLibrary.Application.Features.DeleteBook
{
    public class DeleteBookCommand
    {
        public DeleteBookCommand(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; set; }
    }
}
