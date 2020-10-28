using System;
using System.Collections.Generic;

namespace AtosLibrary.Presentation.Book
{
    public interface IBookPresentationRepository
    {
        BookModel Get(int id);
        IEnumerable<BookModel> GetList();
        IEnumerable<BookModel> Search(string searchQuery);
    }
}