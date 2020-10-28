using System;
using System.Collections.Generic;
using System.Text;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Record
{
    public interface IRecordRepository
    {
        void Add(RecordDto entity);

        void Edit(RecordDto entity);

        void Delete(int id);

        public RecordDto Get(int id);

        public IEnumerable<RecordDto> GetAll();
    }
}
