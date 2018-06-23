using MySql.Data.MySqlClient;
using System;
using static BussinesTypedObject;

public class EntityManager
{
    #region [ ctors. ]

    public EntityManager(ProyectNameEnum ProyectName) {
         
    }
     
    //Aqui consultar el proyecto para poder crear la instancia de la enum que toque para el tipo de negocio (esto implica la enum de nombres de tablas de BD)
    public EntityManager(BussinesObjectTypeEnum bussinesObject, ProyectNameEnum ProyectName) {
        InitializeTypes(bussinesObject, ProyectName);
    }

    #endregion 

    #region [ properties ]

    public BussinesTypedObject TypedBO;
    public MySqlConnection DbConnection; //Pendiente usar desde dao, para decidir la base de datos desde presentacion mediante el objeto de negocio

    #endregion

    #region [ public methods ]

    public IEntity GetEntity() {
        return (IEntity)Activator.CreateInstance(TypedBO.BussinesLayerType, args: TypedBO);
    }
    public IModel GetModel() {
        return (IModel)Activator.CreateInstance(TypedBO.ModelLayerType);
    }
    public IDaoEntity GetDAO()
    {
        return (IDaoEntity)Activator.CreateInstance(TypedBO.DataLayerType, args: TypedBO);
    }
     
    public void InitializeTypes(BussinesObjectTypeEnum bussinesObject, ProyectNameEnum ProyectName) {

        TypedBO = new BussinesTypedObject {
            BussinesLayerType = typeof(Entity),
            DataLayerType = typeof(Dao)
        };

        switch (bussinesObject) {
            case BussinesObjectTypeEnum.UsuarioAlumno:
                TypedBO.ModelLayerType = typeof(ModelUsuarioAlumno);
                
                //TypedBO.DataTableName = DataTableNames.User_Alumno;

                //MasterManagerDataTableNames
                //BioIntranetDataTableNames

                TypedBO.DataTableName = (DataTableNames)Enum.Parse(typeof(DataTableNames), "User_Alumno");
                
                //BOTMasterManagerEnum
                //BOTBioIntranet
                break;

            case BussinesObjectTypeEnum.Documento:
                TypedBO.ModelLayerType = typeof(ModelDocumento);
                
                //TypedBO.DataTableName = DataTableNames.Documento;
                TypedBO.DataTableName = (DataTableNames)Enum.Parse(typeof(DataTableNames), bussinesObject.ToString());
                break;
        }

        switch(ProyectName) {
            case ProyectNameEnum.BioIntranet:
                DbConnection = new MySqlConnection("database=qsg265; data source=localhost;user id=dbUser;password=123;persistsecurityinfo=true;sslMode=none;");
                break;

            case ProyectNameEnum.MasterManager:
                DbConnection = new MySqlConnection("database=biointranet; data source=localhost; user id=dbUser; password=123; persistsecurityinfo=true; sslMode=none;");
                break;
        }
    }

    #endregion

    #region [ TODO ]

    //private static string EntityName => "Entity";
    //private static string ModelName => "Model";

    // metodos privados "GetEntityName" que usen contsantes privadas "Entity" y "Model" y "Dao" para construir los
    // nombres de las clases de negocio ui y datos que se utilizan en los switch y en la llamada a instance de reflexion 

    #endregion
}