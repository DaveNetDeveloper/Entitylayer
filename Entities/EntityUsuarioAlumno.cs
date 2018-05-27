using System.Collections.Generic;

public class EntityUsuarioAlumno : IEntity
{
    //properties
    public IDaoEntity DaoEntity { get; set; }

    //ctror.
    public EntityUsuarioAlumno()
    {
        DaoEntity = new DaoUsuarioAlumno();
    }

    //methods
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
        return Insert(nombre, string.Empty, string.Empty);
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        return DaoEntity.Insert(nombre, texto2, texto3);
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
}