using System;

public class ModelDataBaseField
{
    public ModelDataBaseField()
    {
    }

    public string Data_Type { get; set; }
    public string Column_Name { get; set; }
    public Int32 Ordinal_Position { get; set; }
    public string PrimaryKeyName { get; set; }
    public Boolean Is_Nullable { get; set; }
    public Int32 Character_Maximum_Length { get; set; }
    public Boolean Column_Key { get; set; }
}