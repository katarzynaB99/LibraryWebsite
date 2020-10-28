using System;
using System.Collections.Generic;
using System.Linq;
using AtosLibrary.Domain.Reader;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Presentation.Reader
{
    public class ReaderPresentationRepository : IReaderPresentationRepository
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderPresentationRepository(IReaderRepository readerRepository) =>
            _readerRepository = readerRepository;

        public ReaderModel Get(int id)
        {
            var entity = _readerRepository.Get(id);

            return new ReaderModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Gender = entity.Gender,
                Birthday = entity.Birthday,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Country = entity.Country,
                City = entity.City
            };
        }

        public IEnumerable<ReaderModel> GetList()
        {
            var entities = _readerRepository.GetAll();

            return ConvertEntityToModelList(entities);
        }

        public IEnumerable<ReaderModel> Search(string searchQuery)
        {
            searchQuery = searchQuery.ToLowerInvariant();
            var entities = _readerRepository.GetAll().Where(x =>
                x.Name.ToLowerInvariant().Contains(searchQuery) ||
                x.Surname.ToLowerInvariant().Contains(searchQuery));

            return ConvertEntityToModelList(entities);
        }

        private List<ReaderModel> ConvertEntityToModelList(IEnumerable<ReaderDto> entities)
        {
            var readers = new List<ReaderModel>();

            foreach (var entity in entities)
            {
                var reader = ConvertEntityToModel(entity);
                readers.Add(reader);
            }

            return readers;
        }

        private ReaderModel ConvertEntityToModel(ReaderDto entity)
        {
            var reader = new ReaderModel();

            reader.Id = entity.Id;
            reader.Surname = entity.Surname;
            reader.Name = entity.Name;
            reader.Gender = entity.Gender;
            reader.Birthday = entity.Birthday;
            reader.Email = entity.Email;
            reader.PhoneNumber = entity.PhoneNumber;
            reader.Country = entity.Country;
            reader.City = entity.City;

            return reader;
        }
    }
}