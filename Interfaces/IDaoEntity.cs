using System.Collections.Generic;

public interface IDaoEntity
{
    int NextPrimaryKey { get; set; }

    IModel GetByPrimaryKey(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveByPrimaryKey(int pKValue);
    bool Insert(string nombre, string texto2, string texto3);
    bool UpdateByPrimaryKey(int pKValue, string nombre);
    int GetNextPrimaryKey(); 
}