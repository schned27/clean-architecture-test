using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MUIManagement.Infrastructure.Database.Entities
{
    public class PersonEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<RentalEntity> Rentals { get; set; }

        [InverseProperty("Author")]
        public List<MovieEntity> AuthoredMovies { get; set; }
    }
}
