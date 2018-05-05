using System; 
 
public class ModelUserContact : IModel
{
    public ModelUserContact() { }

    public ModelUserContact(string pNombreCompleto, string pTelefono, string pEmail, string pAsunto, string pMensaje)
    {
        NombreCompleto = pNombreCompleto;
        Telefono = pTelefono;
        Email = pEmail;
        Asunto = pAsunto;
        Mensaje = pMensaje;
        FechaHora = DateTime.Now;
    }

    public int Id { get; set; }
    public string NombreCompleto { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Asunto { get; set; }
    public string Mensaje { get; set; }
    public DateTime FechaHora { get; set; }
}