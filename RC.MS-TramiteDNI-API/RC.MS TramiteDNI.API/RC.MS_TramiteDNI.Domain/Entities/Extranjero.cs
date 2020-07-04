using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.Entities
{
    public class Extranjero
    {
        public int ExtranjeroId { get; set; }
        public string PaisOrigen { get; set; }
        public int TramiteDNIid { get; set; }
        public TramiteDNI TramiteDNInavigator { get; set; }
        
    }
}
