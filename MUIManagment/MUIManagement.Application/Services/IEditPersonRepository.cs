using System;
using MUIManagement.Application.Domain.Models.EditPersonModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IEditPersonRepository
    {
        Task<List<EditPersonModel>> GetAllPersons();
        Task<EditPersonModel> GetPersonById(long id);
        Task CreatePerson(EditPersonModel person);
        Task EditPerson(long id, EditPersonModel person);
        Task DeletePersonById(long id);
    }
}