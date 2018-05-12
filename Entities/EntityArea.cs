using System.Collections.Generic;

public class EntityArea : IEntity
{
    public IDaoEntity DaoEntity { get; set; }

    #region [ ctors. ]

    public EntityArea()
    {
        DaoEntity = new DaoArea();
    }

    #endregion

    #region [ public methods ]
     
    public IModel GetByPrimaryKey(int pKValue)
    {   
        return DaoEntity.GetByPrimaryKey(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return DaoEntity.GetList();
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        return DaoEntity.RemoveByPrimaryKey(pKValue);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, "Descripción del area", "nombre@mail.com");
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        return DaoEntity.Insert(nombre, descripcion, responsable);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return DaoEntity.UpdateByPrimaryKey(pKValue, nombre);
    }
    public int GetNextPrimaryKey()
    {
        return DaoEntity.GetNextPrimaryKey();
    }

    #endregion
}