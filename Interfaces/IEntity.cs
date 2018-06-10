using System.Collections.Generic; 

public interface IEntity
{
    IDaoEntity DaoEntity { get; set; }

    IModel GetByPrimaryKey(int pKValue);
    IEnumerable<IModel> GetList();
    bool RemoveByPrimaryKey(int pKValue);
    bool Insert(IModel model);
    bool UpdateByPrimaryKey(int pKValue, string nombre);
    bool UpdateByPrimaryKey(IModel model);
}