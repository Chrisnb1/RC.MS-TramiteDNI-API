using RC.MS_TramiteDNI.Domain.Commands;
using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using RC.MS_TramiteDNI.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramineDNI.Application.Services
{
    public interface IExtranjeroServicio
    {
        Extranjero CrearExtranjero(ExtranjeroDTO entidad);

        Extranjero ActualizarExtranjero(ExtranjeroDTO dto, int id);

        List<ExtranjeroDTO> ListaExtranjeros(int ExtranjeroId);
    }

    public class ExtranjeroServicio : IExtranjeroServicio
    {
        private readonly IGenericRepository _repository;
        private readonly IQuery _query;

        public ExtranjeroServicio(IGenericRepository repository, IQuery query)
        {
            _repository = repository;
            _query = query;
        }


        public Extranjero CrearExtranjero(ExtranjeroDTO entidad)
        {
            var tramite = new TramiteDNI();
            _repository.Add(tramite);

            var nuevo = new Extranjero()
            {
                PaisOrigen = entidad.PaisOrigen,
                TramiteDNInavigator = tramite
            };

            
            _repository.Add(nuevo);
            return nuevo;
        }


        public Extranjero ActualizarExtranjero(ExtranjeroDTO entidad, int id)
        {
            var editado = new Extranjero()
            {
                ExtranjeroId = id,
                PaisOrigen = entidad.PaisOrigen,
                TramiteDNIid = entidad.TramiteDNIid
            };

            _repository.Update(editado);
            return editado;
        }

        public List<ExtranjeroDTO> ListaExtranjeros(int ExtranjeroId)
        {
            return _query.GetListaExtranjeros(ExtranjeroId);
        }
    }
}
