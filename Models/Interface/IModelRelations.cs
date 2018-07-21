using System.Collections.Generic;

internal interface IModelRelations
{
    List<IList<IModel>> RelationalEntityList { get; set; }
}