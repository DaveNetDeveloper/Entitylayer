using System;
using System.Collections.Generic;

public class ModelUsuarioAlumno : IModel
{
    public enum ModelFields
    {
        Id = 0,
        Name = 1,
        Surname = 2,
        BirthDate = 3,
        Mail = 4,
        UserName = 5,
        Password = 6,
        Entered = 7,
        Active = 8,
        Created = 9,
        Updated = 10,
        Phone = 11
    };

    public ModelUsuarioAlumno() { Id = -1; } 
    public ModelUsuarioAlumno(int id, string name, string surname, DateTime birthDate, string mail, string userName, string password, bool entered, bool active, int phone, DateTime created, DateTime updated)
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
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public int Phone { get; set; }
    //public IEnumerable<IModel> Productos { get; set; }
}