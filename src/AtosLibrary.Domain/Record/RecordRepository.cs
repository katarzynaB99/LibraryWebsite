using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Record
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AtosLibraryContext _context;

        public RecordRepository(AtosLibraryContext context) => _context = context;


        public void Add(RecordDto entity)
        {
            _context.RecordLog.Add(new RecordEntity
            {
                BookId = entity.BookId,
                ReaderId = entity.ReaderId,
                Status = entity.Status,
                RentStart = entity.RentStart,
                RentEnd = entity.RentEnd
            });

            _context.SaveChanges();
        }

        public void Edit(RecordDto entity)
        {
            var recordEntity = GetEntity(entity.RecordId);

            recordEntity.BookId = entity.BookId;
            recordEntity.ReaderId = entity.ReaderId;
            recordEntity.Status = entity.Status;
            recordEntity.RentStart = entity.RentStart;
            recordEntity.RentEnd = entity.RentEnd;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.RecordLog.Remove(GetEntity(id));

            _context.SaveChanges();
        }

        public RecordDto Get(int id)
        {
            var recordDto = _context.RecordLog.Select(x => new RecordDto
            {
                RecordId = x.RecordId,
                ReaderId = x.ReaderId,
                BookId = x.BookId,
                Status = x.Status,
                RentStart = x.RentStart,
                RentEnd = x.RentEnd,
                BookName = x.Book.Name,
                ReaderName = x.Reader.Name,
                ReaderSurname = x.Reader.Surname
            }).FirstOrDefault(x => x.RecordId == id);

            return recordDto;
        }

        public IEnumerable<RecordDto> GetAll()
        {
            return _context.RecordLog.Select(x => new RecordDto
            {
                RecordId = x.RecordId,
                ReaderId = x.ReaderId,
                BookId = x.BookId,
                Status = x.Status,
                RentStart = x.RentStart,
                RentEnd = x.RentEnd,
                BookName = x.Book.Name,
                ReaderName = x.Reader.Name,
                ReaderSurname = x.Reader.Surname
            }).ToList();
        }

        private RecordEntity GetEntity(int id)
        {
            return _context.RecordLog.FirstOrDefault(x => x.RecordId == id);
        }
    }
}
