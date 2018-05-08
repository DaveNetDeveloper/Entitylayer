using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

public interface IDaoBase
{
    DaoBase.DataTableNames TableName { get; set; } 
    string PrimaryKeyName { get; set; } 

    String QuerySql { get; set; }
    MySqlDataReader DrData { get; set; }
    MySqlConnection DbConnection { get; set; }
    List<MySqlParameter> MySqlParametersList { get; set; }

    IModel Model { get; set; }
    List<IModel> ModelList { get; set; }

    void AddNewParameter(string nombreParam, object Value);
    MySqlConnection ExecuteDataReader(DaoBase.QueryTypes pQueryType); 
    bool ExecuteNonQuery(DaoBase.QueryTypes pQueryType);
}