using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using AtosLibrary.Domain.Record;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Presentation.Record
{
    public class RecordPresentationRepository : IRecordPresentationRepository
    {
        private readonly IRecordRepository _recordRepository;

        public RecordPresentationRepository(IRecordRepository recordRepository) =>
            _recordRepository = recordRepository;

        public RecordModel Get(int id)
        {
            var entity = _recordRepository.Get(id);

            RecordModel record = ConvertEntityModel(entity);

            return record;
        }

       
        public IEnumerable<RecordModel> GetList()
        {
            var entities = _recordRepository.GetAll();

            return ConvertEntityToModelList(entities);
        }

        public IEnumerable<RecordModel> Search(string searchQuery)
        {
            searchQuery = searchQuery.ToLowerInvariant();
            var entities = _recordRepository.GetAll().Where(x =>
                x.RecordId.ToString().ToLowerInvariant().Contains(searchQuery) ||
                x.BookId.ToString().ToLowerInvariant().Contains(searchQuery) ||
                x.ReaderId.ToString().ToLowerInvariant().Contains(searchQuery) ||
                x.Status.ToLowerInvariant().Contains(searchQuery));
            return ConvertEntityToModelList(entities);
        }

        private RecordModel ConvertEntityModel(RecordDto entity)
        {
            var record = new RecordModel();

            record.RecordId = entity.RecordId;
            record.ReaderId = entity.ReaderId;
            record.BookId = entity.BookId;
            record.Status = entity.Status;
            record.RentStart = entity.RentStart;
            record.RentEnd = entity.RentEnd;

            record.BookName = entity.BookName;
            record.ReaderName = entity.ReaderName;
            record.ReaderSurname = entity.ReaderSurname;

            return record;
        }

        private List<RecordModel> ConvertEntityToModelList(IEnumerable<RecordDto> entities)
        {
            var records = new List<RecordModel>();

            foreach (var entity in entities)
            {
                var record = ConvertEntityModel(entity);
                records.Add(record);
            }

            return records;
        }
    }
}
