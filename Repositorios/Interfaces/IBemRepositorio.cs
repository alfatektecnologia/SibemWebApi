using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IBemRepositorio
    {
        Task<List<BemModel>> GetAllBens();
        Task<List<BemModel>> GetBemByIgrejaId(String igrejaId);
        Task<BemModel> AddBem(BemModel model);
        Task<BemModel?> UpdateBem(BemModel model, String igrejaId, string bemId);
        Task<bool> DeleteBem(String id);

    }
}
