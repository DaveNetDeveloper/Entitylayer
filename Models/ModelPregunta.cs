 
public class ModelPregunta : IModel
{
    public ModelPregunta() { }

    public ModelPregunta(int id, string texto, string imagenUrl, string tipo)
    {
        Id = id;
        Texto = texto;
        ImagenUrl = imagenUrl;
        Tipo = tipo;
    }

    public int Id { get; set; }
    public string Texto { get; set; }
    public string ImagenUrl { get; set; }
    public string Tipo { get; set; } 
}