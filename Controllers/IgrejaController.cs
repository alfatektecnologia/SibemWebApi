﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id_igreja}")]
        public async Task<ActionResult<IgrejaModel>> getIgrejaById(string id)
        {
            IgrejaModel? igrejaById = await _igrejaRepositorio.GetIgrejaById(id);
            return Ok(igrejaById);
        }

        [HttpPost]
        public async Task<ActionResult<IgrejaModel>> AddIgreja([FromBody] IgrejaModel igrejaModel)
        {
            IgrejaModel igreja = await _igrejaRepositorio.AddIgreja(igrejaModel);
            return Ok(igreja);
        }

        [HttpPut("{id_igreja}")]
        public async Task<ActionResult<IgrejaModel>> UpdateIgreja([FromBody]IgrejaModel igrejaModel, string id)
        {
            igrejaModel.id_igreja = id;
            IgrejaModel? igreja = await _igrejaRepositorio.UpdateIgreja(igrejaModel, id);
            return Ok(igreja);

        }

        [HttpDelete("{id_igreja}")]
        public async Task<ActionResult<IgrejaModel>> DeleteIgreja(string id)
        {
           
            bool deleted = await _igrejaRepositorio.DeleteIgreja(id);
            return Ok(deleted);

        }


    }
}
