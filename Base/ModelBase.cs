using System;
using System.Collections.Generic;

public class ModelBase
{
    public DateTime Updated { get; set; }
    public DateTime Created { get; set; }
    public List<ModelDataBaseFKRelation> FkInputRelationsList { get; set; }
    public List<ModelDataBaseFKRelation> FkOutputRelationsList { get; set; }
}