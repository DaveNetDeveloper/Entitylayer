using System;

public class ModelIdioma : ModelBase, IModel
{
    #region [ ctors. ]

    public ModelIdioma() { }

    #endregion

    #region [ public properties ]

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cultura { get; set; }
    public string Codigo { get; set; }

    #endregion
}