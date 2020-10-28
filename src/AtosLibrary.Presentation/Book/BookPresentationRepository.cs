using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Book;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Presentation.Book
{
    public class BookPresentationRepository : IBookPresentationRepository
    {
        private readonly IBookRepository _bookRepository;

        public BookPresentationRepository(IBookRepository bookRepository) =>
            _bookRepository = bookRepository;

        public BookModel Get(int id)
        {
            var entity = _bookRepository.Get(id);

            BookModel bookModel = ConvertEntityToModel(entity);

            return bookModel;
        }
        public IEnumerable<BookModel> Search(string searchQuery)
        {
            searchQuery = searchQuery.ToLowerInvariant();
            var entities = _bookRepository.GetAll().Where(x =>
                x.Name.ToLowerInvariant().Contains(searchQuery) ||
                x.Author.ToLowerInvariant().Contains(searchQuery) ||
                x.Genre.ToLowerInvariant().Contains(searchQuery) ||
                x.Publisher.ToLowerInvariant().Contains(searchQuery));

            return ConvertEntityToModelList(entities);
        }

        public IEnumerable<BookModel> GetList()
        {
            var entities = _bookRepository.GetAll();
            var books = ConvertEntityToModelList(entities);

            return books;
        }

        private List<BookModel> ConvertEntityToModelList(IEnumerable<BookDto> entities)
        {
            var books = new List<BookModel>();

            foreach (var entity in entities)
            {
                var reader = ConvertEntityToModel(entity);
                books.Add(reader);
            }

            return books;
        }
        private BookModel ConvertEntityToModel(BookDto entity)
        {
            var bookModel = new BookModel();

            bookModel.Id = entity.Id;
            bookModel.Number = entity.Number;
            bookModel.Name = entity.Name;
            bookModel.Description = entity.Description;
            bookModel.Genre = entity.Genre;
            bookModel.Author = entity.Author;
            bookModel.PageNumber = entity.PageNumber;
            bookModel.PublicationYear = entity.PublicationYear;
            bookModel.Publisher = entity.Publisher;

            return bookModel;
        }
    }
}