
namespace SolaERP.Shared.Model
{
    public class AppUser : IBaseModel
    {
        public AppUser()
        {
            RowIndex = -1;
            ChangePassword = false;
            StatusId = 0;
            Theme = "light";
            ExpirationDate = new DateTime(2099, 12, 31);
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RowIndex { get; set; }
        public string FullName { get; set; }
        public string NotificationEmail { get; set; }
        public bool ChangePassword { get; set; }
        public int StatusId { get; set; }
        public string Theme { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Sessions { get; set; }
        public DateTime LastActivity { get; set; }
        public byte[] Photo { get; set; }
        public string ReturnMessage { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
    }
}

