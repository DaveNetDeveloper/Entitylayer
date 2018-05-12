using System; 
 
public class ModelUsuarioAlumno : IModel
{
    public ModelUsuarioAlumno() { }

    public ModelUsuarioAlumno(int id, string name, string surname, DateTime birthDate, string mail, string userName, string password, bool entered, bool active, string phone, DateTime created, DateTime updated)
    {
        Id = id;
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        UserName = UserName;
        Password = password;
        Entered = entered;
        Active = active;
        Phone = phone;
        Created = created;
        Updated = updated;
    }
 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Mail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool Entered { get; set; }
    public bool Active { get; set; }
    public string Phone { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}