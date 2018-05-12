using System.Collections.Generic;

public class EntityDocumento : IEntity
{
    private DaoDocumento _daoDocumentos;

    #region [ ctors. ]

    public EntityDocumento()
    {
        _daoDocumentos = new DaoDocumento();
    }
     
    #endregion

    #region [ public methods ]

    public IModel GetByPrimaryKey(int pKValue)
    {   
        return _daoDocumentos.GetByPrimaryKey(pKValue); 
    }
    public IEnumerable<IModel> GetList()
    {
        return _daoDocumentos.GetList();
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        return _daoDocumentos.RemoveByPrimaryKey(pKValue);
    }
    public bool Insert(string nombre)
    {
        return _daoDocumentos.Insert(nombre, "Descripción del documento", "xxxx@biosystems.es");
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        return _daoDocumentos.UpdateByPrimaryKey(pKValue, nombre);
    }
    public int GetNextPrimaryKey()
    {



        return 0;
    }
    #endregion
}