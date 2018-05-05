using System.Collections.Generic; 

public interface IEntity
{
    IModel GetById(int id);
    IEnumerable<IModel> GetList();
    bool RemoveById(int id);
    bool Insert(string nombre);// string descripcion, string responsable
    //bool Insert(IModel model);
    bool UpdateById(int id, string nombre);
}