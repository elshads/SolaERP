namespace SolaERP.Shared.Model;
public class Group :BaseModel
{
    public Group() : base() { }
    public Group(Group instance) : base(instance)
    {
        GroupId = instance.GroupId;
        GroupName = instance.GroupName;
        Description = instance.Description;
    }

    public int GroupId { get; set; }
    public string? GroupName { get; set; }
    public string? Description { get; set; }
}
