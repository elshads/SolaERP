namespace SolaERP.Client.Data
{
    public class SessionData
    {
        public SessionData()
        {
            CurrentUser = new AppUser();
            Loading = false;
        }
        internal AppUser? CurrentUser { get; set; }
        public List<UserMenuAccess>? CurrentUserMenuAccessList { get; set; }
        public bool Loading { get; set; }
    }
}
