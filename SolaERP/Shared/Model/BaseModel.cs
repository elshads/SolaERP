namespace SolaERP.Shared.Model;
public class BaseModel : IBaseModel
{
    public BaseModel() 
    {
        RowIndex = -1;
    }

    public int RowIndex { get; set; }
    public string? ReturnMessage { get; set; }
}
