using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using RC.MS_TramiteDNI.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramineDNI.Application.Services
{
    public interface ITramiteDNIServicio
    {
        List<ListaTramites> GetListaTramite(int TramiteDNIid);
    }

    public class TramiteDNIServicio : ITramiteDNIServicio
    {

        private readonly IQuery _query;

        public TramiteDNIServicio(IQuery query)
        {
            _query = query;
        }
        public List<ListaTramites> GetListaTramite(int TramiteDNIid)
        {
            return _query.GetListaTramite(TramiteDNIid);
        }
    }
}
