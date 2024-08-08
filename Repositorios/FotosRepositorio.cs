using Microsoft.EntityFrameworkCore;
using SibemWebApi.Data;
using SibemWebApi.Models;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Repositorios
{
    public class FotosRepositorio : IFotosRepositorio
    {
        private readonly SibemDbContext _dbContext;

        public FotosRepositorio(SibemDbContext sibemDbContext)
        {
            _dbContext = sibemDbContext;
        }

        public async Task<FotosModel> AddFoto(string foto, int id_igreja)
        {
            FotosModel fotosModel = new FotosModel();
            fotosModel.foto = foto;
            fotosModel.id_igreja = id_igreja;
            await _dbContext.fotos.AddAsync(fotosModel);
            await _dbContext.SaveChangesAsync();
            return fotosModel;
        }

        public async Task<List<FotosModel>> GetAllFotos()
        {
            return  await _dbContext.fotos.ToListAsync();
        }
    }
}
