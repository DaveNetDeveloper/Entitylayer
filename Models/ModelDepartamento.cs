
 
public class ModelDepartamento : IModel
{
    #region [ ctors. ]

    public ModelDepartamento() { } 
    public ModelDepartamento(int id, string nombre, string descripcion, string responsable)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Responsable = responsable;
        Area = new ModelArea();
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Responsable { get; set; }
    public IModel Area { get; set; }

    #endregion
}