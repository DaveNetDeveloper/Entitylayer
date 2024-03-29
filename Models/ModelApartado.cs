﻿ 
public class ModelApartado : ModelBase, IModel
{
    #region [ ctors. ]

    public ModelApartado() { } 
    public ModelApartado(int id, string nombre, string descripcion, string imagen)
    {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
        Imagen = imagen;
        Producto = new ModelProducto();
    }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public IModel Producto { get; set; }

    #endregion
}