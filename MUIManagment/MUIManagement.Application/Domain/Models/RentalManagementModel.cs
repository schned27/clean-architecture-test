using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MUIManagement.Application.Domain.Models
{
    public class RentalManagementModel
    {
        public long Id { get; set; }
        public string? Note { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime DueDate { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
    }
}
