using RC.MS_TramiteDNI.Domain.Commands;
using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using RC.MS_TramiteDNI.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace RC.MS_TramineDNI.Application.Services
{
    public interface INuevoEjemplarServicio
    {
        NuevoEjemplar CrearNuevoEjemplar(NuevoEjemplarDTO entidad);

        NuevoEjemplar ActualizarNuevoEjemplar(NuevoEjemplarDTO entidad, int id);

        IEnumerable<NuevoEjemplarDTO> ListaNuevosEjemplares(int id);

    }
    public class NuevoEjemplarServicio : INuevoEjemplarServicio
    {
        private readonly IGenericRepository _repository;
        private readonly IQuery _query;

        public NuevoEjemplarServicio(IGenericRepository repository, IQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public NuevoEjemplar CrearNuevoEjemplar(NuevoEjemplarDTO entidad)
        {
            var tramite = new TramiteDNI();
            _repository.Add(tramite);

            var nuevo = new NuevoEjemplar()
            {
                Descripcion = entidad.Descripcion,
                TramiteDNInavigator = tramite
            };
            
            _repository.Add(nuevo);
            return nuevo;
        }


        public NuevoEjemplar ActualizarNuevoEjemplar(NuevoEjemplarDTO entidad, int id)
        {
            var editado = new NuevoEjemplar()
            {
                NuevoEjemplarId = id,
                Descripcion = entidad.Descripcion,
                TramiteDNIid = entidad.TramiteDNIid
            };

            _repository.Update(editado);
            return editado;
        }

        public IEnumerable<NuevoEjemplarDTO> ListaNuevosEjemplares(int NuevoEjemplarId)
        {
            return _query.GetListaNuevosEjemplares(NuevoEjemplarId);
        }
    }
}
