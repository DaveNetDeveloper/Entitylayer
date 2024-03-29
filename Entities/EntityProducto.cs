﻿using System.Collections.Generic;

public class EntityProducto 
{
    public IDaoEntity DaoEntity { get; set; }

    #region [ ctors. ]

    public EntityProducto()
    {
        DaoEntity = new DaoProducto();
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
    private int GetNextPrimaryKey()
    {
        return DaoEntity.GetNextPrimaryKey();
    } 
    public IModel GetByForeignKey()
    {
        return ((DaoProducto)DaoEntity).GetByForeignKey();
    }

    #endregion
}