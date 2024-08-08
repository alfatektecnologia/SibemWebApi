using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibemWebApi.Models;
using SibemWebApi.Repositorios;
using SibemWebApi.Repositorios.Interfaces;

namespace SibemWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BemController : ControllerBase
    {
        private readonly IBemRepositorio _bemRepositorio;
        public BemController(IBemRepositorio bemRepositorio)
        {
            _bemRepositorio = bemRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<BemModel>>> getAllBens() 
        {
           List<BemModel> bens =  await _bemRepositorio.GetAllBens();
            return Ok(bens);
        }

        [HttpGet("{igreja}")]
        public ActionResult<List<BemModel>> getBemById(string igreja)
        {
            List<BemModel?> bemById =  _bemRepositorio.GetBemById(igreja);
            return Ok(bemById);
        }

        [HttpPost]
        public async Task<ActionResult<BemModel>> AddBem([FromBody] BemModel bemModel)
        {
            BemModel bem = await _bemRepositorio.AddBem(bemModel);
            return Ok(bem);
        }


    }
}
