using Microsoft.EntityFrameworkCore;
using SibemWebApi.Data;
using SibemWebApi.Models;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Repositorios
{
    public class IgrejaRepositorio : IIgrejaRepositorio
    {
        private readonly SibemDbContext _dbContext;

        public IgrejaRepositorio(SibemDbContext sibemDbContext)
        {
            _dbContext = sibemDbContext;
        }
        public async Task<List<IgrejaModel>> GetAllIgrejas()
        {
            return await _dbContext.igrejas.ToListAsync();
        }

        public async Task<IgrejaModel?> GetIgrejaById(string id)
        {
            return await _dbContext.igrejas.FirstOrDefaultAsync(x=> x.id_igreja.Equals(id));
        }

        public async Task<IgrejaModel> AddIgreja(IgrejaModel model)
        {
            await _dbContext.igrejas.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteIgreja(string id)
        {
            IgrejaModel? igrejaModelById = await GetIgrejaById(id);
            if (igrejaModelById == null)
            {
                throw new Exception($"Igreja para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Remove(igrejaModelById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        

        public async Task<IgrejaModel?> UpdateIgreja(IgrejaModel model, string id)
        {
           IgrejaModel? igrejaModelById = await GetIgrejaById(id);
            if (igrejaModelById == null)
            {
                throw new Exception($"Igreja para o ID: {id} não foi encontrada no banco de dados.");
            }
            igrejaModelById.igreja = model.igreja;
            igrejaModelById.id_igreja = id;
            igrejaModelById.endereco = model.endereco;
            igrejaModelById.situacao = model.situacao;
            igrejaModelById.id_setor = model.id_setor;
            igrejaModelById.foto = model.foto;
            igrejaModelById.last_Inventario = model.last_Inventario;

            _dbContext.Update(igrejaModelById);
            await _dbContext.SaveChangesAsync();
            return igrejaModelById;
        }
    }
}
