﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SibemWebApi.Models;
using SibemWebApi.Repositorios;
using SibemWebApi.Repositorios.Interfaces;
using System.Text.Json;

namespace SibemWebApi.Controllers
{
   // [Authorize]
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
        public async Task<ActionResult<List<InventarioModel>?>> getInventarioByIgrejaId(string idIgreja)
        {
            List<InventarioModel>? inventarioById = await _inventarioRepositorio.InventariosByIgrejaId(idIgreja);
            return Ok(inventarioById);
        }

        /*
        [HttpGet("{status}")]
        public async Task<ActionResult<InventarioModel>?> getInventarioParcialByIgrejaId(string status, string igrejaId)
        {
            List<InventarioModel>? inventarioById = await _inventarioRepositorio.InventariosByIgrejaId(igrejaId);
            InventarioModel? inventarioParcial= null;
            foreach(InventarioModel iv in inventarioById!) 
            {
                if (iv.status.ToLower().Equals(status.ToLower()))
                {
                    inventarioParcial = iv;
                }
            }
            return Ok(inventarioParcial);
        }
        */

        [HttpPost]
        public async Task<ActionResult<InventarioModel>> AddInventario(string inventarioJson)
        {
            InventarioModel? inventario = JsonSerializer.Deserialize<InventarioModel>(inventarioJson);
            InventarioModel inventarioResult = await _inventarioRepositorio.AddInventario(inventario!);
            return Ok(inventario);
        }


    }
}
