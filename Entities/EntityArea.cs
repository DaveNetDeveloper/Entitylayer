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
     
    public IModel GetById(int pKValue)
    {   
        return _daoAreas.GetById(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoAreas.GetList();
    }
    public bool RemoveById(int pKValue)
    {
        return _daoAreas.RemoveById(pKValue);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, "Descripción del area", "nombre@mail.com");
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        return _daoAreas.Insert(nombre, descripcion, responsable);
    }
    public bool UpdateById(int pKValue, string nombre)
    {
        return _daoAreas.UpdateById(pKValue, nombre);
    }
    
    #endregion
}