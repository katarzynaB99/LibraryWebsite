using System;

namespace AtosLibrary.Application.Features.RegistrationReader
{
    public class RegistrationReaderCommand
    {
        public RegistrationReaderCommand(string name, string surname, string gender,
            DateTime birthday, string email, string phoneNumber, string country, string city)
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            Birthday = birthday;
            Email = email;
            PhoneNumber = phoneNumber;
            Country = country;
            City = city;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}