using RC.MS_TramiteDNI.Domain.DTOs;
using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Commands
{
    public interface IGenericRepository
    {
        void Add<T>(T entidad) where T : class;

        void Update<T>(T entidad) where T : class;

        void Remove<T>(T entidad) where T : class;
    }
}
