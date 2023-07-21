namespace Back.Models.DTO
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string fechaNacimiento { get; set; }
        public string CiudadRecidencia { get; set; }
    }
}
