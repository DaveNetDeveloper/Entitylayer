using System.Collections.Generic;

public class EntityDocumento : IEntity
{
    private DaoDocumento _daoDocumentos;

    public EntityDocumento()
    {
        _daoDocumentos = new DaoDocumento();
    }
    public IModel GetById(int pKValue)
    {   
        return _daoDocumentos.GetById(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoDocumentos.GetList();
    }
    public bool RemoveById(int pKValue)
    {
        return _daoDocumentos.RemoveById(pKValue);
    }
    public bool Insert(string nombre)
    {
        return _daoDocumentos.Insert(nombre, "Descripción del documento", "xxxx@biosystems.es");
    }
    public bool UpdateById(int pKValue, string nombre)
    {
        return _daoDocumentos.UpdateById(pKValue, nombre);
    }
}