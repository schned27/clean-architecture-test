using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Infrastructure.Services
{
    public class RentalRepository : IRentalRepository
    {
        public async Task<List<RentalModel>> GetAllRentals()
        {
            return null;
        }

        public async Task<RentalModel> GetRentalById(long id)
        {
            return null;
        }

        public async Task CreateRental(RentalModel Rental)
        {

        }

        public async Task EditRental(long id, RentalModel Rental)
        {

        }

        public async Task DeleteRentalById(long id)
        {

        }
    }
}
