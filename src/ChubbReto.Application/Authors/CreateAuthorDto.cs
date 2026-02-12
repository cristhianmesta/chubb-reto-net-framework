using System;

namespace ChubbReto.Application.Authors
{
    public class CreateAuthorDto
    {
        public string NombreCompleto { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string CiudadDeProcedencia { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
