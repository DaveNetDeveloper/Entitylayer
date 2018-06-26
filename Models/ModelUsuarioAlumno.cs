using System;
 
public class ModelUsuarioAlumno : ModelBase, IModel
{
    public ModelUsuarioAlumno() => Id = -1;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Mail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool Entered { get; set; }
    public bool Active { get; set; } 
    public int Phone { get; set; }
    public int idusuariogestor { get; set; }
    public int idrol { get; set; }
     
    public ModelRol rol { get; set; }
    public ModelUsuarioGestor usuario_gestor { get; set; }

    //TODO Lista de elementos foraneo -> Tabla relaciones 1-n
    //public IEnumerable<IModel> Productos { get; set; }
}