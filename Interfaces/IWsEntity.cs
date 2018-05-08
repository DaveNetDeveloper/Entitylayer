using System.Collections.Generic;

public interface IWsEntity
{
    bool EliminarById(int pKValue);
    IEnumerable<IModel> GetAll();
    //IModel GetById(IModel model);
    bool Insertar(string nombre);
    bool UpdateById(int pKValue, string nombre);
}