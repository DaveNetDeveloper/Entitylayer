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
     
    public IModel GetById(int pKValue)
    {   
        return _daoTests.GetById(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoTests.GetList();
    }
    public bool RemoveById(int pKValue)
    {
        return _daoTests.RemoveById(pKValue);
    }
    public bool Insert(string nombre)
    {
        return _daoTests.Insert(nombre, "Descripción del test", string.Empty);
    }
    public bool UpdateById(int pKValue, string nombre)
    {
        return _daoTests.UpdateById(pKValue, nombre);
    }

    #endregion
}