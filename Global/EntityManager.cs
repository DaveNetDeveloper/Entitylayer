public static class EntityManager
{
    public enum EntityType
    {
        Apartado,
        Area,
        Convocatoria,
        Documento,
        Pregunta,
        Respuesta,
        Test,
        UsuarioAlumno,
        UsuarioGestor,
        Contacto
    };

    public static IEntity GetEntity(EntityType pEntityType)
    {
        IEntity entity = null;

        switch (pEntityType)
        {
            case EntityType.Area:
                entity = new EntityArea();
                break;
            //case Enums.EntityType.Convocatoria:
            //    entity = new EntityConvocatoria();
            //    break;
            case EntityType.Documento:
                entity = new EntityDocumento();
                break;
            //case Enums.EntityType.Pregunta:
            //    entity = new EntityPregunta();
            //    break;
            //case Enums.EntityType.Respuesta:
            //    entity = new EntityRespuestao();
            //    break;
            case EntityType.Test:
                entity = new EntityTest();
                break;
            case EntityType.UsuarioAlumno:
                //entity = new EntityUsuarioAlumno();
                break;
            case EntityType.UsuarioGestor:
                //entity = new EntityUsuarioGestor();
                break;
            //case Enums.EntityType.Contacto:
            //    entity = new EntityContacto();
            //    break;

            //case Enums.EntityType.Apartado:
            //    entity = new EntityApartado();
            //    break;
        }
        return entity;
    }
     
}