namespace SolaERP.Shared.Model;
public class Menu : BaseModel
{
    public int MenuId { get; set; }
    public string? MenuName { get; set; }
    public int ParentId { get; set; }
    public string? URL { get; set; }
    public string? Icon { get; set; }
}
