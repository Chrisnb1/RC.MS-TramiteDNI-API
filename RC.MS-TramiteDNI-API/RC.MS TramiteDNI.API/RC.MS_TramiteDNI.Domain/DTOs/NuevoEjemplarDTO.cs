using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.DTOs
{
    public class NuevoEjemplarDTO
    {
        public int NuevoEjemplarId { get; set; }
        public string Descripcion { get; set; }
        public int TramiteDNIid { get; set; }

    }
}
