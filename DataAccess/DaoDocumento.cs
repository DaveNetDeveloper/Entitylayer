using System;
using System.Collections.Generic; 

public class DaoDocumento : DbAccess, IDaoEntity
{
    public DaoDocumento()
    {
        TableName = "DOCUMENTO";
    }
    public IModel GetById(int id)
    {
        IModel documento = null;
        AddNewParameter("id", id);
        DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                documento = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
            }
        }
        DbConnection.Close();
        return documento;
    }
    public IEnumerable<IModel> GetList()
    { 
        List<IModel> documentosList = null; 
        DbConnection = ExecuteDataReader(QueryTypes.SelectAll);
         
        if (!DrData.IsClosed)
        {
            documentosList = new List<IModel>();
            while (DrData.Read())
            {
                IModel documento = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
                documentosList.Add(documento);
            }
        }
        DbConnection.Close();
        return documentosList; 
    }
    public bool RemoveById(int id)
    { 
        AddNewParameter("id", id);
        return ExecuteNonQuery(QueryTypes.DeleteByPrimary);
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