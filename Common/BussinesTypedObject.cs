using System; 

namespace BussinesTypedObject
{ 
    public class BussinesTypes
    {
        #region [ Enums ]

        public enum ProyectName
        {
            BioIntranet = 0,
            MasterManager = 1
        }
      
        public enum BussinesObjectType
        {
            UsuarioAlumno,
            UsuarioGestor,
            Documento
        } 
        //public enum BOTMasterManager
        //{
        //    UsuarioAlumno,
        //    UsuarioGestor,
        //    Documento
        //}
        //public enum BOTBioIntranet
        //{
        //    UsuarioAlumno,
        //    UsuarioGestor,
        //    Documento
        //}

        public enum DataTableNames
        {
            Area,
            Documento,
            Noticia,
            Departamento,
            Imagen,
            Seccion,
            Aviso,
            Empleado,
            Rol,
            Usuario,
            Log,

            //
            Category,
            Center,
            Contact,
            Convocation,
            Literales,
           // Log,
            Pregunta,
            Producto,
            Respuesta,
            Test,
            User_Alumno,
            User_Producto,
            Usuario_Gestor
        }; 
        //public enum BioIntranetDataTableNames
        //{
        //    Area,
        //    Documento,
        //    Noticia,
        //    Departamento,
        //    Imagen,
        //    Seccion,
        //    Aviso,
        //    Empleado,
        //    Rol,
        //    Usuario,
        //    Log
        //}; 
        //public enum MasterManagerDataTableNames
        //{
        //    Category,
        //    Center,
        //    Contact,
        //    Convocation,
        //    Literales,
        //    Log,
        //    Pregunta,
        //    Producto,
        //    Respuesta,
        //    Test,
        //    User_Alumno,
        //    User_Producto,
        //    Usuario_Gestor
        //};

        #endregion

        #region [ Properties ]

        public Type BussinesLayerType;
        public Type DataLayerType;
        public Type ModelLayerType;
        public DataTableNames DataTableName;

        #endregion
    }
}