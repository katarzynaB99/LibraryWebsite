using System;

namespace AtosLibrary.Domain.Reader
{
    public interface IReaderFactory
    {
        Reader Create(string commandName, string commandSurname, string commandGender,
            DateTime commandBirthday, string commandEmail, string commandPhoneNumber,
            string commandCountry, string commandCity);

        Reader Create(int commandId, string commandName, string commandSurname,
            string commandGender, DateTime commandBirthday, string commandEmail,
            string commandPhoneNumber, string commandCountry, string commandCity);

        Reader Create(string commandName, string commandSurname, IReaderRepository readerRepository);
    }
}