using System.Collections.Generic; 

public class DaoUsuarioAlumno : DaoBase, IDaoEntity
{
    #region [ ctors. ]

    public DaoUsuarioAlumno()
    {
        TableName = DataTableNames.USER_ALUMNO;
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
                Model = new ModelUsuarioAlumno();

                //if (!dr.IsDBNull(1))
                //{
                //    privateUserName.Text = dr.GetString(1);
                //}

                //if (!dr.IsDBNull(2))
                //{
                //    privateUserSurname.Text = dr.GetString(2);
                //}

                //if (!dr.IsDBNull(3))
                //{
                //    privateUserBirthDate.Text = dr.GetDateTime(3).ToString("dd/MM/yyyy");
                //}

                //if (!dr.IsDBNull(4))
                //{
                //    privateUserMail.Text = dr.GetString(4);
                //}

                //if (!dr.IsDBNull(5))
                //{
                //    privateUserUserName.Text = dr.GetString(5);
                //}

                //if (!dr.IsDBNull(6))
                //{
                //    privateUserPassword.Text = dr.GetString(6).ToString();
                //}

                //if (!dr.IsDBNull(7))
                //{
                //    privateUserEntered.Checked = ((dr.GetInt32(7) == 0) ? false : true);
                //}

                //if (!dr.IsDBNull(8))
                //{
                //    privateUserActive.Checked = ((dr.GetInt32(8) == 0) ? false : true);
                //}

                //if (!dr.IsDBNull(9))
                //{
                //    if (Mode == "N")
                //    {
                //        privateUserCreated.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //    }
                //    else if (Mode == "E")
                //    {
                //        privateUserCreated.Text = dr.GetDateTime(9).ToString("dd/MM/yyyy");
                //    }
                //    else if (Mode == "V")
                //    {
                //        privateUserCreated.Text = dr.GetDateTime(9).ToString("dd/MM/yyyy");
                //    }
                //}

                //if (!dr.IsDBNull(10))
                //{
                //    if (Mode == "E")
                //    {
                //        privateUserUpdated.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //    }
                //    else if (Mode == "V")
                //    {
                //        privateUserUpdated.Text = dr.GetDateTime(10).ToString("dd/MM/yyyy");
                //    }
                //}

                //if (!dr.IsDBNull(11))
                //{
                //    privateUserPhone.Text = dr.GetInt32(11).ToString();
                //}

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
                //IModel area = new ModelUsuarioAlumno(DrData.GetFieldType(0), DrData.GetString(1), (DrData.IsDBNull(2)) ? string.Empty : DrData.GetString(2), DrData.GetString(3));
                Model = new ModelUsuarioAlumno();
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
    public bool Insert(string name, string surname, string mail)
    {
        QuerySql = "INSERT INTO @TableName (name, surname, mail) VALUES( @Name, @Surname, @Mail)";
        AddNewParameter("Name", name);
        AddNewParameter("Surname", surname);
        AddNewParameter("Mail", mail);

        //`name`
        //`surname`
        //`birth_date`
        //`mail`
        //`user_name`
        //`password`
        //`entered`
        //`active`
        //`created`
        //`updated`
        //`phone`
         
        return ExecuteNonQuery();
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre)
    {
        QuerySql = $"UPDATE @TableName SET Nombre = @Nombre WHERE ID = @{PrimaryKeyName}";
        AddNewParameter(PrimaryKeyName, pKValue);
        AddNewParameter("Nombre", nombre);

        return ExecuteNonQuery();
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
    public IEnumerable<IModel> GetByForeignKey()  
    {
        //Cargar los productos asociados al alumno
        return new List<IModel>();
    }

    #endregion
}