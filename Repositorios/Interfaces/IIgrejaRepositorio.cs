using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IIgrejaRepositorio
    {
        Task<List<IgrejaModel>> GetAllIgrejas();
        Task<IgrejaModel?> GetIgrejaById(String id);
        Task<IgrejaModel> AddIgreja(IgrejaModel model);
        Task<IgrejaModel?> UpdateIgreja(IgrejaModel model);
        Task<bool> DeleteIgreja(String id);
        Task<List<IgrejaModel>> GetIgrejasBySetorId(String setId);
    }
}
