﻿using SibemWebApi.Models;

namespace SibemWebApi.Repositorios.Interfaces
{
    public interface IFotosRepositorio
    {
        Task<List<FotosModel>> GetAllFotos();
        Task<FotosModel> AddFoto(string id_igreja, string foto);
    }
}
