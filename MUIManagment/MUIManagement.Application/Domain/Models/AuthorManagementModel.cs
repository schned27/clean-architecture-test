using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.Domain.Models
{
    public class AuthorManagementModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorManagementModel() { }

        public AuthorManagementModel(long id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}