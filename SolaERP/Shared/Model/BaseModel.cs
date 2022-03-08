namespace SolaERP.Shared.Model;
public class BaseModel
{
    public BaseModel() { }

    public BaseModel(BaseModel instance) 
    {
        ReturnMessage = instance.ReturnMessage;
    }

    public string? ReturnMessage { get; set; }
}
