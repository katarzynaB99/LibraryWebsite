using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtosLibrary.Infrastructure
{
    [Table("BookList")]
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public int PageNumber { get; set; }

        public int PublicationYear { get; set; }

        public string Publisher { get; set; }

        public virtual ICollection<RecordEntity> Records { get; set; } = new HashSet<RecordEntity>();

    }
}