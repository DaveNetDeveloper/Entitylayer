﻿using System.Collections.Generic;

public interface IDaoEntity
{ 
    IModel GetByPrimaryKey(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveByPrimaryKey(int pKValue);
   // bool Insert(string nombre, string texto2, string texto3);
    bool Insert(IModel model);
    bool UpdateByPrimaryKey(int pKValue, string nombre);
    bool UpdateByPrimaryKey(IModel model);
    int GetNextPrimaryKey();
    bool ExistByPrimaryKey(int pKValue);
}