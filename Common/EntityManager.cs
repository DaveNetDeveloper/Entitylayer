using System;
using static BussinesTypedObject;

public static class EntityManager
{
    private static BussinesTypedObject TypedBO;
    
    public static IEntity GetEntity() => (IEntity)Activator.CreateInstance(TypedBO.BussinesLayerType, args: TypedBO.ModelLayerType);
    public static IModel GetModel() => (IModel)Activator.CreateInstance(TypedBO.ModelLayerType);

    private static IDaoEntity GetDAO() => (IDaoEntity)Activator.CreateInstance(TypedBO.DataLayerType);

    public static BussinesTypedObject GetBussinesObjectType(BOType bussinesObjectEnum)
    {
        TypedBO = new BussinesTypedObject();
        switch (bussinesObjectEnum)
        {
            case BOType.UsuarioAlumno:
                TypedBO.BussinesLayerType = typeof(EntityUsuarioAlumno);
                TypedBO.ModelLayerType = typeof(ModelUsuarioAlumno);
                TypedBO.DataLayerType = typeof(DaoUsuarioAlumno);
                break;

            case BOType.Documento:
                TypedBO.BussinesLayerType = typeof(EntityDocumento);
                TypedBO.ModelLayerType = typeof(ModelDocumento);
                TypedBO.DataLayerType = typeof(DaoDocumento);
                break;
        }
        return TypedBO;
    }

    private static string EntityName => "Entity";
    private static string ModelName => "Model";

    // metodos privados "GetEntityName" que usen contsantes privadas "Entity" y "Model" y "Dao" para construir los
    // nombres de las clases de negocio ui y datos que se utilizan en los switch y en la llamada a instance de reflexion 
}