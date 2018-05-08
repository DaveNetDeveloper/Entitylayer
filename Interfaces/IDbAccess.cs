using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public interface IDbAccess
{
    string TableName { get; set; }
    //object PrimaryKeyValue { get; set; }
    string PrimaryKeyName { get; set; }

    IModel Model { get; set; }
    List<IModel> ModelList { get; set; }
    String QuerySql { get; set; }
    MySqlDataReader DrData { get; set; }
    MySqlConnection DbConnection { get; set; }
    List<MySqlParameter> MySqlParametersList { get; set; }

    void AddNewParameter(string nombreParam, object Value);
    MySqlConnection ExecuteDataReader(DbAccess.QueryTypes pQueryType); 
    bool ExecuteNonQuery(DbAccess.QueryTypes pQueryType);
}