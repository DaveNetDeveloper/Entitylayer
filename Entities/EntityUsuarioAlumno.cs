using System.Collections.Generic;

public class EntityUsuarioAlumno : IEntity
{
    private DaoUsuarioAlumno _daoUsuarioAlumno;

    public EntityUsuarioAlumno()
    {
        _daoUsuarioAlumno = new DaoUsuarioAlumno();
    }

    public IModel GetByPrimaryKey(int pKValue)
    {   
        return _daoUsuarioAlumno.GetByPrimaryKey(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoUsuarioAlumno.GetList();
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        return _daoUsuarioAlumno.RemoveByPrimaryKey(pKValue);
    }
    public bool Insert(string nombre)
    {
        return Insert(nombre, string.Empty, string.Empty);
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        return _daoUsuarioAlumno.Insert(nombre, texto2, texto3);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return _daoUsuarioAlumno.UpdateByPrimaryKey(pKValue, nombre);
    }
    public int GetNextPrimaryKey()
    {
        return _daoUsuarioAlumno.GetNextPrimaryKey();
    }
}