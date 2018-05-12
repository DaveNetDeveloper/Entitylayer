using System.Collections.Generic;

public class EntityArea : IEntity
{
    private DaoArea _daoAreas;

    #region [ ctors. ]

    public EntityArea()
    {
        _daoAreas = new DaoArea();
    }

    #endregion

    #region [ public methods ]
     
    public IModel GetByPrimaryKey(int pKValue)
    {   
        return _daoAreas.GetByPrimaryKey(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoAreas.GetList();
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        return _daoAreas.RemoveByPrimaryKey(pKValue);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, "Descripción del area", "nombre@mail.com");
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        return _daoAreas.Insert(nombre, descripcion, responsable);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return _daoAreas.UpdateByPrimaryKey(pKValue, nombre);
    }
    public int GetNextPrimaryKey()
    {



        return 0;
    }
    #endregion
}