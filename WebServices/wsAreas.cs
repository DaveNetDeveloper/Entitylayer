using System;
using System.Collections.Generic;
using System.Web.Services;
  
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(true)]
[System.Web.Script.Services.ScriptService] 
public class WsAreas : WebService, IWsEntity
{
    IEntity entityAreas = new EntityArea();
     
    [WebMethod(EnableSession = true)]
    //public IModel GetById(IModel pModel)
    public IModel GetById(ModelArea pModel)
    {
        try
        {
            return entityAreas.GetById(pModel.Id);
        }
        catch(Exception)
        {
            throw;
        } 
    }

    [WebMethod(EnableSession = true)]
    public IEnumerable<IModel> GetAll()
    { 
        try
        {
            return entityAreas.GetList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public bool EliminarById(int id)
    {
        try
        {
            return entityAreas.RemoveById(id);
        }
        catch (Exception)
        {
            throw;
        }
    }   

    [WebMethod(EnableSession = true)]
    public bool Insertar(string nombre)
    {
        try
        {
            return entityAreas.Insert(nombre);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [WebMethod(EnableSession = true)]
    public bool UpdateById(int id, string nombre)
    {
        try
        {
            return entityAreas.UpdateById(id, nombre);
        }
        catch (Exception)
        {
            throw;
        }
    }
}