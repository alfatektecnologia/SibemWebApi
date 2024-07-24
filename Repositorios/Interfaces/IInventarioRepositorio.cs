using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IInventarioRepositorio
    {
        Task<List<InventarioModel>> GetAllInventarios();
        List<InventarioModel>? GetAllInventariosByIgrejaId(String igrejaId);
        Task<InventarioModel?> GetInventarioById(String id);
        Task<InventarioModel> AddInventario(InventarioModel model);
        Task<InventarioModel> UpdateInventario(InventarioModel model, String id);
        Task<bool> DeleteInventario(String id);
    }
}
