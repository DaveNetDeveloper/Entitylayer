 
public class ModelSeccion : ModelBase, IModel
{
    #region [ ctors. ]

    public ModelSeccion() { } 
    public ModelSeccion(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Departamento = new ModelDepartamento();
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public IModel Departamento { get; set; }

    #endregion
}