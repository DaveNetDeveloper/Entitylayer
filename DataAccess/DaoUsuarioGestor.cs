using System.Collections.Generic;
using System.Data;

public class DaoUsuarioGestor : DbAccess, IDaoEntity
{
    public DaoUsuarioGestor()
    {
        TableName = "usuario_gestor";
    }
     
    public IModel GetById(int id)
    {
        QuerySql = "SELECT * FROM @TableName WHERE ID = @Id";
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
        QuerySql = "SELECT * FROM @TableName ORDER BY ID";
        

        DbConnection = ExecuteDataReader();
        if (!DrData.IsClosed)
        {
            var dtDocumento = new DataTable();
            dtDocumento.Columns.AddRange(new DataColumn[8] 
            {   new DataColumn("ID"),
                new DataColumn("NAME"),
                new DataColumn("DESCRIPTION"),
                new DataColumn("INFO_WINDOW"),
                new DataColumn("ADDRESS"),
                new DataColumn("CP"), new DataColumn("City"),
                new DataColumn("chkSelect")
            });


            ModelList = new List<IModel>();
            while (DrData.Read())
            {
                IModel area = new ModelArea(DrData.GetInt32(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                ModelList.Add(area);


                dtDocumento.Rows.Add(DrData.GetInt32(0), DrData.GetString(1), "" + "...", "", DrData.GetString(4), DrData.GetString(5), DrData.GetString(6), false);
          }
        }
        DbConnection.Close();
        return ModelList; 
    }
    public bool RemoveById(int id)
    {
        QuerySql = "DELETE FROM @TableName WHERE ID = @Id";
        AddNewParameter("Id", id);
        

        return ExecuteNonQuery();
    }
    public bool Insert(string nombre, string texto2, string texto3)
    {
        QuerySql = "INSERT INTO @TableName (Nombre, Descripción, Responsable) VALUES( @NombreArea, @Descripción, @Responsable)";
        AddNewParameter("NombreArea", nombre);
        AddNewParameter("Descripción", texto2);
        AddNewParameter("Responsable", texto3);
        

        return ExecuteNonQuery();
    }
    public bool UpdateById(int id, string nombre)
    {
        QuerySql = "UPDATE @TableName SET Nombre = @NombreArea WHERE ID = @Id";
        AddNewParameter("Id", id);
        AddNewParameter("NombreArea", nombre);
        

        return ExecuteNonQuery();
    }
}