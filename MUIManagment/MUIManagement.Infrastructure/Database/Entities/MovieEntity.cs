﻿using System;
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

        public long AuthorId { get; set; }
        public AuthorEntity Author { get; set; }

        public List<RentalEntity> Rentals { get; set; }

        public MovieEntity(long id, string title, string description, DateTime releaseDate, long authorId)
        {
            Id = id;
            Title = title;
            Description = description;
            ReleaseDate = releaseDate;
            AuthorId = authorId;
        }
    }
}
