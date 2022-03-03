using MudBlazor;

namespace SolaERP.Client.Data
{
    public class AppState
    {
        private ISnackbar Snackbar { get; set; }
        public AppState(ISnackbar snackbar)
        {
            Snackbar = snackbar;
        }

        public void ShowAlert(string message, MudBlazor.Severity severity, Action onClick = null)
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
