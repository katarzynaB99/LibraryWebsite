using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AtosLibrary.Presentation.Record
{
    public class RecordModel
    {
        public int RecordId { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public string Status { get; set; }

        public DateTime? RentStart { get; set; }

        public DateTime? RentEnd { get; set; }

        public string BookName { get; set; }

        public string ReaderName { get; set; }

        public string ReaderSurname { get; set; }
    }
}
