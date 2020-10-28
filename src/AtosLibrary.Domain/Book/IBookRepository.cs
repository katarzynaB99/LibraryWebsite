using System;
using System.Collections.Generic;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Book
{
    public interface IBookRepository
    {
        void Add(BookDto entity);

        void Edit(BookDto entity);

        void Delete(int id);

        public BookDto Get(int id);

        public IEnumerable<BookDto> GetAll();

        public BookDto GetByName(string name);
    }
}