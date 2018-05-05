using System;
using System.Collections.Generic; 

public class DaoArea : DbAccess, IDaoEntity
{ 
    public DaoArea()
    {
    }

    public IModel GetById(int id)
    {
        QuerySql = String.Format("SELECT * FROM AREA WHERE ID = @Id");
        AddNewParameter("Id", id);
        DbConnection = ExecuteDataReader();
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
        QuerySql = " SELECT * FROM AREA ORDER BY ID ";
        DbConnection = ExecuteDataReader();
         
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
        QuerySql = String.Format("DELETE FROM AREA WHERE ID = @Id");
        AddNewParameter("Id", id);
        return ExecuteNonQuery();
    }
    public bool Insert(string nombre, string descripcion, string responsable)
    {
        QuerySql = String.Format("INSERT INTO AREA (Nombre, Descripción, Responsable) VALUES( @NombreArea, @Descripción, @Responsable)");
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("Descripción", descripcion);
        AddNewParameter("Responsable", responsable);
        return ExecuteNonQuery();
    }
    public bool UpdateById(int id, string nombre)
    {
        QuerySql = String.Format("UPDATE AREA SET Nombre = @NombreArea WHERE ID = @Id");
        AddNewParameter("Id", id);
        AddNewParameter("NombreArea", nombre);
        return ExecuteNonQuery();
    }
}