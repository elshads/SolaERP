using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SolaERP.Client.Data
{
    public class SessionData
    {
        internal AppUser? CurrentUser { get; set; } = new();
        public List<UserMenuAccess>? CurrentUserMenuAccessList { get; set; }
        public PaymentDocumentMain PaymentDocumentMain { get; set; }
    }
}
