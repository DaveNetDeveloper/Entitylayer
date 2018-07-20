using System;
using System.Collections.Generic;

public class ModelAlumno : IModel, IModelRelations
{
    public ModelAlumno() => Id = -1;

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

    //Audit fields
    public DateTime Updated { get; set; }
    public DateTime Created { get; set; } 

    //Bindings
    public int idusuariogestor { get; set; }
    public int idrol { get; set; } 

    public ModelRol rol { get; set; }
    public ModelUsuarioGestor usuario_gestor { get; set; }

    public List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    public List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }

    public IList<IList<IModel>> RelationalList { get; set; } 
}