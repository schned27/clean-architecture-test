using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Services
{
    public class RentalManagementRepository : IRentalManagementRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RentalManagementRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<RentalManagementModel>> GetAllRentals()
        {
            return await _context.Rentals.Select(x =>
                    _mapper.Map<RentalManagementModel>(x))
                .ToListAsync();
        }

        public async Task<RentalManagementModel> GetRentalById(long id)
        {
            var Rental = await _context.Rentals.FindAsync(id);
            return _mapper.Map<RentalManagementModel>(Rental);
        }

        public async Task CreateRental(RentalManagementModel Rental)
        {
            await _context.Rentals.AddAsync(new RentalEntity(Rental.Id, Rental.Note, Rental.IsPaid, Rental.Borrowed, Rental.DueDate, Rental.UserId, Rental.MovieId));
            await _context.SaveChangesAsync();
        }

        public async Task EditRental(long id, RentalManagementModel editRental)
        {
            var Rental = await _context.Rentals.FindAsync(id);
            Rental.Note = editRental.Note;
            Rental.IsPaid = editRental.IsPaid;
            Rental.Borrowed = editRental.Borrowed;
            Rental.DueDate = editRental.DueDate;
            Rental.UserId = editRental.UserId;
            Rental.MovieId = editRental.MovieId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalById(long id)
        {
            _context.Rentals.Remove(await _context.Rentals.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
