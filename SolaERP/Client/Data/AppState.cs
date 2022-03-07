using MudBlazor;

namespace SolaERP.Client.Data
{
    public class AppState
    {
        ISnackbar Snackbar { get; set; }
        SessionData _sessionData;
        PageData _pageData;
        public AppState(ISnackbar snackbar, SessionData sessionData, PageData pageData)
        {
            Snackbar = snackbar;
            _sessionData = sessionData;
            _pageData = pageData;
        }

        public void ShowAlert(string message, Severity severity, Action onClick = null)
        {
            Snackbar.Add(message, severity, config =>
            {
                config.Onclick = snackbar =>
                {
                    config.RequireInteraction = (onClick != null);
                    onClick?.Invoke();
                    return Task.CompletedTask;
                };
            });
        }

        public event Action OnRefreshClick;

        public void Refresh()
        {
            OnRefreshClick?.Invoke();
        }

    }
}
