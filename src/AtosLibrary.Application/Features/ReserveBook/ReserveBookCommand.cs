using System;
using AtosLibrary.Domain.Book;

namespace AtosLibrary.Application.Features.ReserveBook
{
    public class ReserveBookCommand
    {
        public string ReaderName { get; set; }

        public string ReaderSurname { get; set; }

        public string BookName { get; set; }

        public ReserveBookCommand(string readerName, string readerSurname, string bookName)
        {
            ReaderName = readerName;
            ReaderSurname = readerSurname;
            BookName = bookName;
        }
    }
}