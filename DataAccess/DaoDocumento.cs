﻿using System;
using System.Collections.Generic; 

public class DaoDocumento : DaoBase, IDaoEntity
{
    #region [ ctors. ]

    public DaoDocumento()
    {
        TableName = DataTableNames.DOCUMENTO;
        PrimaryKeyName = "id";
    }

    #endregion

    #region [ public methods ]

    public IModel GetByPrimaryKey(int pKValue)
    { 
        AddNewParameter(PrimaryKeyName, pKValue);
        DbConnection = ExecuteDataReader(QueryTypes.SelectByPrimary);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                Model = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
            }
        }
        DbConnection.Close();
        return Model;
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
                Model = new ModelDocumento(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3), DrData.GetString(7));
                documentosList.Add(Model);
            }
        }
        DbConnection.Close();
        return documentosList; 
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        AddNewParameter(PrimaryKeyName, pKValue);
        return ExecuteNonQuery(QueryTypes.DeleteByPrimary);
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        QuerySql = String.Format("INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES('{0}', '{1}', '{2}')", nombre, texto2, texto3);
        
        return ExecuteNonQuery();
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        QuerySql = String.Format("UPDATE @TableName SET Nombre = '{0}' WHERE ID = {1}", nombre, pKValue);
        
        return ExecuteNonQuery();
    }
    public int GetNextPrimaryKey()
    {



        return 0;
    }
    #endregion
}