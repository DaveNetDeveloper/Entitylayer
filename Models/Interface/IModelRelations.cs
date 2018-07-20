using System.Collections.Generic;

internal interface IModelRelations
{
    IList<IList<IModel>> RelationalList { get; set; }
}