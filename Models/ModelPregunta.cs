using System.Collections.Generic;

public class ModelPregunta : ModelBase, IModel
{
    public ModelPregunta() { }

    public ModelPregunta(int id, string texto, string imagenUrl, string tipo)
    {
        Id = id;
        Texto = texto;
        ImagenUrl = imagenUrl;
        Tipo = tipo;
        Test = new ModelTest();
        Apartado = new ModelApartado();
    }

    public int Id { get; set; }
    public string Texto { get; set; }
    public string ImagenUrl { get; set; }
    public string Tipo { get; set; }

    public IModel Test { get; set; }
    public IModel Apartado { get; set; }
    public IEnumerable<IModel> Respuestas { get; set; }
}