using System.Collections.Generic;

public interface IDaoEntity
{
    IModel GetById(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveById(int pKValue);
    bool Insert(string nombre, string texto2, string texto3);
    bool UpdateById(int pKValue, string nombre);
}