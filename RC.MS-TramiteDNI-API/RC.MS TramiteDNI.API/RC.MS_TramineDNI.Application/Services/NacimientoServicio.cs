using RC.MS_TramiteDNI.Domain.Commands;
using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using RC.MS_TramiteDNI.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramineDNI.Application.Services
{
    public interface INacimientoServicio
    {
        Nacimiento CrearNacimiento(NacimientoDTO entidad);

        Nacimiento ActualizarNacimiento(NacimientoDTO entidad, int id);

        IEnumerable<NacimientoDTO> ListaNacimientos(int NacimientoId);
    }

    public class NacimientoServicio : INacimientoServicio
    {
        private readonly IGenericRepository _repository;
        private readonly IQuery _query;

        public NacimientoServicio(IGenericRepository repository, IQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public Nacimiento CrearNacimiento(NacimientoDTO entidad)
        {
            var tramite = new TramiteDNI();
            _repository.Add(tramite);

            var nuevo = new Nacimiento()
            {
                TramiteRecienNacidoId = entidad.TramiteRecienNacidoId,
                TramiteDNInavigator = tramite
            };


            _repository.Add(nuevo);
            return nuevo;
        }

        public Nacimiento ActualizarNacimiento(NacimientoDTO entidad, int id)
        {
            var editado = new Nacimiento()
            {
                NacimientoId = id,
                TramiteDNIid = entidad.TramiteDNIid
            };

            _repository.Update(editado);
            return editado;
        }


        public IEnumerable<NacimientoDTO> ListaNacimientos(int NacimientoId)
        {
            return _query.GetListaNacimientos(NacimientoId);
        }
    }
}










//public RecienNacido CrearRecienNacido(RecienNacidoDTO entidad)
//{

//    var tramite = new TramiteDNI();
//    _repository.Add(tramite);

//    var nuevo = new RecienNacido()
//    {
//        Persona_1_Id = entidad.Persona_1_Id,
//        Persona_2_Id = entidad.Persona_2_Id,
//        PartidaNacimientoId = entidad.PartidaNacimientoId,
//        TramiteDNIid = entidad.TramiteDNIid
//    };

//    if(tramite.TramiteDNIid!=entidad.TramiteDNIid)
//    {
//        _repository.Remove(tramite);
//    }

//    _repository.Add(nuevo);
//    tramite.RecienNacidosNavigator.Add(nuevo);

//    return nuevo;
//}
