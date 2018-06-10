using System;

public static class EntityManager
{
    public static IEntity GetEntity(Type ModelClass)
    {
        IEntity entity = null;
        switch (ModelClass.Name)
        {
            case "ModelUsuarioAlumno":
                entity = new EntityUsuarioAlumno(ModelClass);
                break;
            case "ModelDocumento":
                entity = new EntityDocumento(ModelClass);
                break;
        }
        return entity;
    } 
}