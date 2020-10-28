using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Book
{
    public class BookRepository : IBookRepository
    {
        private readonly AtosLibraryContext _context;

        public BookRepository(AtosLibraryContext context) => _context = context;

        public void Add(BookDto entity)
        {
            _context.BookList.Add(new BookEntity
            {
                Name = entity.Name,
                Description = entity.Description,
                Number = entity.Number,
                Genre = entity.Genre,
                Author = entity.Author,
                PageNumber = entity.PageNumber,
                Publisher = entity.Publisher,
                PublicationYear = entity.PublicationYear
            });

            _context.SaveChanges();
        }

        public void Edit(BookDto entity)
        {
            var bookEntity = GetEntity(entity.Id);

            bookEntity.Name = entity.Name;
            bookEntity.Description = entity.Description;
            bookEntity.Number = entity.Number;
            bookEntity.Genre = entity.Genre;
            bookEntity.Author = entity.Author;
            bookEntity.PageNumber = entity.PageNumber;
            bookEntity.Publisher = entity.Publisher;
            bookEntity.PublicationYear = entity.PublicationYear;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.BookList.Remove(GetEntity(id));

            _context.SaveChanges();
        }

        public BookDto Get(int id)
        {
            var bookDto = _context.BookList.Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Number = x.Number,
                Genre = x.Genre,
                Author = x.Author,
                PageNumber = x.PageNumber,
                Publisher = x.Publisher,
                PublicationYear = x.PublicationYear
            }).FirstOrDefault(x => x.Id == id);

            return bookDto;
        }

        public BookDto GetByName(string name)
        {
            var bookDto = _context.BookList.Select(x => new BookDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Number = x.Number,
                Genre = x.Genre,
                Author = x.Author,
                PageNumber = x.PageNumber,
                Publisher = x.Publisher,
                PublicationYear = x.PublicationYear
            }).FirstOrDefault(x => x.Name.Equals(name));

            return bookDto;
        }

        public IEnumerable<BookDto> GetAll()
        {
            return _context.BookList.Select(x => new BookDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Number = x.Number,
                Genre = x.Genre,
                Author = x.Author,
                PageNumber = x.PageNumber,
                Publisher = x.Publisher,
                PublicationYear = x.PublicationYear
            }).ToList();
        }

        private BookEntity GetEntity(int id)
        {
            return _context.BookList.FirstOrDefault(x => x.Id == id);
        }
    }
}