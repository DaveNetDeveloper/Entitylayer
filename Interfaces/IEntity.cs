using System.Collections.Generic; 

public interface IEntity
{
    IModel GetById(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveById(int pKValue);
    bool Insert(string nombre); 
    bool UpdateById(int pKValue, string nombre);
}