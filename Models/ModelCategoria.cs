public class ModelCategoria : ModelBase, IModel
{
    #region [ ctors. ]

    public ModelCategoria() { } 
    public ModelCategoria(int id, string nombre, string descripcion)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion; 
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    #endregion
}