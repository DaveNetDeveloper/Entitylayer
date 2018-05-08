using System.Collections.Generic; 

public interface IEntity
{
    IModel GetById(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveById(int pKValue);
    bool Insert(string nombre);// string descripcion, string responsable
    //bool Insert(IModel model);
    bool UpdateById(int pKValue, string nombre);
}