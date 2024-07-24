using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IIgrejaRepositorio
    {
        Task<List<IgrejaModel>> GetAllIgrejas();
        Task<IgrejaModel?> GetIgrejaById(String id);
        Task<IgrejaModel> AddIgreja(IgrejaModel model);
        Task<IgrejaModel?> UpdateIgreja(IgrejaModel model, String id);
        Task<bool> DeleteIgreja(String id);
    }
}
