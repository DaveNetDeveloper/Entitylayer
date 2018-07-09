using System;
 
public class ModelUsuarioProducto : ModelBase
{
    public ModelUsuarioProducto() { }

    public int IdUsuario { get; set; }
    public int IdProdcuto { get; set; }

    public ModelUsuarioAlumno usuario_Alumno { get; set; }
    public ModelProducto producto { get; set; }
}