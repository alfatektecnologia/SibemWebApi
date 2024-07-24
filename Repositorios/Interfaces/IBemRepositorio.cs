using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IBemRepositorio
    {
        Task<List<BemModel>> GetAllBens();
        List<BemModel?> GetBemById(String id);
        Task<BemModel> AddBem(BemModel model);
        Task<BemModel?> UpdateBem(BemModel model, String id);
        Task<bool> DeleteBem(String id);

    }
}
