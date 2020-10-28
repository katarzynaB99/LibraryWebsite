using AtosLibrary.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;


namespace AtosLibrary.Domain.Reader
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly AtosLibraryContext _context;

        public ReaderRepository(AtosLibraryContext context) => _context = context;

        public void Add(ReaderDto entity)
        {
            _context.ReaderList.Add(new ReaderEntity
            {  
                Name = entity.Name,
                Surname = entity.Surname,
                Gender = entity.Gender,
                Birthday = entity.Birthday,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Country = entity.Country,
                City = entity.City
            });
            _context.SaveChanges();
        }

        public void Edit(ReaderDto entity)
        {
            var readerEntity = GetEntity(entity.Id);

            readerEntity.Name = entity.Name;
            readerEntity.Surname = entity.Surname;
            readerEntity.Gender = entity.Gender;
            readerEntity.Birthday = entity.Birthday;
            readerEntity.Email = entity.Email;
            readerEntity.PhoneNumber = entity.PhoneNumber;
            readerEntity.Country = entity.Country;
            readerEntity.City = entity.City;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.ReaderList.Remove(GetEntity(id));

            _context.SaveChanges();
        }

        public ReaderDto Get(int id)
        {
            var readerDto = _context.ReaderList.Select(x => new ReaderDto()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Gender = x.Gender,
                Birthday = x.Birthday,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Country = x.Country,
                City = x.City
            }).FirstOrDefault(x => x.Id == id);

            return readerDto;
        }

        public ReaderDto GetByName(string name, string surname)
        {
            /*var reader = _context.ReaderList.Select(x => new ReaderDto()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Gender = x.Gender,
                Birthday = x.Birthday,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Country = x.Country,
                City = x.City
            }).FirstOrDefault(x => x.Name == name && x.Surname == surname);

            return reader;*/

            var resultId = (from x in _context.ReaderList
                where x.Name.Equals(name) && x.Surname.Equals(surname)
                select x.Id).FirstOrDefault();

            return Get(resultId);
        }

        public IEnumerable<ReaderDto> GetAll()
        {
            return _context.ReaderList.Select(x => new ReaderDto
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Gender = x.Gender,
                Birthday = x.Birthday,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Country = x.Country,
                City = x.City
            }).ToList();
        }

        private ReaderEntity GetEntity(int id)
        {
            return _context.ReaderList.FirstOrDefault(x => x.Id == id);
        }
    }
}