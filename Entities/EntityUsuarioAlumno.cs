using System;
using System.Collections.Generic;

public class EntityUsuarioAlumno : IEntity
{
    //properties
    public IDaoEntity DaoEntity { get; set; }

    //ctror.
    public EntityUsuarioAlumno(Type modelClass) => DaoEntity = new DaoUsuarioAlumno(modelClass); //Crear instancia del DAO que toque a traves del tipo guarado en "TypedBO"

    //methods
    public IModel GetByPrimaryKey(int pKValue) => DaoEntity.GetByPrimaryKey(pKValue);
    public IEnumerable<IModel> GetList() => DaoEntity.GetList();
    public bool RemoveByPrimaryKey(int pKValue) => DaoEntity.RemoveByPrimaryKey(pKValue);
    public bool Insert(IModel model)
    {
        model.Id = GetNextPrimaryKey();
        return DaoEntity.Insert(model);
    }
    public bool UpdateByPrimaryKey(int pKValue, string nombre) => DaoEntity.UpdateByPrimaryKey(pKValue, nombre);
    public bool UpdateByPrimaryKey(IModel model) => DaoEntity.UpdateByPrimaryKey(model);

    //private methods
    private int GetNextPrimaryKey() => DaoEntity.GetNextPrimaryKey();

    //TODO: Por implementar (llamar desde UI después de hacer la validación en el guardar(edit o create))
    //public bool ExistByPrimaryKey(IModel model)
    //{
    //bool exist;

    //Consulta en la base de datos por la existencia de alguna fila con las PK informadas a través del modelo

    //return exist;
    //}
}