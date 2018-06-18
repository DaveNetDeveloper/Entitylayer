/// <summary>
///  Constantes globales para uso de la capa de negocio
/// </summary>
public static class Constants
{
    // TODO Crear todas las contantes posibles en tablas maestras en la base de datos
    //      --> levantar estos datos al iniciar la aplicación y guardarlo en cache (Session)

    public const string languageCode_ESPAÑOL = "es";
    public const string languageCode_CATALAN = "ca";
    public const string languageCode_INGLES = "en";

    //Culture Info
    public const string CULTURE_INFO_ESPAÑOL = "es-ES";
    public const string CULTURE_INFO_CATALAN = "ca-ES";
    public const string CULTURE_INFO_INGLES = "en-US";

    public const string NoImageParaPreguntaTestOnline = "~/Images/NoImage.jpg";

    // Reminder for text message on popUp - SMS Send confirmation
    public const string SendSMS_ReminderTextMessage = "Recuerda que puedes usar en tu mensaje las etiquetas <i> [NOMBRE] </i> <i>[APELLIDOS]</i> <i>[TELÉFONO]</i> <i>[EMAIL]</i> <i>[USUARIO]</i> y <i>[CONTRASEÑA]</i> para que el contenido sea personalizable para cada usuario. Puedes usar estas etiquetas en el campo 'MENSAJE' como si fueran palabras normales.";

    public const string inputDateTimeFormat_ddmmaaaa = "dd/mm/aaaa";
    public const string inputDateTimeFormat_mmddaaaa = "mm/dd/aaaa";

    //CENTERS
    public const string LITERALCODE_CENTER_NAME = "CENTER_NAME_";
    public const string LITERALCODE_CENTER_DESCRIPTION = "CENTER_DESCRIPTION_";
    public const string LITERALCODE_CENTER_INFO = "CENTER_INFO_";

    //PRODUCTS
    public const string LITERALCODE_PRODUCT_NAME = "PRODUCT_NAME_";
    public const string LITERALCODE_PRODUCT_DESCRIPTION = "PRODUCT_DESCRIPTION_";
    public const string LITERALCODE_PRODUCT_TEXT = "PRODUCT_TEXT_";
    public const string LITERALCODE_PRODUCT_DISTANCE = "PRODUCT_DISTANCE_";

    //ACCIONES SOBRE LISTADOS
    public const string ACTIONS_LIST_PAGE_CREATE = "Crear";
    public const string ACTIONS_LIST_PAGE_VIEW = "Ver";
    public const string ACTIONS_LIST_PAGE_EDIT = "Editar";
    public const string ACTIONS_LIST_PAGE_DELETE = "Eliminar";
    public const string ACTIONS_LIST_PAGE_IMPRIMIR = "Imprimir";
    public const string ACTIONS_LIST_SEND_SMS = "EnviarSMS";
    public const string ACTIONS_LIST_EXPORT_EXCEL = "ExportarExcel";
    public const string ACTIONS_LIST_FILTRAR_LISTADO = "FiltrarListado";

    //TIPOS DE PREGUNTA
    public const string QUESTION_TYPE_TEST = "Test";
    public const string QUESTION_TYPE_FREE = "Libre";

    //APARTADOS TEST
    public const string APARTADO_TEST_TECNOLOGIA = "Tecnología naval";
    public const string APARTADO_TEST_MANIOBRAS = "Maniobras a motor";
    public const string APARTADO_TEST_SEGURIDAD = "Seguridad";
    public const string APARTADO_TEST_NAVEGACIÓN = "Navegación";
    public const string APARTADO_TEST_METEOROLOGIA = "Meteorología";
    public const string APARTADO_TEST_RADIOCOMUNICACIONES = "Rodiocomunicaciones";
    public const string APARTADO_TEST_PROPULSION = "Propulsión";
    public const string APARTADO_TEST_RIPA = "RIPA";
    public const string APARTADO_TEST_BALIZAMIENTO = "Balizamiento";
    public const string APARTADO_TEST_LEGISLACION = "Legislación";

    //2DO: POR DEFINIR DÍAS DE LA SEMANA, EN ESPAÑOL E INGLÉS:

    public const string ASP_PAGE_EXTENSION = ".aspx";
}