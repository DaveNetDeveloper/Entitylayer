public class ModelUsuarioGestor : IModel
{
    public ModelUsuarioGestor() { }

    public ModelUsuarioGestor(int pId, string pNombre, string pLogin, string pPassword, string pApellidos, string pEmail)
    {
        Id = pId;
        Nombre = pNombre;
        Apellidos = pApellidos;
        Email = pEmail; 
        Login = pLogin;
        Password = pPassword;
    } 

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; } 
}