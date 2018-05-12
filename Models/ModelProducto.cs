public class ModelProducto : IModel
{
    #region [ ctors. ]

    public ModelProducto() { } 
    public ModelProducto(int id, string nombre, string descripcion, string codigo)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Codigo = codigo;
        Precio = 0;

        //Bind By Foreing Key
        //Categoria =  
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Codigo { get; set; } 
    public decimal Precio { get; set; } 
    public IModel Categoria { get; set; }

    #endregion
}