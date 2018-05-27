using System.Collections.Generic;

public class EntityTest : IEntity
{
    public IDaoEntity DaoEntity { get; set; }

    #region [ ctors. ]

    public EntityTest()
    {
        DaoEntity = new DaoTest();
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
        return DaoEntity.Insert(nombre, "Descripción del test", string.Empty);
    }
    public bool Insert(IModel model)
    {
        return DaoEntity.Insert(model);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return DaoEntity.UpdateByPrimaryKey(pKValue, nombre);
    }
    public bool UpdateByPrimaryKey(IModel model)
    {
        return DaoEntity.UpdateByPrimaryKey(model);
    }
    public int GetNextPrimaryKey()
    {
        return DaoEntity.GetNextPrimaryKey();
    }
    public void GetByForeignKey()
    {
        ((DaoTest)DaoEntity).GetByForeignKey();
    }

    #endregion
}