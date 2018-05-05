
using System;

public class ModelConvocatoria : IModel
{
    public ModelConvocatoria() { }

    public ModelConvocatoria(int id, string nombre, string descripcion, DateTime fecha)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Fecha = fecha;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime Fecha { get; set; } 
}