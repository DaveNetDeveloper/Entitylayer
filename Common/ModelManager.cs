using System;
using System.Reflection;
using System.Runtime.Remoting;

public static class ModelManager
{  
    #region [ constants ]
     
    private const string modelLiteral = "Model";

    #endregion

    #region [ public ]

    public static Object CreateModelInstanceByName(string name)
    {
        var modelTypeOfForeingTableName = modelLiteral + TableNameTreatment(name);
        ObjectHandle handle = Activator.CreateInstance(CurrenAssembly, modelTypeOfForeingTableName);
        return handle.Unwrap();
    }
    public static IModel CreateModelInstanceByType(Type modelClass)
    {
        return (IModel)Activator.CreateInstance(modelClass);
    }
    public static bool IsInternalModelProperty(string modelPropertyTypeName)
    {
        if (modelPropertyTypeName.Contains(modelLiteral)) {
            return modelPropertyTypeName.Substring(0, modelLiteral.Length).Equals(modelLiteral);
        }
        return false;
    }
    public static bool IsInternalProperty(Type interfaceType, string propertyName)
    {
        foreach (var relationModelProperty in interfaceType.GetProperties()) {
            if (relationModelProperty.Name.Equals(propertyName)) return true;
        }
        return false;
    }
    
    #endregion

    #region [ private ]

    private static string CurrenAssembly => Assembly.GetExecutingAssembly().GetName().Name;
    private static string TableNameTreatment(string str)
    {
        if (str.Length > 1) {
            var primeraMayuscula = char.ToUpper(str[0]) + str.Substring(1);

            if (primeraMayuscula.Contains("_")) {
                var posGuion = primeraMayuscula.IndexOf("_");
                var primeraParte = primeraMayuscula.Substring(0, posGuion);
                var segundaParte = primeraMayuscula.Substring(posGuion + 1);
                segundaParte = char.ToUpper(segundaParte[0]) + segundaParte.Substring(1);
                return primeraParte + segundaParte;
            }
            return primeraMayuscula;
        }
        return str.ToUpper();
    }
    
    #endregion
}