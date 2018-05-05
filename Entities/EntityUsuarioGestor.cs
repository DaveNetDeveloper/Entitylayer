using System.Collections.Generic;

public class EntityUsuarioGestor : IEntity
{
    private DaoUsuarioGestor _daoUsuarioGestor;

    public EntityUsuarioGestor()
    {
        _daoUsuarioGestor = new DaoUsuarioGestor();
    }
    public IModel GetById(int id)
    {   
        return _daoUsuarioGestor.GetById(id); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoUsuarioGestor.GetList();
    }
    public bool RemoveById(int id)
    {
        return _daoUsuarioGestor.RemoveById(id);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, string.Empty, string.Empty);
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        return _daoUsuarioGestor.Insert(nombre, texto2, texto3);
    }
    public bool UpdateById(int id, string nombre)
    {
        return _daoUsuarioGestor.UpdateById(id, nombre);
    }
}