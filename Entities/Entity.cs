using System;
using System.Collections.Generic;
using BussinesTypedObject;

public class Entity : IEntity
{
    #region [ ctors. ]

    public Entity(BussinesTypes TypedBO) {
        DaoEntity = (IDaoEntity)Activator.CreateInstance(TypedBO.DataLayerType, args: TypedBO);
    }

    #endregion

    #region [ properties ]

    public IDaoEntity DaoEntity { get; set; }

    #endregion
     
    #region [ methods ]

    public IModel GetByPrimaryKey(int pKValue) => DaoEntity.GetByPrimaryKey(pKValue);
    public IEnumerable<IModel> GetList() => DaoEntity.GetList();
    public bool RemoveByPrimaryKey(int pKValue) => DaoEntity.RemoveByPrimaryKey(pKValue);
    public bool Insert(IModel model)
    {
        model.Id = GetNextPrimaryKey();
        return DaoEntity.Insert(model);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre) => DaoEntity.UpdateByPrimaryKey(pKValue, nombre);
    public bool UpdateByPrimaryKey(IModel model) => DaoEntity.UpdateByPrimaryKey(model);
    public bool ExistByPrimaryKey(int pKValue) => DaoEntity.ExistByPrimaryKey(pKValue);
    public int GetNextPrimaryKey() => DaoEntity.GetNextPrimaryKey();

    #endregion 
}