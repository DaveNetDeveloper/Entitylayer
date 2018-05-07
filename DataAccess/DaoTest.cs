using System;
using System.Collections.Generic; 

public class DaoTest : DbAccess, IDaoEntity
{
    public DaoTest()
    {
        TableName = "TEST";
    }
    public IModel GetById(int id)
    {
        IModel test = null; 
        AddNewParameter("id", id);
        DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                //test = new ModelTest(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                test = new ModelTest();
            }
        }
        DbConnection.Close();
        return test;
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
                IModel test = new ModelTest();// DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                testsList.Add(test);
            }
        }
        DbConnection.Close();
        return testsList; 
    }
    public bool RemoveById(int id)
    {
        QueryType = QueryTypes.DeleteByPrimary;
        AddNewParameter("id", id);
        return ExecuteNonQuery();
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        QuerySql = String.Format("INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombre, texto2, texto3);
        
        return ExecuteNonQuery();
    }
    public bool UpdateById(int id, string nombre)
    {
        QuerySql = String.Format("UPDATE @TableName SET Nombre = '{0}' WHERE ID = {1}", nombre, id);
        
        return ExecuteNonQuery();
    }
}

