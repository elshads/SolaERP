namespace SolaERP.Client.Data
{
    public class SessionData
    {
        public SessionData()
        {
            CurrentUser = new AppUser();
            Loading = true;
        }
        internal AppUser? CurrentUser { get; set; }
        public bool Loading { get; set; }
    }
}
