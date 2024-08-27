using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibemWebApi.Models;
using SibemWebApi.Repositorios;
using SibemWebApi.Repositorios.Interfaces;
using System.Text.Json;

namespace SibemWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IgrejaController : ControllerBase
    {
        private readonly IIgrejaRepositorio _igrejaRepositorio;
        public IgrejaController(IIgrejaRepositorio igrejaRepositorio)
        {
            _igrejaRepositorio = igrejaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<IgrejaModel>>> getAllIgrejas() 
        {
           List<IgrejaModel> igrejas =  await _igrejaRepositorio.GetAllIgrejas();
            return Ok(igrejas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IgrejaModel>> getIgrejaById(string id)
        {
            IgrejaModel? igrejaById = await _igrejaRepositorio.GetIgrejaById(id);
            return Ok(igrejaById);
        }
        [HttpGet("[action]{setor}")]
        public async Task<ActionResult<List<IgrejaModel>>> getIgrejaBySetor(string setor)
        {
            List<IgrejaModel> listIgrejaBySetorId = await _igrejaRepositorio.GetIgrejasBySetorId(setor);
            return Ok(listIgrejaBySetorId);
        }

        [HttpPost]
        public async Task<ActionResult<IgrejaModel>> AddIgreja(string igrejaJson)
        {
            IgrejaModel? igrejaModel = JsonSerializer.Deserialize<IgrejaModel>(igrejaJson);
            IgrejaModel igreja = await _igrejaRepositorio.AddIgreja(igrejaModel!);
            return Ok(igreja);
        }

        [HttpPut("{igrejaJson}")]
        public async Task<ActionResult<IgrejaModel>> UpdateIgreja([FromBody] string igrejaJson)
        {
            IgrejaModel? igrejaModel = JsonSerializer.Deserialize<IgrejaModel>(igrejaJson);
            
            await _igrejaRepositorio.UpdateIgreja(igrejaModel!);
            return Ok(igrejaModel);

        }

        [HttpDelete("{igreja_id}")]
        public async Task<ActionResult<IgrejaModel>> DeleteIgreja(string igreja_id)
        {
           
            bool deleted = await _igrejaRepositorio.DeleteIgreja(igreja_id);
            return Ok(deleted);

        }


    }
}
