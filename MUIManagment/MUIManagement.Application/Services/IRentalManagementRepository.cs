using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IRentalManagementRepository
    {
        Task<List<RentalManagementModel>> GetAllRentals();
        Task<RentalManagementModel> GetRentalById(long id);
        Task CreateRental(RentalManagementModel Rental);
        Task EditRental(long id, RentalManagementModel Rental);
        Task DeleteRentalById(long id);
    }
}
