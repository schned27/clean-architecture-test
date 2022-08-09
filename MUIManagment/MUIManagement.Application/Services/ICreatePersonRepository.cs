using System;
using MUIManagement.Application.Domain.Models.CreatePersonModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface ICreatePersonRepository
    {
        Task<List<CreatePersonModel>> GetAllPersons();
        Task<CreatePersonModel> GetPersonById(long id);
        Task CreatePerson(CreatePersonModel person);
        Task EditPerson(long id, CreatePersonModel person);
        Task DeletePersonById(long id);
    }
}