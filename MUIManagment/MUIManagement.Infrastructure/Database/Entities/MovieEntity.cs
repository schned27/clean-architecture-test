using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Infrastructure.Database.Entities
{
    public class MovieEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int AuthorPersonId { get; set; }
        public PersonEntity Author { get; set; }

        public List<RentalEntity> Rentals { get; set; }
    }
}
