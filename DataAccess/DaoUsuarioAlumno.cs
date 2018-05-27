using System;
using System.Collections.Generic; 

public class DaoUsuarioAlumno : DaoBase, IDaoEntity
{
    public enum DataTableFields
    {
        id = 0,
        name = 1,
        surname = 2,
        birth_date = 3,
        mail = 4,
        user_name = 5,
        password = 6,
        entered = 7,
        active = 8,
        created = 9,
        updated = 10,
        phone = 11
    };

    #region [ ctors. ]

    public DaoUsuarioAlumno()
    {
        TableName = DataTableNames.USER_ALUMNO;
        PrimaryKeyName = "id"; 
    } 

    #endregion

    #region [ public methods ]

    public IModel GetByPrimaryKey(int pKValue)
    {
        AddNewParameter(PrimaryKeyName, pKValue);
        DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                Model = new ModelUsuarioAlumno();

                for (int fieldIndex = 0; fieldIndex < DrData.FieldCount; fieldIndex++)
                {
                    var fieldType = DrData.GetFieldType(fieldIndex);
                    Object fildValue = GetFieldValue(fieldIndex, fieldType);
                    LoadFieldIntoModel(fieldIndex, fildValue);
                }
            }
        }
        DbConnection.Close();
        MySqlParametersList.Clear();
        Command.Dispose();


        //((ModelUsuarioAlumno)Model).Productos = GetByForeignKey(pKValue);

        // Aqui mirar la nueva propiedad ListOf ForeignKey Field (que contiene el nombre de las tablas relacinadas) y a traves de la
        // propiedad "primaryKeyName" del DAO que sea, sabré el campo primaryKey para filtrar la entidad foranea 
        // Hacer metodo que llame al "SelectByPrimaryKey" de cada DAO que aparezca en la lista de Tablas foraneas
        // y asigne la entidad devuelta a la propiedad foranea en el modelo actual  


        return Model;
    }
    public IEnumerable<IModel> GetList()
    {
        DbConnection = ExecuteDataReader(QueryTypes.SelectAll);
        if (!DrData.IsClosed)
        {
            ModelList = new List<IModel>();
            while (DrData.Read())
            {
                //IModel area = new ModelUsuarioAlumno(DrData.GetFieldType(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                Model = new ModelUsuarioAlumno(); 
                for (int fieldIndex = 0; fieldIndex < DrData.FieldCount; fieldIndex++)
                {
                    var fieldType = DrData.GetFieldType(fieldIndex);
                    Object fildValue = GetFieldValue(fieldIndex, fieldType);
                    LoadFieldIntoModel(fieldIndex, fildValue);
                }
                ModelList.Add(Model);
            }
        }
        DbConnection.Close();
        return ModelList; 
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        AddNewParameter(PrimaryKeyName, pKValue);
        return ExecuteNonQuery(QueryTypes.DeleteByPrimary);
    }
    public bool Insert(string name, string surname, string mail)
    {
        QuerySql = "INSERT INTO @TableName (name, surname, mail) VALUES( @Name, @Surname, @Mail)";
        AddNewParameter("Name", name);
        AddNewParameter("Surname", surname);
        AddNewParameter("Mail", mail);

        // name 
        // surname 
        // birth_date 
        // mail 
        // user_name 
        // password 
        // entered 
        // active 
        // created 
        // updated 
        // phone 
         
        return ExecuteNonQuery();
    }
    public bool Insert(IModel model)
    {
        Model = model;
        //QueryTypes.Insert 
        return true;
    } 
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        QuerySql = $"UPDATE @TableName SET Nombre = @Nombre WHERE ID = @{PrimaryKeyName}";
        AddNewParameter(PrimaryKeyName, pKValue);
        AddNewParameter("Nombre", nombre);

        return ExecuteNonQuery();
    }
    public bool UpdateByPrimaryKey(IModel model)
    {
        Model = model;
        //QueryTypes.UpdateByPrimaryKey
        return true;
    }
    public int GetNextPrimaryKey()
    {
        DbConnection = ExecuteDataReader(QueryTypes.SelectNextPrimaryKey);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                NextPrimaryKey = DrData.GetInt32(0);
            }
        }
        DbConnection.Close();
        if(MySqlParametersList != null) MySqlParametersList.Clear();
        return NextPrimaryKey; 
    }  

    #endregion

    #region [ private methods ]

    private void LoadFieldIntoModel(int fieldIndex, Object fildValue)
    {
        switch (fieldIndex)
        {
            case (int)DataTableFields.id:
                Model.Id = (int)fildValue;
                break;
            case (int)DataTableFields.name:
                ((ModelUsuarioAlumno)Model).Name = (string)fildValue;
                break;
            case (int)DataTableFields.surname:
                ((ModelUsuarioAlumno)Model).Surname = (string)fildValue;
                break;
            case (int)DataTableFields.birth_date:
                ((ModelUsuarioAlumno)Model).BirthDate = (DateTime)fildValue;
                break;
            case (int)DataTableFields.mail:
                ((ModelUsuarioAlumno)Model).Mail = (string)fildValue;
                break;
            case (int)DataTableFields.user_name:
                ((ModelUsuarioAlumno)Model).UserName = (string)fildValue;
                break;
            case (int)DataTableFields.password:
                ((ModelUsuarioAlumno)Model).Password = (string)fildValue;
                break;
            case (int)DataTableFields.entered:
                ((ModelUsuarioAlumno)Model).Entered = ((int)fildValue == 1 ? true : false);
                break;
            case (int)DataTableFields.active:
                ((ModelUsuarioAlumno)Model).Active = ((int)fildValue == 1 ? true : false);
                break;
            case (int)DataTableFields.created:
                ((ModelUsuarioAlumno)Model).Created = (DateTime)fildValue;
                break;
            case (int)DataTableFields.updated:
                ((ModelUsuarioAlumno)Model).Updated = (DateTime)fildValue;
                break;
            case (int)DataTableFields.phone:
                ((ModelUsuarioAlumno)Model).Phone = (int)fildValue;
                break;
        }
    }
    private Object GetFieldValue(int fieldIndex, Type fieldType) //mover a DaoBase?
    {
        Object fieldValue;
        switch (fieldType.Name)
        {
            case "String":
                fieldValue = DrData.GetString(fieldIndex);
                break;
            case "DateTime":
                fieldValue = DrData.GetDateTime(fieldIndex);
                break;
            case "Boolean":
                fieldValue = DrData.GetBoolean(fieldIndex);
                break;
            case "Int32":
                fieldValue = DrData.GetInt32(fieldIndex);
                break;
            case "Decimal":
                fieldValue = DrData.GetDecimal(fieldIndex);
                break;
            default:
                fieldValue = null;
                break;
        }
        return fieldValue;
    }
    private void GetByForeignKey(int pKValue)
    { 

    }

    #endregion
}