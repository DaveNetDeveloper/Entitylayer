using System;
using MySql.Data.MySqlClient; 
using BussinesTypedObject;
using static BussinesTypedObject.BussinesTypes;

public class EntityManager
{
    #region [ ctors. ]

    public EntityManager(ProyectName ProyectName) {
         
    }
    public EntityManager(BussinesObjectType bussinesObject, ProyectName ProyectName) {
        InitializeTypes(bussinesObject, ProyectName);
    }

    #endregion 

    #region [ properties ]

    public BussinesTypes TypedBO;
    public MySqlConnection DbConnection;

    #endregion

    #region [ methods ]

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
    public void InitializeTypes(BussinesObjectType bussinesObject, ProyectName ProyectName) {

        TypedBO = new BussinesTypes {
            BussinesLayerType = typeof(Entity),
            DataLayerType = typeof(Dao)
        };

        switch (bussinesObject) {
            case BussinesObjectType.Alumno:
                TypedBO.ModelLayerType = typeof(ModelAlumno);
                TypedBO.DataTableName = (DataTableNames)Enum.Parse(typeof(DataTableNames), TableNameTreatment(BussinesObjectType.Alumno.ToString()));
                break;
            case BussinesObjectType.Usuario_Gestor:
                TypedBO.ModelLayerType = typeof(ModelUsuarioGestor);
                TypedBO.DataTableName = (DataTableNames)Enum.Parse(typeof(DataTableNames), TableNameTreatment(BussinesObjectType.Usuario_Gestor.ToString()));
                break;
            //case BussinesObjectType.Documento:
            //    TypedBO.ModelLayerType = typeof(ModelDocumento);
            //    TypedBO.DataTableName = (DataTableNames)Enum.Parse(typeof(DataTableNames), TableNameTreatment(bussinesObject.ToString()));
            //    break;
        }

        switch(ProyectName) {
            case ProyectName.BioIntranet:
                DbConnection = new MySqlConnection("database=biointranet; data source=localhost; user id=dbUser; password=123; persistsecurityinfo=true; sslMode=none;");
                break;
            case ProyectName.MasterManager:
                DbConnection = new MySqlConnection("database=qsg265; data source=localhost;user id=dbUser;password=123;persistsecurityinfo=true;sslMode=none;");
                break;
        }
    }

    private string TableNameTreatment(string str)
    {
        if (str.Length > 1) {
            var primeraMayuscula = char.ToUpper(str[0]) + str.Substring(1);

            if (primeraMayuscula.Contains("_")) {
                var posGuion = primeraMayuscula.IndexOf("_");
                var primeraParte = primeraMayuscula.Substring(0, posGuion);
                var segundaParte = primeraMayuscula.Substring(posGuion);
                segundaParte = char.ToUpper(segundaParte[0]) + segundaParte.Substring(1);
                return primeraParte + segundaParte;
            }
            else { return primeraMayuscula; }
        }
        return str.ToUpper();
    }

    #endregion

}