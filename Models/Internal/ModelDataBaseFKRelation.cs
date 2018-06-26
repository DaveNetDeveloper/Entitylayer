public class ModelDataBaseFKRelation
{
    public ModelDataBaseFKRelation()
    {
    }

    //public string TABLE_NAME { get; set; }
    public string ColumnName { get; set; }
    public string ConstraintName { get; set; }
    public string Referenced_TableName { get; set; }
    public string Referenced_ColumnName { get; set; }
}