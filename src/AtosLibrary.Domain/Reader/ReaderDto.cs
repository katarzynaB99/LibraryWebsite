using System;
using System.Collections.Generic;
using System.Text;

namespace AtosLibrary.Domain.Reader
{
    public class ReaderDto
    {
        public int Id { get; set; }

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
