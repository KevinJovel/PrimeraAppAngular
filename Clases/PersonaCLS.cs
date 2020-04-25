using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApp.Clases
{
    public class PersonaCLS
    {
        public int idPersona { get; set; }
        public string nombreCompleto { get; set; }
        public string  telefono { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int bhabilitado { get; set; }
        //propiedades adicionales
        public string nombre { get; set; }
        public string aPaterno { get; set; }
        public string aMaterno { get; set; }
        public string fechaCadena { get; set; }
    }
}
