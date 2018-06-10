using System;
using System.Collections.Generic;

public class EntityUsuarioAlumno : IEntity
{
    //properties
    public IDaoEntity DaoEntity { get; set; }

    //ctror.
    public EntityUsuarioAlumno(Type modelClass)
    {
        DaoEntity = new DaoUsuarioAlumno(modelClass);
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
    public bool Insert(IModel model)
    {
        model.Id = GetNextPrimaryKey();
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

    //private methods
    private int GetNextPrimaryKey()
    {
        return DaoEntity.GetNextPrimaryKey();
    }
}