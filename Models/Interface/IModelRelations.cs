using System.Collections.Generic;

public interface IModelRelations
{
    List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }

    List<IList<IModel>> RelationalEntityList { get; set; }
}