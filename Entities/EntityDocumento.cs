using System.Collections.Generic;

public class EntityDocumento : IEntity
{
    private DaoDocumento _daoDocumentos;

    public EntityDocumento()
    {
        _daoDocumentos = new DaoDocumento();
    }
    public IModel GetById(int id)
    {   
        return _daoDocumentos.GetById(id); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoDocumentos.GetList();
    }
    public bool RemoveById(int id)
    {
        return _daoDocumentos.RemoveById(id);
    }
    public bool Insert(string nombre)
    {
        return _daoDocumentos.Insert(nombre, "Descripción del documento", "xxxx@biosystems.es");
    }
    public bool UpdateById(int id, string nombre)
    {
        return _daoDocumentos.UpdateById(id, nombre);
    }
}