using System.Collections.Generic;

public class EntityUsuarioAlumno : IEntity
{
    private DaoUsuarioAlumno _daoUsuarioAlumno;

    public EntityUsuarioAlumno()
    {
        _daoUsuarioAlumno = new DaoUsuarioAlumno();
    }
    public IModel GetById(int id)
    {   
        return _daoUsuarioAlumno.GetById(id); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoUsuarioAlumno.GetList();
    }
    public bool RemoveById(int id)
    {
        return _daoUsuarioAlumno.RemoveById(id);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, string.Empty, string.Empty);
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        return _daoUsuarioAlumno.Insert(nombre, texto2, texto3);
    }
    public bool UpdateById(int id, string nombre)
    {
        return _daoUsuarioAlumno.UpdateById(id, nombre);
    }
}