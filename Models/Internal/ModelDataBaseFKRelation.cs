public class ModelDataBaseFKRelation
{
    public ModelDataBaseFKRelation()
    {
    }

    public string TableName { get; set; }
    public string ColumnName { get; set; }
    public string ConstraintName { get; set; }
    public string ReferencedTableName { get; set; }
    public string ReferencedColumnName { get; set; }
}