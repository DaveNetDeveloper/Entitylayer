using System;

public class ModelPais : ModelBase, IModel
{
    #region [ ctors. ]

    public ModelPais() { }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public int Prefijo { get; set; }

    #endregion
}