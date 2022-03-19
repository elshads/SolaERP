﻿
namespace SolaERP.Shared.Model;
public class Group :BaseModel
{
    public int GroupId { get; set; }

    [Required(ErrorMessage = "Required")]
    public string? GroupName { get; set; }
    public string? Description { get; set; }
    public IEnumerable<AppUser> Users { get; set; }
    public IEnumerable<BusinessUnit> BusinessUnits { get; set; }
    public IEnumerable<BusinessUnit> Menus { get; set; }
    public IEnumerable<BusinessUnit> Roles { get; set; }
    public IEnumerable<Unit> Units { get; set; }
}
