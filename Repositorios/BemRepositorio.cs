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

        public List<BemModel?> GetBemById(string id)
        {
            List<BemModel?> list = [];
            var result = _dbContext.bens.Where(x => x.id_igreja.Equals(id));
            foreach (var item in result)
            {
                list.Add(item);
            }
            

           return list;
           
        }

        public async Task<BemModel?> UpdateBem(BemModel model, string id)
        {
            BemModel? bemModelById = null;//GetBemById(id);
            if (bemModelById == null)
            {
                throw new Exception($"Bem para o ID: {id} não foi encontrado no banco de dados.");
            }

            bemModelById.dependencia = model.dependencia;
            bemModelById.status = model.status;
            //bemModelById.observacao = model.observacao;
            bemModelById.descricao = model.descricao;
            bemModelById.id_bem = id;
            bemModelById.id_igreja = model.id_igreja;
            _dbContext.Update(bemModelById);
            await _dbContext.SaveChangesAsync();

            return bemModelById;
           
        }
    }
}
