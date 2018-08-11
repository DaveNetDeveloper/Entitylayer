using BussinesTypedObject;
using System;
using System.Collections.Generic;
using System.Reflection;

public class Dao : DaoBase, IDaoEntity
{
    #region [ ctors. ]

    public Dao(BussinesTypes TypedBO) {
        InitializeData(TypedBO.ModelLayerType, TypedBO.DataTableName);
    }

    #endregion 

    #region [ methods ]

    public IModel GetByPrimaryKey(int pKValue)
    {
        try {
            AddNewParameter(PrimaryKeyName, pKValue);
            DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary); 
            if (!DrData.IsClosed) {
                while (DrData.Read()) {
                    for (int fieldIndex = 0; fieldIndex < DrData.FieldCount; fieldIndex++) {
                        var fieldType = DrData.GetFieldType(fieldIndex);
                        SetTypedFieldValueIntoModel(fieldIndex, fieldType);
                    }
                }
            } 
            FillInputDataRelationsByForeignKeys();
            if (IsRelationalInterfaceImplemented) FillOutputDataRelationsByForeignKeys(); 
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
                    SetTypedFieldValueIntoModel(fieldIndex, fieldType); 
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
    public bool ExistByPrimaryKey(int pKValue)
    {
        try {
            AddNewParameter(PrimaryKeyName, pKValue);
            DbConnection = ExecuteDataReader(QueryTypes.ExistByPrimary);
            if (!DrData.IsClosed) {
                while (DrData.Read()) {
                    return DrData.GetInt32(0) > 0;
                }
            }
            return false;
        }
        finally {
            DbConnection.Close();
            if (MySqlParametersList != null) MySqlParametersList.Clear();
        }
    }
    public int GetNextPrimaryKey() {
        int nextPrimaryKey = 0;
        DbConnection = ExecuteDataReader(QueryTypes.SelectNextPrimaryKey);
        if (!DrData.IsClosed) {
            while (DrData.Read()) {
                nextPrimaryKey = DrData.GetInt32(0);
            }
        }

        DbConnection.Close();
        if (MySqlParametersList != null) MySqlParametersList.Clear();
        return nextPrimaryKey;
    }
  
    #endregion
}