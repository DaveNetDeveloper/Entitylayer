using System;
using System.Collections.Generic; 

public class DaoArea : DaoBase, IDaoEntity
{
    #region [ ctors. ]

    public DaoArea()
    {
        TableName = DataTableNames.AREA;
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
                Model = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
            }
        }
        DbConnection.Close();
        MySqlParametersList.Clear();
        return Model;
    }
    public IEnumerable<IModel> GetList()
    {  
        DbConnection = ExecuteDataReader(QueryTypes.SelectAll); 
        if (!DrData.IsClosed)
        {
            ModelList = new List<IModel>();
            while (DrData.Read())
            {
                Model = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                ModelList.Add(Model);
            }
        }
        DbConnection.Close();
        return ModelList; 
    }
    public bool RemoveByPrimaryKey(int pKValue)
    {
        AddNewParameter(PrimaryKeyName, pKValue);
        return ExecuteNonQuery(QueryTypes.DeleteByPrimary);
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        QuerySql = String.Format("INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES( @NombreArea, @Descripción, @Responsable)");
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("Descripción", descripcion);
        AddNewParameter("Responsable", responsable);
         
        return ExecuteNonQuery();
    }
    public bool Insert(IModel model)
    {
        Model = model;
        //QueryTypes.Insert 
        return true;
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        QuerySql = String.Format("UPDATE @TableName SET Nombre = @NombreArea WHERE ID = @Id");
        AddNewParameter(PrimaryKeyName, pKValue);
        AddNewParameter("NombreArea", nombre);

        return ExecuteNonQuery();
    }
    public bool UpdateByPrimaryKey(IModel model)
    {
        Model = model;
        //QueryTypes.UpdateByPrimaryKey
        return true;
    }
    public int GetNextPrimaryKey()
    {
        AddNewParameter(PrimaryKeyName, PrimaryKeyName);
        DbConnection = ExecuteDataReader(QueryTypes.SelectNextPrimaryKey);
        if (!DrData.IsClosed)
        {
            while (DrData.Read())
            {
                NextPrimaryKey = DrData.GetInt32(0);
            }
        }
        DbConnection.Close();
        MySqlParametersList.Clear();
        return NextPrimaryKey;
    }  

    #endregion
}