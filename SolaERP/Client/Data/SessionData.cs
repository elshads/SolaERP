using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SolaERP.Client.Data
{
    public class SessionData
    {
        public SessionData()
        {
            CurrentUser = new AppUser();
        }
        internal AppUser? CurrentUser { get; set; }
        public List<UserMenuAccess>? CurrentUserMenuAccessList { get; set; }

        public AuthenticationState AuthenticationState { get; set; }

        public PaymentDocumentMain PaymentDocumentMain { get; set; }
        public List<PaymentDocumentDetail> PaymentDocumentSummaryList { get; set; } = new();
    }
}
