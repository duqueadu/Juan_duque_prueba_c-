namespace Clientes.DTOs;


    public class ClienteDto
    {
        public int Id { get; set; }              // Identificador único
        public string Identificacion { get; set; }
        public string Nombres { get; set; }       // Nombre del cliente
        public string Apellidos { get; set; }     // Apellido del cliente
        public string Email { get; set; }        // Correo electrónico
        public string Telefono { get; set; }     // Número de contacto
        public DateTime? FechaNacimiento { get; set; }

        public string Direccion { get; set; }    // Dirección física
    }
