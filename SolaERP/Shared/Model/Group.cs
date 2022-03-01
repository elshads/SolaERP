namespace SolaERP.Shared.Model;
public class Group :BaseModel
{
    public int GroupId { get; set; }
    public string? GroupName { get; set; }
    public string? Description { get; set; }
}
