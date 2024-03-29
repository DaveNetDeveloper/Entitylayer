﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Runtime.Remoting;
using System.Reflection;
using BussinesTypedObject;
using System.Linq;

public class DaoBase
{
    #region [ constants ]

    private const string mySqPrimaryKey = "PRI";
    private const string mySqForeingKey = "MUL"; 
    private const string modelLiteral = "Model"; 
    private const string ConnectionString = "database = qsg265; data source = localhost; user id = dbUser; password = 123; persistsecurityinfo = true; sslMode = none;";
    private const string Connection_biointranet = "database=biointranet; data source=localhost; user id=dbUser; password=123; persistsecurityinfo=true; sslMode=none;";

    #endregion

    #region [ enums ]

    protected enum QueryTypes {
        SelectAll,
        SelectByPrimary,
        UpdateByPrimary,
        Insert,
        DeleteByPrimary,
        SelectNextPrimaryKey,
        SelectInputForeignRelationsDefinition,
        SelectOutputForeignRelationsDefinition,
        SelectFieldsDefinition,
        ExistByPrimary,
        Custom
    };

    #endregion

    #region [ properties ]

    protected Type ModelClass { get; set; } 
    protected IModel Model
    {
        get {
            if (_model == null) _model = ModelManager.CreateModelInstanceByType(ModelClass);
            return _model;
        }
        set {
            _model = value;
        }
    }
    protected PropertyInfo[] GetModelProperties
    {
        get {
            return ModelClass.GetProperties();
        }
    }
    protected List<IModel> ModelList { get; set; }

    protected BussinesTypes.DataTableNames TableName { get; set; }
    protected string PrimaryKeyName { get; set; }
    protected List<string> ForeignkeysNames { get; set; }
    protected QueryTypes QueryType { get; set; }
    protected String QuerySql { get; set; }
    protected MySqlCommand Command { get; set; }
    protected MySqlDataReader DrData { get; set; }
    protected MySqlConnection DbConnection { get; set; }
    protected List<MySqlParameter> MySqlParametersList { get; set; } 

    protected List<ModelDataBaseField> FieldsList { get; set; }
    protected List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    protected List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }
    protected bool IsRelationalInterfaceImplemented
    {
        get {
            if (null != ((TypeInfo)ModelClass) && null != ((TypeInfo)ModelClass).ImplementedInterfaces && ((TypeInfo)ModelClass).ImplementedInterfaces.Count() > 0) {
                var hasInterefaces = false;
                var auxInterefaces =  (from interfaces in ((TypeInfo)ModelClass).ImplementedInterfaces
                        where interfaces.Equals(typeof(IModelRelations))
                        select interfaces)?.FirstOrDefault();
                if (auxInterefaces != null) hasInterefaces = true;
                return hasInterefaces;
            } else { return false; }
        }
    }

    private string CurrenAssembly => Assembly.GetExecutingAssembly().GetName().Name;
    private IModel _model;

    #endregion

    #region [ methods ]

    protected MySqlConnection ExecuteDataReader(QueryTypes pQueryType)
    {
        QueryType = pQueryType;
        InitializeConnection(); 
        DrData = Command.ExecuteReader();
        return (DrData != null) ? DbConnection : null;
    }
    protected bool ExecuteNonQuery(QueryTypes pQueryType)
    {
        try {
            QueryType = pQueryType;
            InitializeConnection();
            int affectedRecords = Command.ExecuteNonQuery();
            DbConnection.Close();
            MySqlParametersList.Clear();
            return affectedRecords > 0; 
        }
        catch {
            DbConnection.Close();
            MySqlParametersList.Clear();
            return false;
        } 
    }
    protected bool ExecuteNonQuery()
    {
        InitializeConnection();
        int affectedRecords = Command.ExecuteNonQuery();
        DbConnection.Close();
        MySqlParametersList.Clear();
        return affectedRecords > 0; ;
    }
    protected void AddNewParameter(string nombreParam, object value)
    {
        if (null == MySqlParametersList) MySqlParametersList = new List<MySqlParameter>();
        MySqlParametersList.Add(new MySqlParameter(nombreParam, value));
    }

    protected void SetTypedFieldValueIntoModel(int fieldIndex, Type fieldType)
    {
        Object fieldValue = null; 
        switch (fieldType.Name) {
            case "String":
                fieldValue = DrData.GetString(fieldIndex);
                break;
            case "DateTime":
            case "Date":
                fieldValue = DrData.GetDateTime(fieldIndex);
                break;
            case "Boolean":
                fieldValue = DrData.GetBoolean(fieldIndex);
                break;
            case "Int32":
            case "Int64":
                fieldValue = DrData.GetInt32(fieldIndex);
                break;
            case "Decimal":
                fieldValue = DrData.GetDecimal(fieldIndex);
                break;
        }

        SetValueWhenPropertyIsBoolean(ref fieldValue, fieldIndex, fieldType); //Special case for db integer value for boolean properties into Model
        SetValueToModelProperty(fieldValue, fieldIndex);   
    }  

    protected List<ModelDataBaseField> GetFielsDefinitionList()
    {
        QueryType = QueryTypes.SelectFieldsDefinition;
        QuerySql = GetSqlQueryByType();
        MySqlConnection cnn = new MySqlConnection(ConnectionString);
        MySqlCommand mc = new MySqlCommand(QuerySql, cnn);
        cnn.Open();
        MySqlDataReader DataReader = mc.ExecuteReader();

        if (!DataReader.IsClosed) {

            ForeignkeysNames = new List<string>();
            FieldsList = new List<ModelDataBaseField>();

            while (DataReader.Read()) {
                if(DataReader.GetString(5).ToUpper().Equals(mySqPrimaryKey)) { 
                    PrimaryKeyName = String.IsNullOrEmpty(PrimaryKeyName) ? DataReader.GetString(1) : $"{PrimaryKeyName},{DataReader.GetString(1)}";
                }
                else if (DataReader.GetString(5).ToUpper().Equals(mySqForeingKey)) {
                    ForeignkeysNames.Add(DataReader.GetString(1));
                }

                FieldsList.Add (
                    new ModelDataBaseField() {
                        Data_Type = DataReader.GetString(0),
                        Column_Name = DataReader.GetString(1),
                        Ordinal_Position = DataReader.GetInt32(2),
                        Is_Nullable = DataReader.GetString(3).ToUpper() == "YES" ? true : false,
                        Character_Maximum_Length = DataReader.IsDBNull(4) ? 0 : DataReader.GetInt32(4),
                        Column_Key = DataReader.GetString(5)
                    } );
            }
        } cnn.Close();
        return FieldsList;
    } 
    protected void GetInputForeingKeysDefinitionList()
    {
        QueryType = QueryTypes.SelectInputForeignRelationsDefinition;
        QuerySql = GetSqlQueryByType();
        MySqlConnection cnn = new MySqlConnection(ConnectionString);
        MySqlCommand mc = new MySqlCommand(QuerySql, cnn);
        cnn.Open();
        MySqlDataReader auxDR = mc.ExecuteReader();

        if (!auxDR.IsClosed) {
            FkInputRelationsList = new List<ModelDataBaseFKRelation>();
            while (auxDR.Read()) {
                FkInputRelationsList.Add(
                    new ModelDataBaseFKRelation()
                    {
                        ColumnName = auxDR.GetString(0),
                        ConstraintName = auxDR.GetString(1),
                        ReferencedTableName = auxDR.GetString(2),
                        ReferencedColumnName = auxDR.GetString(3),
                        TableName = auxDR.GetString(4)
                    });
            }
            Model.FkInputRelationsList = FkInputRelationsList;
        }
        cnn.Close();
    }
    protected void GetOutputForeingKeysDefinitionList()
    {
        QueryType = QueryTypes.SelectOutputForeignRelationsDefinition;
        QuerySql = GetSqlQueryByType();
        MySqlConnection cnn = new MySqlConnection(ConnectionString);
        MySqlCommand mc = new MySqlCommand(QuerySql, cnn);
        cnn.Open();
        MySqlDataReader auxDR = mc.ExecuteReader();

        if (!auxDR.IsClosed) {
            FkOutputRelationsList = new List<ModelDataBaseFKRelation>();
            while (auxDR.Read()) {
                FkOutputRelationsList.Add(
                    new ModelDataBaseFKRelation() {
                        TableName = auxDR.GetString(0),
                        ColumnName = auxDR.GetString(1),
                        ConstraintName = auxDR.GetString(2),
                        ReferencedTableName = auxDR.GetString(3),
                        ReferencedColumnName = auxDR.GetString(4)
                    });
            }
            Model.FkOutputRelationsList = FkOutputRelationsList;
        }
        cnn.Close();
    }

    protected void FillInputDataRelationsByForeignKeys()
    {
        if (FkInputRelationsList != null && FkInputRelationsList.Count > 0) {
            foreach (ModelDataBaseFKRelation fkRelation in FkInputRelationsList) {
                if (IsInForeingKeyNameList(fkRelation.ColumnName)) {

                    MySqlConnection cnn = null;
                    MySqlDataReader DataReader = ExecuteSelectForForeingData(fkRelation, ref cnn);  
                    if (!DataReader.IsClosed) {
                        while (DataReader.Read()) {

                            string ReferencedTableName = fkRelation.ReferencedTableName;
                            Object ModelForeingInstance = ModelManager.CreateModelInstanceByName(ReferencedTableName);

                            for (int fieldIndex = 0; fieldIndex < DataReader.FieldCount; fieldIndex++) {
                                var fieldValue = DataReader.GetValue(fieldIndex);
                                var propertyName = ModelForeingInstance.GetType().GetProperties()[fieldIndex].Name;
                                ModelForeingInstance.GetType().GetProperty(propertyName).SetValue(ModelForeingInstance, fieldValue);
                            }
                            GetModelProperty(ReferencedTableName).SetValue(Model, ModelForeingInstance);
                        }
                    } cnn.Close();
                }
            }
        }
    }
    protected void FillOutputDataRelationsByForeignKeys() 
    {
        // Cambiar la definición de ModelManager para que se instancia cada vez que se vaya a trabajar sobre un [Model] (en este caso [ModelForeingInstance])
        // ModelManager instanciara el modelo requerido y ofrecera metodos sobre este como [GetProperties], [GetProperty], [SetPropertyValue] o GetPropertyValue]...

        if (FkOutputRelationsList != null && FkOutputRelationsList.Count > 0) {
            foreach (ModelDataBaseFKRelation fkRelation in FkOutputRelationsList) {
                MySqlConnection cnn = null;
                MySqlDataReader DataReader = ExecuteSelectForOutputForeingData(fkRelation, ref cnn);
                if (!DataReader.IsClosed) {
                    var foreingDataList = new List<IModel>();
                    while (DataReader.Read()) {

                        string tableName = fkRelation.TableName;
                        Object ModelForeingInstance = ModelManager.CreateModelInstanceByName(tableName);
                        for (int fieldIndex = 0; fieldIndex < DataReader.FieldCount; fieldIndex++) {
                            var fieldValue = DataReader.GetValue(fieldIndex);
                            var propertyName = ModelForeingInstance.GetType().GetProperties()[fieldIndex].Name;
                            ModelForeingInstance.GetType().GetProperty(propertyName).SetValue(ModelForeingInstance, fieldValue);
                        }
                        foreingDataList.Add((IModel)ModelForeingInstance);
                    }
                    var relationalList = new List<IList<IModel>>();
                    relationalList.Add(foreingDataList);
                    GetModelProperty("RelationalEntityList").SetValue(Model, relationalList);
                }
                cnn.Close();
            }
        } 
    }
    protected void InitializeDataTypes(BussinesTypes typedBO)
    {
        ModelClass = typedBO.ModelLayerType;
        TableName = typedBO.DataTableName;
        DbConnection = typedBO.DbConnection;

        GetFielsDefinitionList();
        GetInputForeingKeysDefinitionList();
        if (IsRelationalInterfaceImplemented) GetOutputForeingKeysDefinitionList();
    }

    private MySqlDataReader ExecuteSelectForForeingData(ModelDataBaseFKRelation fkRelation, ref MySqlConnection cnn)
    {
        var modelFkValue = GetModelProperty(fkRelation.ColumnName).GetValue(Model);
        var sqlQuery = $"SELECT * FROM {fkRelation.ReferencedTableName} WHERE {fkRelation.ReferencedColumnName} = {modelFkValue}";
        cnn = new MySqlConnection(ConnectionString);
        MySqlCommand mc = new MySqlCommand(sqlQuery, cnn);
        cnn.Open();
        return mc.ExecuteReader();
    }
    private MySqlDataReader ExecuteSelectForOutputForeingData(ModelDataBaseFKRelation fkRelation, ref MySqlConnection cnn)
    {
        var modelPKValue = GetModelProperty(TableNameTreatment(fkRelation.ReferencedColumnName)).GetValue(Model);
        var sqlQuery = $"SELECT * FROM {fkRelation.TableName} WHERE {fkRelation.ColumnName} = {modelPKValue}";
        cnn = new MySqlConnection(ConnectionString);
        MySqlCommand mc = new MySqlCommand(sqlQuery, cnn);
        cnn.Open();
        return mc.ExecuteReader();
    }
    private bool IsInForeingKeyNameList(string fkColumnName)
    {
        foreach (string fkName in ForeignkeysNames) {
            if (fkName.Equals(fkColumnName)) return true;
        }
        return false;
    }
    private void AddParametersToCommand()
    {
        if (null != MySqlParametersList && MySqlParametersList.Count > 0)
            foreach (var parameterItem in MySqlParametersList) {
                Command.Parameters.AddWithValue(parameterItem.ParameterName, parameterItem.Value);
            }
    }
    private void InitializeConnection()
    {
        Command = new MySqlCommand { Connection = DbConnection };
        Command.CommandText = GetSqlQueryByType().Replace("@TableName", TableName.ToString());
        AddParametersToCommand();
        DbConnection.Open();
    }
    private string GetSqlQueryByType()
    {
        switch (QueryType) {
            case QueryTypes.SelectAll:
                QuerySql = " SELECT * FROM @TableName ";
                break;
            case QueryTypes.SelectByPrimary:
                QuerySql = $" SELECT * FROM @TableName WHERE {PrimaryKeyName} = @id ";
                break;
            case QueryTypes.UpdateByPrimary:
                //TODO
                break;
            case QueryTypes.Insert:

                QuerySql = "INSERT INTO @TableName(";

                var queryValues = string.Empty;
                var queryNames = string.Empty;

                foreach (var parameterItem in MySqlParametersList) {

                    queryNames += $"{parameterItem.ParameterName},";

                    object value = null;
                    switch (parameterItem.MySqlDbType) {
                        case MySqlDbType.Byte:
                            value = ((bool)parameterItem.Value == true) ? 1 : 0;
                            break;

                        case MySqlDbType.VarChar:
                        case MySqlDbType.DateTime:
                            value = $"'{parameterItem.Value}'";
                            break;

                        default:
                            value = parameterItem.Value;
                            break;
                    }
                    queryValues += value + ",";
                }
                queryNames = queryNames.Remove(queryNames.LastIndexOf(","));
                queryValues = queryValues.Remove(queryValues.LastIndexOf(","));

                QuerySql += $"{queryNames} ) VALUES(";
                QuerySql += $"{queryValues} )";
                break;

            case QueryTypes.DeleteByPrimary:
                QuerySql = $" DELETE FROM @TableName WHERE {PrimaryKeyName} = @id ";
                break;

            case QueryTypes.SelectNextPrimaryKey:
                QuerySql = $" SELECT MAX({PrimaryKeyName}) + 1 FROM @TableName ";
                break;
            case QueryTypes.SelectInputForeignRelationsDefinition:
                QuerySql = $"SELECT COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME, TABLE_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = '{TableName}' AND CONSTRAINT_NAME != 'PRIMARY' AND REFERENCED_COLUMN_NAME IS NOT NULL AND REFERENCED_TABLE_NAME IS NOT NULL";
                break;
            case QueryTypes.SelectOutputForeignRelationsDefinition:
                QuerySql = $" SELECT TABLE_NAME, COLUMN_NAME, CONSTRAINT_NAME, REFERENCED_TABLE_NAME, REFERENCED_COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE CONSTRAINT_NAME != 'PRIMARY' AND REFERENCED_COLUMN_NAME IS NOT NULL AND REFERENCED_TABLE_NAME IS NOT NULL AND REFERENCED_TABLE_NAME = '{TableName}'";
                break;
            case QueryTypes.SelectFieldsDefinition:
                QuerySql = $"SELECT Data_Type, Column_Name, Ordinal_Position, Is_Nullable, Character_Maximum_Length, Column_Key FROM information_schema.columns WHERE TABLE_NAME = '{TableName}'";
                break;
            case QueryTypes.Custom:
                break;
        }
        return QuerySql;
    }
    private string TableNameTreatment(string str)
    {
        if (str.Length > 1){
            var primeraMayuscula = char.ToUpper(str[0]) + str.Substring(1);

            if(primeraMayuscula.Contains("_")) {
                var posGuion = primeraMayuscula.IndexOf("_");
                var primeraParte = primeraMayuscula.Substring(0, posGuion);
                var segundaParte = primeraMayuscula.Substring(posGuion + 1);
                segundaParte = char.ToUpper(segundaParte[0]) + segundaParte.Substring(1);
                return primeraParte + segundaParte;
            }
            return primeraMayuscula;
        }
        return str.ToUpper();
    } 
    private PropertyInfo GetModelProperty(string propertyName)
    {
        return Model.GetType().GetProperty(propertyName);
    }
    private void SetValueToModelProperty(object fieldValue, int fieldIndex)
    {
        var modelPropertyTypeName = GetModelProperties[fieldIndex].PropertyType.Name;
        if (!ModelManager.IsInternalModelProperty(modelPropertyTypeName)) {
            var modelPropertyName = GetModelProperties[fieldIndex].Name;
            GetModelProperty(modelPropertyName).SetValue(Model, fieldValue);
        }
    }
    private void SetValueWhenPropertyIsBoolean(ref object fieldValue, int fieldIndex, Type fieldType)
    {
        if (fieldType.Equals(typeof(Int32)) && GetModelProperties[fieldIndex].PropertyType.Equals(typeof(Boolean))) {
            fieldValue = fieldValue.Equals(1) ? true : false;
        }
    }

    #endregion
}