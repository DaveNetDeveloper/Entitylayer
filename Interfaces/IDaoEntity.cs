using System.Collections.Generic;

public interface IDaoEntity
{
    IModel GetById(int pKValue);
    IEnumerable<IModel> GetList();
    bool Insert(string nombre, string texto2, string texto3);
    bool RemoveById(int pKValue);
    bool UpdateById(int pKValue, string nombre);
}