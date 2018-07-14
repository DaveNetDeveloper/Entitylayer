using System;
using System.Collections.Generic;

public interface IModel
{
    int Id { get; set; }
    DateTime Updated { get; set; }
    DateTime Created { get; set; }

    List<ModelDataBaseFKRelation> FkRelationsList { get; set; }
}