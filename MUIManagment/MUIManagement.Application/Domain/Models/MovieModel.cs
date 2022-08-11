using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.Domain.Models
{
    public class MovieModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
    }
}
