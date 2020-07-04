using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.Domain.DTOs
{
    public class ListaTramites
    {
        

        //public int NuevoEjemplarId { get; set; }
        //public int PersonaId { get; set; }
        //public string Descripcion { get; set; }

        //public int ExtranjeroId { get; set; }
        //public string PaisOrigen { get; set; }

        //public int RecienNacidoId { get; set; }
        //public int Persona_1_Id { get; set; }
        //public int Persona_2_Id { get; set; }
        //public int PartidaNacimientoId { get; set; }

        public List<NuevoEjemplarDTO> NuevosEjemplares { get; set; }

        public List<ExtranjeroDTO> Extranjeros { get; set; }

        public List<NacimientoDTO> Nacimientos { get; set; }
    }

}
