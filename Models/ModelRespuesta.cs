 
public class ModelRespuesta : IModel
{
    public ModelRespuesta() { }

    public ModelRespuesta(int id, string texto, int idPregunta, string solucionCorrecta)
    {
        Id = id;
        Texto = texto;
        IdPregunta = idPregunta;
        SolucionCorrecta = solucionCorrecta;
    }

    public int Id { get; set; }
    public string Texto { get; set; }
    public int IdPregunta { get; set; }
    public string SolucionCorrecta { get; set; } 
}