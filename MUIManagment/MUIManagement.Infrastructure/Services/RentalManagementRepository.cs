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
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                throw new KeyNotFoundException($"Rental with id = {id} does not exist.");
            }
            return _mapper.Map<RentalManagementModel>(rental);
        }

        public async Task CreateRental(RentalManagementModel rental)
        {
            await _context.Rentals.AddAsync(new RentalEntity(rental.Id, rental.Note, rental.IsPaid, rental.Borrowed, rental.DueDate, rental.UserId, rental.MovieId));
            await _context.SaveChangesAsync();
        }

        public async Task EditRental(long id, RentalManagementModel editRental)
        {
            var rental = await _context.Rentals.FindAsync(id);

            if (rental == null)
            {
                throw new KeyNotFoundException($"Rental with id = {id} does not exist.");
            }

            rental.Note = editRental.Note;
            rental.IsPaid = editRental.IsPaid;
            rental.Borrowed = editRental.Borrowed;
            rental.DueDate = editRental.DueDate;
            rental.UserId = editRental.UserId;
            rental.MovieId = editRental.MovieId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalById(long id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                throw new KeyNotFoundException($"Rental with id = {id} does not exist.");
            }
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
        }
    }
}
