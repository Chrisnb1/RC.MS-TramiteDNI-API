using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Entities
{
    public class TramiteDNI
    {
        public int TramiteDNIid { get; set; }
        public NuevoEjemplar NuevosEjemplarNavigator { get; set; }
        public Extranjero ExtranjeroNavigator { get; set; }
        public Nacimiento NacimientoNavigator { get; set; }
    }
}
