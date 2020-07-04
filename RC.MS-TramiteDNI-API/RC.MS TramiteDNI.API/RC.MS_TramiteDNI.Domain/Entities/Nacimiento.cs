using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Entities
{
    public class Nacimiento
    {
        public int NacimientoId { get; set; }
        public int TramiteRecienNacidoId { get; set; }

        public int TramiteDNIid { get; set; }
        public TramiteDNI TramiteDNInavigator { get; set; }

    }
}
