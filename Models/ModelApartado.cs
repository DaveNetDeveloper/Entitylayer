 
public class ModelApartado : IModel
{
    public ModelApartado() { }

    public ModelApartado(int id, string nombre, string descripcion, string imagen)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Imagen = imagen;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; } 
}