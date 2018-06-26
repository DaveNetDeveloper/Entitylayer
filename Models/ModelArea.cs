using System;

public class ModelArea : ModelBase, IModel
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

    #endregion
}