using Microsoft.AspNetCore.Mvc;
using RC.MS_TramineDNI.Application.Services;
using RC.MS_TramiteDNI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.MS_TramiteDNI.API.Controllers
{
    [Route("Api/Nacimiento")]
    [ApiController]
    public class NacimientoController : ControllerBase
    {
        private readonly INacimientoServicio _servicio;

        public NacimientoController(INacimientoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListaNacimientos")]
        public IActionResult ListaNacimientos(int NacimientoId)
        {
            try
            {
                return new JsonResult(_servicio.ListaNacimientos(NacimientoId)) { StatusCode = 200 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(NacimientoDTO dto)
        {

            try
            {
                return new JsonResult(_servicio.CrearNacimiento(dto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(NacimientoDTO dto, int id)
        {
            if (dto.NacimientoId != id)
            {
                return BadRequest();
            }

            else
                return new JsonResult(_servicio.ActualizarNacimiento(dto, id)) { StatusCode = 200 };
        }
    }
}
