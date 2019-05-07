using Realms;
using System;

namespace EndavaForms.Models
{
    public class Estudiantes : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTimeOffset FechaNacimiento { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";

        public string FechaDeNacimiento => FechaNacimiento.Date.ToShortDateString();
    }
}
