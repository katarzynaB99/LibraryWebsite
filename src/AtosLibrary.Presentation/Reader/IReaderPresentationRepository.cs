using System;
using System.Collections.Generic;

namespace AtosLibrary.Presentation.Reader
{
    public interface IReaderPresentationRepository
    {
        ReaderModel Get(int id);
        IEnumerable<ReaderModel> GetList();
        IEnumerable<ReaderModel> Search(string searchQuery);
    }
}