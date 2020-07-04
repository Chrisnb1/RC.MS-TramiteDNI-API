using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Queries
{
    public interface IQuery
    {
        List<ListaTramites> GetListaTramite(int TramiteDNIid);

        List<NuevoEjemplarDTO> GetListaNuevosEjemplares(int NuevoEjemplarId);

        List<ExtranjeroDTO> GetListaExtranjeros(int ExtranjeroId);

        List<NacimientoDTO> GetListaNacimientos(int NacimientoId);
    }
}
