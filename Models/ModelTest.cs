using System;

public class ModelTest : IModel
{
    public ModelTest() { }
    public ModelTest(ModelTest test)
    {
        Id = test.Id;
        Nombre = test.Nombre;
        Codigo = test.Codigo;
        Descripcion = test.Descripcion;
        Titulo = test.Titulo;
        Clave = test.Clave;
        IdPregunta = test.IdPregunta;
        IdProducto = test.IdProducto;
        FechaCreacion = test.FechaCreacion;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Clave { get; set; }
    public int IdPregunta { get; set; }
    public int IdProducto { get; set; }
    public DateTime FechaCreacion { get; set; }
}