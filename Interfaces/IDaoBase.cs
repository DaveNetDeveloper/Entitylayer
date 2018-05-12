using MySql.Data.MySqlClient;
using System.Collections.Generic;

public interface IDaoBase
{
    #region [ properties ]

    DaoBase.DataTableNames TableName { get; set; } 
    string PrimaryKeyName { get; set; }
    string ForeignkeyName { get; set; }
    int NextPrimaryKey { get; set; }
    string QuerySql { get; set; }
    MySqlDataReader DrData { get; set; }
    MySqlConnection DbConnection { get; set; }
    List<MySqlParameter> MySqlParametersList { get; set; }
    IModel Model { get; set; }
    List<IModel> ModelList { get; set; }
    
    #endregion

    #region [ methods ]

    void AddNewParameter(string nombreParam, object Value);
    MySqlConnection ExecuteDataReader(DaoBase.QueryTypes pQueryType); 
    bool ExecuteNonQuery(DaoBase.QueryTypes pQueryType);

    #endregion
}