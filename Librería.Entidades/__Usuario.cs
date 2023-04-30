using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librería.Entidades
{
    public class __Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdEstado { get; set; }
    }
}