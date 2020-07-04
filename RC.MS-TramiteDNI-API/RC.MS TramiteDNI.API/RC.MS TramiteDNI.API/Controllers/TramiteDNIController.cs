using Microsoft.AspNetCore.Mvc;
using RC.MS_TramineDNI.Application.Services;
using RC.MS_TramiteDNI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RC.MS_TramiteDNI.API.Controllers
{
    [Route("Api/TramiteDNI")]
    [ApiController]
    public class TramiteDNIController : ControllerBase
    {
        private readonly ITramiteDNIServicio _servicio;

        public TramiteDNIController(ITramiteDNIServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("ListaTramites")]

        public ActionResult GetTramites(int TramiteDNIid)
        {
            try
            {
                return new JsonResult(_servicio.GetListaTramite(TramiteDNIid)) { StatusCode = 200 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("NroDNI")]
        public int GetNroDNI()
        {
            var nro = new NroDNI();
            
            return nro.Mostrar();
        }

    }
}
