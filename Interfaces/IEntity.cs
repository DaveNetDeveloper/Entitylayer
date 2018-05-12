using System.Collections.Generic; 

public interface IEntity
{
    IModel GetByPrimaryKey(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveByPrimaryKey(int pKValue);
    bool Insert(string nombre); 
    bool UpdateByPrimaryKey(int pKValue, string nombre);
    int GetNextPrimaryKey();
}