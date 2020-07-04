using Microsoft.AspNetCore.Mvc;
using RC.MS_TramineDNI.Application.Services;
using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.MS_TramiteDNI.API.Controllers
{
    [Route("Api/NuevoEjemplar")]
    [ApiController]
    public class NuevoEjemplarController : ControllerBase
    {
        private readonly INuevoEjemplarServicio _servicio;

        public NuevoEjemplarController(INuevoEjemplarServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListaNuevosEjemplares")]
        public IActionResult ListaNuevosEjemplares(int NuevoEjemplarId)
        {
            try
            {
                return new JsonResult(_servicio.ListaNuevosEjemplares(NuevoEjemplarId)) { StatusCode = 200 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(NuevoEjemplarDTO dto)
        {

            try
            {
                return new JsonResult(_servicio.CrearNuevoEjemplar(dto)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(NuevoEjemplarDTO dto, int id)
        {
            if (dto.NuevoEjemplarId != id)
            {
                return BadRequest();
            }

            else
                return new JsonResult(_servicio.ActualizarNuevoEjemplar(dto, id)) { StatusCode = 200 };
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{


        //    try
        //    {
        //        return new JsonResult(_servicio.EliminarNuevoEjemplar(id)) { StatusCode = 201 };
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }


        //}

    }
}
