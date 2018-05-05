using System.Collections.Generic;
using System.Web.UI.WebControls;

public interface IUcEntityList
{
    IEnumerable<IModel> DataSource { get; set; }
    SortDirection Dir { get; set; }

    void InitializeList();
    void ExportToExcel();
}