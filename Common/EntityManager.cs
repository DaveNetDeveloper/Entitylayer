using System;

public class EntityManager
{
    #region [ ctors. ]

    public EntityManager() {
    }

    #endregion 

    #region [ properties ]

    private BussinesTypedObject _typedBO;
    public BussinesTypedObject TypedBO => _typedBO;

    #endregion

    #region [ public methods ]

    public IEntity GetEntity() => (IEntity)Activator.CreateInstance(_typedBO.BussinesLayerType, args: _typedBO);
    public IModel GetModel() => (IModel)Activator.CreateInstance(_typedBO.ModelLayerType);

    public void InitializeTypes(BussinesTypedObject.BussinesObjectTypeEnum bussinesObject)
    {
        _typedBO = new BussinesTypedObject();
        switch (bussinesObject)
        {
            case BussinesTypedObject.BussinesObjectTypeEnum.UsuarioAlumno:
                //_typedBO.BussinesLayerType = typeof(EntityUsuarioAlumno);
                _typedBO.ModelLayerType = typeof(ModelUsuarioAlumno);
                //_typedBO.DataLayerType = typeof(DaoUsuarioAlumno);
                _typedBO.DataTableName = DaoBase.DataTableNames.User_Alumno;
                break;

            case BussinesTypedObject.BussinesObjectTypeEnum.Documento:
                //_typedBO.BussinesLayerType = typeof(EntityDocumento);
                _typedBO.ModelLayerType = typeof(ModelDocumento);
                //_typedBO.DataLayerType = typeof(DaoDocumento);
                _typedBO.DataTableName = DaoBase.DataTableNames.Documento;
                break;
        }

        _typedBO.BussinesLayerType = typeof(Entity);
        _typedBO.DataLayerType = typeof(Dao);
    }

    #endregion 

    #region [ private methods ]

    private IDaoEntity GetDAO() => (IDaoEntity)Activator.CreateInstance(_typedBO.DataLayerType, args: _typedBO);

    #endregion

    #region [ TODO ]

    //private static string EntityName => "Entity";
    //private static string ModelName => "Model";

    // metodos privados "GetEntityName" que usen contsantes privadas "Entity" y "Model" y "Dao" para construir los
    // nombres de las clases de negocio ui y datos que se utilizan en los switch y en la llamada a instance de reflexion 

    #endregion
}