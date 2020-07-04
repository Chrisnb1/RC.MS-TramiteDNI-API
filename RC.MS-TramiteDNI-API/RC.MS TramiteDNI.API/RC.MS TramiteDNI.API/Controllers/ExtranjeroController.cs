using Microsoft.AspNetCore.Mvc;
using RC.MS_TramineDNI.Application.Services;
using RC.MS_TramiteDNI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.MS_TramiteDNI.API.Controllers
{
    [Route("Api/Extranjero")]
    [ApiController]
    public class ExtranjeroController : ControllerBase
    {
        private readonly IExtranjeroServicio _servicio;
        public NroDNI _nro;

        public ExtranjeroController(IExtranjeroServicio servicio)
        {
            _servicio = servicio;
            
        }

        [HttpGet("ListaExtranjeros")]
        public IActionResult ListaExtranjeros(int ExtranjeroId)
        {
            try
            {
                return new JsonResult(_servicio.ListaExtranjeros(ExtranjeroId)) { StatusCode = 200 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

        [HttpPost]
        public IActionResult Post(ExtranjeroDTO dto)
        {

            try
            {
                return new JsonResult(_servicio.CrearExtranjero(dto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(ExtranjeroDTO dto, int id)
        {
            if (dto.ExtranjeroId != id)
            {
                return BadRequest();
            }

            else
                return new JsonResult(_servicio.ActualizarExtranjero(dto, id)) { StatusCode = 200 };
        }

    }
}
