using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using RC.MS_TramiteDNI.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RC.MS_TramiteDNI.AccessData.Queries
{
    public class Query : IQuery
    {
        private readonly IDbConnection _conection;
        private readonly Compiler _sqlKataCompiler;

        public Query(IDbConnection conection, Compiler sqlKataCompiler)
        {
            _conection = conection;
            _sqlKataCompiler = sqlKataCompiler;
        }

        public List<ExtranjeroDTO> GetListaExtranjeros(int ExtranjeroId)
        {
            var db = new QueryFactory(_conection, _sqlKataCompiler);

            var extranjero = db.Query("Extranjeros")
                .Select("ExtranjeroId", "PaisOrigen", "TramiteDNIid", "NroDNI")
                .When(ExtranjeroId > 0, q => q.WhereLike("ExtranjeroId", $"%{ExtranjeroId}%"));

            var result = extranjero.Get<ExtranjeroDTO>();

            
            
            return result.ToList();
        }

        public List<NuevoEjemplarDTO> GetListaNuevosEjemplares(int NuevoEjemplarId)
        {
            var db = new QueryFactory(_conection, _sqlKataCompiler);

            var ejemplar = db.Query("NuevosEjemplares")
                .Select("NuevoEjemplarId", "TramiteDNIid", "Descripcion")
                .When(NuevoEjemplarId > 0, q => q.WhereLike("NuevoEjemplarId", $"%{NuevoEjemplarId}%"));


            var result = ejemplar.Get<NuevoEjemplarDTO>();
            return result.ToList();

        }

        public List<NacimientoDTO> GetListaNacimientos(int NacimientoId)
        {
            var db = new QueryFactory(_conection, _sqlKataCompiler);

            var nacido = db.Query("Nacimientos")
                .Select("NacimientoId", "TramiteRecienNacidoId", "TramiteDNIid")
                .When(NacimientoId > 0, q => q.WhereLike("NacimientoId", $"%{NacimientoId}%"));


            var result = nacido.Get<NacimientoDTO>();
            return result.ToList();
        }

        public List<ListaTramites> GetListaTramite(int TramiteDNIid)
        {
            var lista = new List<ListaTramites>();

            var db = new QueryFactory(_conection, _sqlKataCompiler);

            var ejemplar = db.Query("NuevosEjemplares")
                .Select("NuevoEjemplarId", "TramiteDNIid", "Descripcion")
                .When(TramiteDNIid > 0, q => q.WhereLike("TramiteDNIid", $"%{TramiteDNIid}%"))
                .Get<NuevoEjemplarDTO>().ToList();

            var extranjero = db.Query("Extranjeros")
                .Select("ExtranjeroId", "PaisOrigen", "TramiteDNIid")
                .When(TramiteDNIid > 0, q => q.WhereLike("TramiteDNIid", $"%{TramiteDNIid}%"))
                .Get<ExtranjeroDTO>().ToList();

            var nacimiento = db.Query("Nacimientos")
                .Select("NacimientoId", "TramiteRecienNacidoId", "TramiteDNIid")
                .When(TramiteDNIid > 0, q => q.WhereLike("TramiteDNIid", $"%{TramiteDNIid}%"))
                .Get<NacimientoDTO>().ToList();

            var result = new ListaTramites
            {
                NuevosEjemplares = ejemplar,
                Extranjeros = extranjero,
                Nacimientos = nacimiento
            };

            lista.Add(result);

            return lista;
        }

        
    }
}
