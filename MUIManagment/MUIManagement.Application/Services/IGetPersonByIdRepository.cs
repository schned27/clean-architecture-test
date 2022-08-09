using MUIManagement.Application.Domain.Models.GetPersonByIdModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IGetPersonByIdRepository
    {
        Task<List<GetPersonByIdModel>> GetAllPersons();
        Task<GetPersonByIdModel> GetPersonById(long id);
        Task CreatePerson(GetPersonByIdModel person);
        Task EditPerson(long id, GetPersonByIdModel person);
        Task DeletePersonById(long id);
    }