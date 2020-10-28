using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Presentation.Record
{
    public interface IRecordPresentationRepository
    {
        RecordModel Get(int id);
        IEnumerable<RecordModel> GetList();
        IEnumerable<RecordModel> Search(string searchQuery);
    }
}
