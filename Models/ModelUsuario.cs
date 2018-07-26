using System;
using System.Collections.Generic;

public class ModelUsuario : IModel
{
    public ModelUsuario() { }

    public ModelUsuario(int pId, string pNombre, string pLogin, string pPassword, string pApellidos, string pEmail)
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
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    

    //Audit fields
    public DateTime Updated { get; set; }
    public DateTime Created { get; set; }

    public List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    public List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }
}