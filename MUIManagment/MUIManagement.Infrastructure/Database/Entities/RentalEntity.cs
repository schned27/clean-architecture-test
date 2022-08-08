using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MUIManagement.Infrastructure.Database.Entities
{
    public class RentalEntity
    {
        public long Id { get; set; }
        public string? Note { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime DueDate { get; set; }

        public long PersonId { get; set; }
        public PersonEntity PersonEntity { get; set; }

        public long MovieId { get; set; }
        public MovieEntity MovieEntity { get; set; }
    }
}
