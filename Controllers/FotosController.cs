using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SibemWebApi.Models;
using SibemWebApi.Repositorios;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class fotosController : ControllerBase
    {
        private readonly IFotosRepositorio _fotosRepositorio;
        public fotosController(IFotosRepositorio fotosRepositorio)
        {
            _fotosRepositorio = fotosRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<FotosModel>>> getAllfotos()
        {
            List<FotosModel> fotos = await _fotosRepositorio.GetAllFotos();
            return Ok(fotos);
        }

        [HttpPost]
        public async Task<ActionResult<FotosModel>> AddFoto([FromBody]FotosModel foto)
        {
           
            if (foto != null) {

               
                    await _fotosRepositorio.AddFoto(foto.id_igreja, foto.foto);
                
            }
            
            return Ok(foto);
        }

    }
}
