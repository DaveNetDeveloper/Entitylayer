using System;

public class ModelDocumento : IModel
{
    public ModelDocumento() { }

    public ModelDocumento(int id, string nombre, string ubicacion, string descripcion, string tipo)
    {
        Id = id;
        Nombre = nombre;
        Ubicacion = ubicacion;
        Descripcion = descripcion;
        Tipo = tipo;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public string Descripcion { get; set; }
    public int Tamaño { get; set; }
    public string Tipo { get; set; }
    public int IdSeccion { get; set; } 
    public DateTime FechaCreacion { get; set; }
}