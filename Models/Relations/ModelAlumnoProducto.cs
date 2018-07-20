using System;
 
public class ModelAlumnoProducto : ModelBase
{
    public ModelAlumnoProducto() { }

    public int IdAlumno { get; set; }
    public int IdProdcuto { get; set; }

    public ModelAlumno Alumno { get; set; }
    public ModelProducto Producto { get; set; }
}