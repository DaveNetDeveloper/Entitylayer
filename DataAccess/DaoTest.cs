using System;
using System.Collections.Generic; 

public class DaoTest : DaoBase, IDaoEntity
{
    #region [ ctor. ]

    public DaoTest()
    {
        TableName = DataTableNames.TEST;
        PrimaryKeyName = "id";
    }

    #endregion

    #region [ public properties ]

    public IModel GetById(int pKValue)
    { 
        AddNewParameter(PrimaryKeyName, pKValue);
        DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                //test = new ModelTest(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                Model = new ModelTest();
            }
        }
        DbConnection.Close();
        return Model;
    }
    public IEnumerable<IModel> GetList()
    { 
        List<IModel> testsList = null;
        QueryType = QueryTypes.SelectAll;
        DbConnection = ExecuteDataReader(QueryTypes.SelectAll);
         
        if (!DrData.IsClosed)
        {
            testsList = new List<IModel>();
            while (DrData.Read())
            {
                Model = new ModelTest();// DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                testsList.Add(Model);
            }
        }
        DbConnection.Close();
        return testsList; 
    }
    public bool RemoveById(int pKValue)
    {
        AddNewParameter(PrimaryKeyName, pKValue);
        return ExecuteNonQuery(QueryTypes.DeleteByPrimary); 
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        QuerySql = String.Format("INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombre, texto2, texto3);
        
        return ExecuteNonQuery();
    }
    public bool UpdateById(int pKValue, string nombre)
    {
        QuerySql = String.Format("UPDATE @TableName SET Nombre = '{0}' WHERE ID = {1}", nombre, pKValue);
        
        return ExecuteNonQuery();
    }

    #endregion
}