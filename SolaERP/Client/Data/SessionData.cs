namespace SolaERP.Client.Data
{
    public class SessionData
    {
        public SessionData()
        {
            CurrentUser = new AppUser();
            CurrentUserMenuAccessList = new List<UserMenuAccess>();
            Loading = true;
        }
        internal AppUser? CurrentUser { get; set; }
        public List<UserMenuAccess>? CurrentUserMenuAccessList { get; set; }
        public bool Loading { get; set; }
    }
}
