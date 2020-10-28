using AtosLibrary.Infrastructure;
using System;
using System.Collections.Generic;

namespace AtosLibrary.Domain.Reader
{
    public interface IReaderRepository
    {
        void Add(ReaderDto entity);

        void Edit(ReaderDto entity);

        void Delete(int id);

        public ReaderDto Get(int id);

        public ReaderDto GetByName(string name, string surname);

        public IEnumerable<ReaderDto> GetAll();
    }
}