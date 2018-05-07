using System;
using System.Collections.Generic; 

public class DaoArea : DbAccess, IDaoEntity
{ 
    public DaoArea()
    {
        TableName = Constants.TableNameAREA;
    }

    public IModel GetById(int id)
    { 
        AddNewParameter("Id", id); 
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
                IModel area = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                ModelList.Add(area);
            }
        }
        DbConnection.Close();
        return ModelList; 
    }
    public bool RemoveById(int id)
    {
        QuerySql = String.Format("DELETE FROM @TableName WHERE ID = @Id");
        AddNewParameter("Id", id);
        

        return ExecuteNonQuery();
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        QuerySql = String.Format("INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES( @NombreArea, @Descripción, @Responsable)");
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("Descripción", descripcion);
        AddNewParameter("Responsable", responsable);
        

        return ExecuteNonQuery();
    }
    public bool UpdateById(int id, string nombre)
    {
        QuerySql = String.Format("UPDATE @TableName SET Nombre = @NombreArea WHERE ID = @Id");
        AddNewParameter("Id", id);
        AddNewParameter("NombreArea", nombre);
        

        return ExecuteNonQuery();
    }
}