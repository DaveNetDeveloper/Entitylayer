using System.Collections.Generic;

internal interface IModelRelations
{
    IList<IModel> RelationalList { get; set; }
}