namespace Clientes.DTOs;


    public class ClienteDto
    {
        public int Id { get; set; }              // Identificador �nico
        public string Identificacion { get; set; }
        public string Nombres { get; set; }       // Nombre del cliente
        public string Apellidos { get; set; }     // Apellido del cliente
        public string Email { get; set; }        // Correo electr�nico
        public string Telefono { get; set; }     // N�mero de contacto
        public DateTime? FechaNacimiento { get; set; }

        public string Direccion { get; set; }    // Direcci�n f�sica
    }
