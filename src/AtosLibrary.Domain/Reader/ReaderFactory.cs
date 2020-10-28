using System;

namespace AtosLibrary.Domain.Reader
{
    public class ReaderFactory : IReaderFactory
    {
        public Reader Create(string commandName, string commandSurname, string commandGender,
            DateTime commandBirthday, string commandEmail, string commandPhoneNumber,
            string commandCountry, string commandCity)
        {
            return new Reader(commandName, commandSurname, commandGender, commandBirthday,
                commandEmail, commandPhoneNumber, commandCountry, commandCity);
        }

        public Reader Create(int commandId, string commandName, string commandSurname,
            string commandGender, DateTime commandBirthday, string commandEmail,
            string commandPhoneNumber, string commandCountry, string commandCity)
        {
            return new Reader(commandId, commandName, commandSurname, commandGender,
                commandBirthday, commandEmail, commandPhoneNumber, commandCountry, commandCity);
        }

        public Reader Create(string commandName, string commandSurname, IReaderRepository readerRepository)
        {
            return new Reader(commandName, commandSurname, readerRepository);
        }
    }
}