using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;

public class DbAccess : IDbAccess
{
    #region [public properties]

    public string TableName { get; set; }
    public IModel Model { get; set; }
    public List<IModel> ModelList { get; set; }
    public String QuerySql { get; set; }
    public MySqlDataReader DrData { get; set; }
    public MySqlConnection DbConnection { get; set; }
    public List<MySqlParameter> MySqlParametersList { get; set; }

    #endregion

    #region [public methods]

    public MySqlConnection ExecuteDataReader()
    {
        InitializeConnection(); 
        DrData = Command.ExecuteReader();
        return (DrData != null) ? DbConnection : null;
    }
    public bool ExecuteNonQuery()
    {
        InitializeConnection(); 
        int affectedRecords = Command.ExecuteNonQuery();
        DbConnection.Close();
        MySqlParametersList.Clear();
        return affectedRecords > 0; ;
    }
    public void AddNewParameter(string nombreParam, object Value)
    {
        if (null == MySqlParametersList) MySqlParametersList = new List<MySqlParameter>();

        var param = new MySqlParameter(nombreParam, Value);
        MySqlParametersList.Add(param);
    }

    #endregion

    #region [private properties]

    private MySqlCommand Command { get; set; }
    private string ConnectionString
    {
        get
        {
            return string.Empty;
        }
    }
    private string Connection_biointranet
    {
        get
        {
            return "database=biointranet; data source=localhost; user id=dbUser; password=123; persistsecurityinfo=true; sslMode=none;";
            //return ConfigurationManager.ConnectionStrings["Connection_qsg265"].ConnectionString;
        }
    }

    #endregion

    #region [private methods]

    private void AddParametersToCommand()
    {
        if (null != MySqlParametersList && MySqlParametersList.Count > 0)
            foreach (var parameterItem in MySqlParametersList)
            {
                Command.Parameters.Add(parameterItem);
            }
    }

    private void InitializeConnection()
    {
        DbConnection = new MySqlConnection(Connection_biointranet);
        Command = new MySqlCommand { Connection = DbConnection };
        AddParametersToCommand();
        Command.CommandText = QuerySql;
        DbConnection.Open();
    }

    #endregion
}