using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Entities
{
    public class NuevoEjemplar
    {
        public int NuevoEjemplarId { get; set; }
        public string Descripcion { get; set; }

        public int TramiteDNIid { get; set; }
        public TramiteDNI TramiteDNInavigator { get; set; }
    }
}
