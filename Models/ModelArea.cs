using System;

public class ModelArea : IModel
{
    #region [ ctors. ]

    public ModelArea() { } 
    public ModelArea(int id, string ip, string ciudad, string region)
    {
        Id = id;
        IP = ip;
        Ciudad = ciudad;
        Region = region;
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string IP { get; set; }
    public string Ciudad { get; set; }
    public string Region { get; set; }
    public string Latitud { get; set; }
    public string Longitud { get; set; }
    public string ZonaHoraria { get; set; }
    public string Pais { get; set; }
    public string CodigoPais { get; set; }
    public string CodigoZIP { get; set; }
    public DateTime FechaHora { get; set; }
    public string NavegadorLenguaje { get; set; }
    public string NavegadorCookkies { get; set; }
    public string NavegadorPlataforma { get; set; }
    public string NavegadorAgente { get; set; }
    public string NavegadorCompañia { get; set; }
    public string NavegadorProducto { get; set; }
    public string SessionID { get; set; }
    public string SessionStartTicks { get; set; }

    #endregion
}