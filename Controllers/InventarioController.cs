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
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepositorio _inventarioRepositorio;
        public InventarioController(IInventarioRepositorio inventarioRepositorio)
        {
            _inventarioRepositorio = inventarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<InventarioModel>>> getAllIinventarios() 
        {
           List<InventarioModel> inventarios =  await _inventarioRepositorio.GetAllInventarios();
            return Ok(inventarios);
        }

        [HttpGet("[action]{id_inventario}")]
        public async Task<ActionResult<InventarioModel>> InventarioById(string id_inventario)
        {
            InventarioModel? inventarioById = await _inventarioRepositorio.GetInventarioById(id_inventario);
            return Ok(inventarioById);
        }
       
        [HttpGet("{idIgreja}")]
        public ActionResult<List<InventarioModel>?> getInventarioByIgrejaId(string idIgreja)
        {
            List<InventarioModel>? inventarioById =  _inventarioRepositorio.InventariosByIgrejaId(idIgreja);
            return Ok(inventarioById);
        }

        [HttpPost]
        public async Task<ActionResult<InventarioModel>> AddInventario([FromBody] InventarioModel inventarioModel)
        {
            InventarioModel inventario = await _inventarioRepositorio.AddInventario(inventarioModel);
            return Ok(inventario);
        }


    }
}
