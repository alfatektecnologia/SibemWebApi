using Microsoft.EntityFrameworkCore;
using SibemWebApi.Data;
using SibemWebApi.Models;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Repositorios
{
    public class BemRepositorio : IBemRepositorio
    {
        private readonly SibemDbContext _dbContext;

        public BemRepositorio(SibemDbContext sibemDbContext)
        {
            _dbContext = sibemDbContext;
        }
        public async Task<BemModel> AddBem(BemModel model)
        {
            await _dbContext.bens.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
           
        }

        public async Task<bool> DeleteBem(string id)
        {
            BemModel? bemModelById = null;// GetBemById(id);
            if (bemModelById == null)
            {
                throw new Exception($"Bem para o ID: {id} não foi encontrado no banco de dados.");
            }
            _dbContext.Remove(bemModelById);
            await _dbContext.SaveChangesAsync();
            return true;

            throw new NotImplementedException();
        }

        public async Task<List<BemModel>> GetAllBens()
        {
            return await _dbContext.bens.ToListAsync();
           
        }

        public async Task<List<BemModel?>> GetBemByIgrejaId(string id)
        {
            
            return await _dbContext.bens.Where(x => x.id_igreja.Equals(id)).ToListAsync();
           
           
        }

        public async Task<BemModel?> UpdateBem(BemModel model, string igrejaId, string bemId)
        {
            List<BemModel?> bemModelById = await GetBemByIgrejaId(igrejaId);
            BemModel bemModel = null;
            if (bemModelById == null)
            {
                throw new Exception($"Bem para o ID: {igrejaId} não foi encontrado no banco de dados.");
            }

            foreach (BemModel bem in bemModelById)
            {
                if(bem.id_bem == bemId) 
                { 
                    bemModel = bem; }
            }

            bemModel.dependencia = model.dependencia;
            bemModel.status = model.status;
            bemModel.descricao = model.descricao;
            bemModel.id_bem = igrejaId;
            bemModel.id_igreja = model.id_igreja;
            _dbContext.Update(bemModelById);
            await _dbContext.SaveChangesAsync();

            return bemModel;
           
        }
    }
}
