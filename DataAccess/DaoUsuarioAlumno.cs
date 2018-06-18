using System;
using System.Collections.Generic;
using System.Reflection;

public class DaoUsuarioAlumno : DaoBase, IDaoEntity
{
    #region [ ctors. ]

    public DaoUsuarioAlumno(BussinesTypedObject TypedBO) => InitializeData(TypedBO.ModelLayerType, TypedBO.DataTableName);

    #endregion 

    #region [ public methods ]

    public IModel GetByPrimaryKey(int pKValue)
    {
        try {
            AddNewParameter(PrimaryKeyName, pKValue);
            DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);

            if (!DrData.IsClosed) {
                while (DrData.Read()) {
                    for (int fieldIndex = 0; fieldIndex < DrData.FieldCount; fieldIndex++) {
                        var fieldType = DrData.GetFieldType(fieldIndex);
                        SetFieldValueIntoModel(fieldIndex, fieldType);
                    }
                }
            } 
            #region [GetByForeignKey]

            //((ModelUsuarioAlumno)Model).Productos = GetByForeignKey(pKValue);
            // Aqui mirar la nueva propiedad ListOf ForeignKey Field (que contiene el nombre de las tablas relacinadas) y a traves de la
            // propiedad "primaryKeyName" del DAO que sea, sabré el campo primaryKey para filtrar la entidad foranea 
            // Hacer metodo que llame al "SelectByPrimaryKey" de cada DAO que aparezca en la lista de Tablas foraneas
            // y asigne la entidad devuelta a la propiedad foranea en el modelo actual 

            #endregion
        }
        catch (Exception ex) {
            throw ex;
        }
        finally {
            DbConnection.Close();
            MySqlParametersList.Clear();
            Command.Dispose();
        }  
        return Model;
    }
    public IEnumerable<IModel> GetList()
    {
        DbConnection = ExecuteDataReader(QueryTypes.SelectAll);
        if (!DrData.IsClosed) {

            ModelList = new List<IModel>();
            while (DrData.Read()) {
                Model = (IModel)Activator.CreateInstance(ModelClass);
                for (int fieldIndex = 0; fieldIndex < DrData.FieldCount; fieldIndex++) {
                    var fieldType = DrData.GetFieldType(fieldIndex);
                    SetFieldValueIntoModel(fieldIndex, fieldType); 
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
    public bool Insert(IModel model)
    {
        Model = model;

        var i = 0;
        foreach (PropertyInfo property in ModelClass.GetProperties()) {
            if (i < FieldsList.Count) { 
                var propertyValue = model.GetType().GetProperty(property.Name).GetValue(model, null);
                var pos = FieldsList[i].Ordinal_Position - 1;
                AddNewParameter(FieldsList[pos].Column_Name, propertyValue);
            } i++;
        }
        return ExecuteNonQuery(QueryTypes.Insert);
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
        if (!DrData.IsClosed) {
            while (DrData.Read()) {
                NextPrimaryKey = DrData.GetInt32(0);
            }
        }

        DbConnection.Close();
        if(MySqlParametersList != null) MySqlParametersList.Clear();
        return NextPrimaryKey; 
    }  

    #endregion

    #region [ private methods ]

    private void GetByForeignKey(int pKValue)
    { 

    }
    private void InitializeData(Type modelClass, DataTableNames dataTableName)
    {
        ModelClass = modelClass;
        TableName = dataTableName;
        FillFielsListFromDataTable();
    }

    #endregion
}