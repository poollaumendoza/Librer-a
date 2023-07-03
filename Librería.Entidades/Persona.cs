using System.Collections.ObjectModel;

namespace Librería.Entidades
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public TipoDocumento oTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Estado oEstado { get; set; }
    }
}