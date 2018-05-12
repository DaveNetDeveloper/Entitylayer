using System.Collections.Generic;

public class EntityTest : IEntity
{
    private DaoTest _daoTests;

    #region [ ctors. ]

    public EntityTest()
    {
        _daoTests = new DaoTest();
    }

    #endregion

    #region [ public methods ]
     
    public IModel GetByPrimaryKey(int pKValue)
    {   
        return _daoTests.GetByPrimaryKey(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoTests.GetList();
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        return _daoTests.RemoveByPrimaryKey(pKValue);
    }
    public bool Insert(string nombre)
    {
        return _daoTests.Insert(nombre, "Descripción del test", string.Empty);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return _daoTests.UpdateByPrimaryKey(pKValue, nombre);
    }
    public int GetNextPrimaryKey()
    {
         
        return 0;
    }
    #endregion
}