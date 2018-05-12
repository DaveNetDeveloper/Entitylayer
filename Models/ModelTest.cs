using System;

public class ModelTest : IModel
{
    #region [ ctors. ]

    public ModelTest() { }
    public ModelTest(ModelTest test)
    {
        Id = test.Id;
        Nombre = test.Nombre;
        Codigo = test.Codigo;
        Descripcion = test.Descripcion;
        Titulo = test.Titulo;
        Clave = test.Clave; 
        Producto = new ModelProducto();
        FechaCreacion = test.FechaCreacion;
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Clave { get; set; } 
    public IModel Producto { get; set; }
    public DateTime FechaCreacion { get; set; }

    #endregion
}