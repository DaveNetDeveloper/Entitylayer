﻿using System; 

public class BussinesTypedObject
{
    public enum BOType
    {
        UsuarioAlumno,
        UsuarioGestor,
        Documento
    }

    public Type BussinesLayerType;
    public Type DataLayerType;
    public Type ModelLayerType;

    //public Type BussinesInstanceType
    //{
    //    get {
    //        return Type.GetType(BussinesLayerType.ToString());
    //    }
    //}
    //public Type DataInstanceType
    //{
    //    get {
    //        return Type.GetType(DataLayerType.ToString());
    //    }
    //}
    //public Type ModelInstanceType
    //{
    //    get {
    //        return Type.GetType(ModelLayerType.ToString());
    //    }
    //}
}