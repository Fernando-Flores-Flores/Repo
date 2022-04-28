using System;
using System.Collections.Generic;

namespace Repo.Models
{
    public partial class TipoDocumentoIdentificacion
    {
        public TipoDocumentoIdentificacion()
        {
            Personas = new HashSet<Persona>();
        }

        public int Iidtipodocumento { get; set; }
        public string? Nombre { get; set; }
        public int? Bhabilitado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
