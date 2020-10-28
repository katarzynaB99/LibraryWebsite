using System;
using AtosLibrary.Domain.Book;
using AtosLibrary.Infrastructure;

namespace AtosLibrary.Domain.Reader
{
    public class Reader
    {
        private readonly int _id;
        private readonly string _commandName;
        private readonly string _commandSurname;
        private readonly string _commandGender;
        private readonly DateTime _commandBirthday;
        private readonly string _commandEmail;
        private readonly string _commandPhoneNumber;
        private readonly string _commandCountry;
        private readonly string _commandCity;

        internal Reader(string commandName, string commandSurname,
            IReaderRepository readerRepository)
        {
            _commandName = commandName;
            _commandSurname = commandSurname;

            var reader = readerRepository.GetByName(commandName, commandSurname);

            _id = reader.Id;
            _commandGender = reader.Gender;
            _commandBirthday = reader.Birthday;
            _commandEmail = reader.Email;
            _commandPhoneNumber = reader.PhoneNumber;
            _commandCountry = reader.Country;
            _commandCity = reader.City;
        }

        internal Reader(string commandName, string commandSurname, string commandGender,
            DateTime commandBirthday, string commandEmail, string commandPhoneNumber,
            string commandCountry, string commandCity)
        {
            _commandName = commandName;
            _commandSurname = commandSurname;
            _commandGender = commandGender;
            _commandBirthday = commandBirthday;
            _commandEmail = commandEmail;
            _commandPhoneNumber = commandPhoneNumber;
            _commandCountry = commandCountry;
            _commandCity = commandCity;
        }

        internal Reader(int commandId, string commandName, string commandSurname,
            string commandGender, DateTime commandBirthday, string commandEmail,
            string commandPhoneNumber, string commandCountry, string commandCity)
        {
            _id = commandId;
            _commandName = commandName;
            _commandSurname = commandSurname;
            _commandGender = commandGender;
            _commandBirthday = commandBirthday;
            _commandEmail = commandEmail;
            _commandPhoneNumber = commandPhoneNumber;
            _commandCountry = commandCountry;
            _commandCity = commandCity;
        }

        public void Register(IReaderRepository readerRepository)
        {
            readerRepository.Add(new ReaderDto
            {
                Id = _id,
                Name = _commandName,
                Surname = _commandSurname,
                Gender = _commandGender,
                Birthday = _commandBirthday,
                Email = _commandEmail,
                PhoneNumber = _commandPhoneNumber,
                Country = _commandCountry,
                City = _commandCity
            });
        }

        public void Edit(IReaderRepository readerRepository)
        {
            readerRepository.Edit(new ReaderDto
            {
                Id = _id,
                Name = _commandName,
                Surname = _commandSurname,
                Gender = _commandGender,
                Birthday = _commandBirthday,
                Email = _commandEmail,
                PhoneNumber = _commandPhoneNumber,
                Country = _commandCountry,
                City = _commandCity
            });
        }
    }
}