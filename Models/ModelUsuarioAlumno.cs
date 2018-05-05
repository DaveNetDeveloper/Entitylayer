using System; 
 
public class ModelUsuarioAlumno : IModel
{
    public ModelUsuarioAlumno() { }

    public ModelUsuarioAlumno(int pId, string pNombre, string pApellidos, string pEmail, DateTime pFechaNacimiento, int pTelefono)
    {
        Id = pId;
        Nombre = pNombre;
        Apellidos = Apellidos;
        Email = pEmail;
        FechaNacimiento = pFechaNacimiento;
        Telefono = pTelefono;

    }
 
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string NombreUsuario { get; set; }
    public bool Activo { get; set; }
    public bool HaIniciadoSesion { get; set; }
    public string Password { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }
}