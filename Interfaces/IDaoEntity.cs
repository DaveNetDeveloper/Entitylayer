using System.Collections.Generic;

public interface IDaoEntity
{
    IModel GetById(int id);
    IEnumerable<IModel> GetList();
    bool Insert(string nombre, string texto2, string texto3);
    bool RemoveById(int id);
    bool UpdateById(int id, string nombre);
}