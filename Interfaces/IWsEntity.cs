using System.Collections.Generic;

public interface IWsEntity
{
    bool EliminarById(int id);
    IEnumerable<IModel> GetAll();
    //IModel GetById(IModel pModel);
    bool Insertar(string nombre);
    bool UpdateById(int id, string nombre);
}