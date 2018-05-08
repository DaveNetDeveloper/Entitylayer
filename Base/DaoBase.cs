using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic; 

public class DaoBase : IDaoBase
{
    #region [public enums]

    public enum QueryTypes
    {
        SelectAll,
        SelectByPrimary,
        UpdateByPrimary,
        DeleteByPrimary,
        Create,
        Custom
    }; 
    public enum DataTableNames
    {
        //BioIntranet
        AREA,
        DOCUMENTO,
        NOTICIA,
        DEPARTAMENTO,
        IMAGEN,
        SECCION,
        AVISO,

        //Gestor Examenes Online
        CATEGORY,
        CENTER,
        CONTACT,
        CONVOCATION,
        LITERALES,
        LOG,
        PREGUNTA,
        PRODUCTO,
        RESPUESTA,
        TEST,
        USER_ALUMNO,
        USER_PRODUCTO,
        USUARIO_GESTOR 
    };

    #endregion

    #region [public properties]

    public QueryTypes QueryType { get; set; }
    public DataTableNames TableName { get; set; } 
    public string PrimaryKeyName { get; set; }
    public IModel Model { get; set; }
    public List<IModel> ModelList { get; set; }
    public String QuerySql { get; set; }
    public MySqlDataReader DrData { get; set; }
    public MySqlConnection DbConnection { get; set; }
    public List<MySqlParameter> MySqlParametersList { get; set; }

    #endregion

    #region [public methods]

    public MySqlConnection ExecuteDataReader(QueryTypes pQueryType)
    {
        QueryType = pQueryType;
        InitializeConnection(); 
        DrData = Command.ExecuteReader();
        return (DrData != null) ? DbConnection : null;
    } 
    public bool ExecuteNonQuery(QueryTypes pQueryType)
    {
        QueryType = pQueryType;
        InitializeConnection(); 
        int affectedRecords = Command.ExecuteNonQuery();
        DbConnection.Close();
        MySqlParametersList.Clear();
        return affectedRecords > 0; ;
    }
    public bool ExecuteNonQuery()
    {
        InitializeConnection();
        int affectedRecords = Command.ExecuteNonQuery();
        DbConnection.Close();
        MySqlParametersList.Clear();
        return affectedRecords > 0; ;
    }
    public void AddNewParameter(string nombreParam, object value)
    {
        if (null == MySqlParametersList) MySqlParametersList = new List<MySqlParameter>();
        MySqlParametersList.Add(new MySqlParameter(nombreParam, value));
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
        Command.CommandText = GetSqQueryByQueryType().Replace("@TableName", TableName.ToString()); 
        AddParametersToCommand(); 
        DbConnection.Open();
    }
    private string GetSqQueryByQueryType()
    {
        switch (QueryType)
        {
            case QueryTypes.SelectAll:
                QuerySql = " SELECT * FROM @TableName ";
                break;
            case QueryTypes.SelectByPrimary:
                QuerySql = " SELECT * FROM @TableName WHERE ID = @id ";
                break;
            case QueryTypes.UpdateByPrimary:

                break;
            case QueryTypes.DeleteByPrimary:
                QuerySql = " DELETE FROM @TableName WHERE ID = @id ";
                break;
            case QueryTypes.Create:

                break;
            case QueryTypes.Custom:

                break; 
        }
        return QuerySql;
    }

    #endregion
}