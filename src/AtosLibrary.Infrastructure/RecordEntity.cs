using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AtosLibrary.Infrastructure
{
    [Table("RecordLog")]
    public class RecordEntity
    {
        [Key]
        public int RecordId { get; set; }

        [ForeignKey("Reader")]
        public int ReaderId { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        public string Status { get; set; }

        public DateTime? RentStart { get; set; }

        public DateTime? RentEnd { get; set; }

        public virtual ReaderEntity Reader { get; set; }

        public virtual BookEntity Book { get; set; }

    }
}
