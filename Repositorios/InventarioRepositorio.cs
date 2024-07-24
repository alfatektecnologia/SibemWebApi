using Microsoft.EntityFrameworkCore;
using SibemWebApi.Data;
using SibemWebApi.Models;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Repositorios
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private readonly SibemDbContext _dbContext;
        public InventarioRepositorio(SibemDbContext sibemDbContext)
        {
            _dbContext = sibemDbContext;
        }
        public async Task<InventarioModel> AddInventario(InventarioModel model)
        {
            _dbContext.inventario.Add(model);
            await _dbContext.SaveChangesAsync();
            return model;
           
        }

        public async Task<bool> DeleteInventario(string id)
        {
            InventarioModel? inventarioModelById = await GetInventarioById(id);
            if (inventarioModelById == null)
            {
                throw new Exception($"Inventario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Remove(inventarioModelById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<InventarioModel>> GetAllInventarios()
        {
           return await _dbContext.inventario.ToListAsync();
        }

        public List<InventarioModel>? GetAllInventariosByIgrejaId(string igrejaId)
        {
            var result = _dbContext.inventario.Where(x => x.id_igreja.Equals(igrejaId));
            List<InventarioModel>? inventarioModels = result.ToList();
           return inventarioModels;
        }

        public async Task<InventarioModel?> GetInventarioById(string id)
        {
           return await _dbContext.inventario.FirstOrDefaultAsync(x=> x.id_inventario.Equals(id));
        }

        public async Task<InventarioModel> UpdateInventario(InventarioModel model, string id)
        {
            InventarioModel? inventarioModelById = await GetInventarioById(id);
            if (inventarioModelById == null)
            {
                throw new Exception($"Inventario para o ID: {id} não foi encontrado no banco de dados.");
            }
            inventarioModelById.bens = model.bens;
            inventarioModelById.id_igreja = id;
            inventarioModelById.inventariantes = model.inventariantes;
            inventarioModelById.status = model.status;
            inventarioModelById.id_inventario = model.id_inventario;
            inventarioModelById.tempo = model.tempo;
            inventarioModelById.data = model.data;
            inventarioModelById.inicio = model.inicio;
            inventarioModelById.termino = model.termino;
            inventarioModelById.pdf = model.pdf;
            inventarioModelById.responsaveis = model.responsaveis;

            _dbContext.Update(inventarioModelById);
            await _dbContext.SaveChangesAsync();
            return inventarioModelById;
        }
    }
}
