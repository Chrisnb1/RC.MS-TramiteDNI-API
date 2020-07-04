using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace RC.MS_TramiteDNI.Domain.DTOs
{
    public class NroDNI
    {
        private static int _nro;
        private string ruta = "NroDNI.json"; 
        public NroDNI() { }
        
        public  int incrementar(int nro)
        {
            int incrementado = Interlocked.Increment(ref nro);
            Guardar(incrementado);

            return incrementado;

        }

        public void Guardar(int i)
        {

            string Nro = JsonConvert.SerializeObject(i);
            File.WriteAllText(ruta, Nro);
        }


        public  int Mostrar()
        {
            string archivo = File.ReadAllText(ruta);
            _nro = JsonConvert.DeserializeObject<int>(archivo);
            _nro = incrementar(_nro);

            return _nro;
        }

    }
}
