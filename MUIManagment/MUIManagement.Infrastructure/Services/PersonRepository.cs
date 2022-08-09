using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonModel>> GetAllPersons()
        {
            return await _context.Persons.Select(x => 
                new PersonModel(
                    x.Id, 
                    x.FirstName, 
                    x.LastName))
                .ToListAsync();
        }

        public async Task<PersonModel> GetPersonById(long id)
        {
            return null;
        }

        public async Task CreatePerson(PersonModel Person)
        {

        }

        public async Task EditPerson(long id, PersonModel Person)
        {

        }

        public async Task DeletePersonById(long id)
        {

        }
    }
}
