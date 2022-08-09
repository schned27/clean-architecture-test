using MUIManagement.Application.Domain.Models.GetAllPersonsModel;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IGetAllPersonsRepository
    {
        Task<List<GetAllPersonsModel>> GetAllPersons();
        Task<GetAllPersonsModel> GetPersonById(long id);
        Task CreatePerson(GetAllPersonsModel person);
        Task EditPerson(long id, GetAllPersonsModel person);
        Task DeletePersonById(long id);
    }