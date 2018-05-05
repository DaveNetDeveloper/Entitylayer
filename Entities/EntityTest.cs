using System.Collections.Generic;

public class EntityTest : IEntity
{
    private DaoTest _daoTests;

    public EntityTest()
    {
        _daoTests = new DaoTest();
    }
    public IModel GetById(int id)
    {   
        return _daoTests.GetById(id); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoTests.GetList();
    }
    public bool RemoveById(int id)
    {
        return _daoTests.RemoveById(id);
    }
    public bool Insert(string nombre)
    {
        return _daoTests.Insert(nombre, "Descripción del test", string.Empty);
    }
    public bool UpdateById(int id, string nombre)
    {
        return _daoTests.UpdateById(id, nombre);
    }
}