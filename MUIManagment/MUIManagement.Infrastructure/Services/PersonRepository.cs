using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Infrastructure.Services
{
    public class PersonRepository : IPersonRepository
    {
        public async Task<List<PersonModel>> GetAllPersons()
        {
            return null;
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
