public static class EntityManager
{
    public static IEntity GetEntity(Enums.EntityType pEntityType)
    {
        IEntity entity = null;

        switch (pEntityType)
        {
            case Enums.EntityType.Area:
                entity = new EntityArea();
                break;
            //case Enums.EntityType.Convocatoria:
            //    entity = new EntityConvocatoria();
            //    break;
            case Enums.EntityType.Documento:
                entity = new EntityDocumento();
                break;
            //case Enums.EntityType.Pregunta:
            //    entity = new EntityPregunta();
            //    break;
            //case Enums.EntityType.Respuesta:
            //    entity = new EntityRespuestao();
            //    break;
            case Enums.EntityType.Test:
                entity = new EntityTest();
                break;
            case Enums.EntityType.UsuarioAlumno:
                entity = new EntityUsuarioAlumno();
                break;
            case Enums.EntityType.UsuarioGestor:
                entity = new EntityUsuarioGestor();
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