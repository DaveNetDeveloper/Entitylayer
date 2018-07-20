using System;
using System.Collections.Generic;

public class ModelAlumnoProducto : IModel
{
    public ModelAlumnoProducto() { }

    public int Id { get; set; }

    public int IdAlumno { get; set; }
    public int IdProdcuto { get; set; }

    public ModelAlumno Alumno { get; set; }
    public ModelProducto Producto { get; set; }

    public DateTime Updated { get; set; }
    public DateTime Created { get; set; }

    public List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    public List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }
}