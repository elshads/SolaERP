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
            SetDefaults();
        }

        public void SetDefaults()
        {
            AddButtonVisible = false;
            AddButtonEnabled = true;
            DeleteButtonVisible = false;
            DeleteButtonEnabled = true;
            SaveButtonVisible = false;
            SaveButtonEnabled = true;
            ReloadButtonVisible = true;
            ReloadButtonEnabled = true;
            ReportButtonVisible = false;
            ReportButtonEnabled = true;

            MobileView = false;
            Report = null;
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

        bool loading;

        public ReportDefinition Report { get; set; }
        public bool MobileView { get; set; }
        public bool Loading { get { return loading; } set { loading = value; Refresh(); } }
        public bool AddButtonVisible { get; set; }
        public bool AddButtonEnabled { get; set; }
        public bool DeleteButtonVisible { get; set; }
        public bool DeleteButtonEnabled { get; set; }
        public bool SaveButtonVisible { get; set; }
        public bool SaveButtonEnabled { get; set; }
        public bool ReloadButtonVisible { get; set; }
        public bool ReloadButtonEnabled { get; set; }
        public bool ReportButtonVisible { get; set; }
        public bool ReportButtonEnabled { get; set; }


        public event Action OnRefreshClick;
        public event Action OnAddClick;
        public event Action OnDeleteClick;
        public event Action OnSaveClick;
        public event Action OnReloadClick;
        public event Action OnReportClick;

        public void Refresh()
        {
            OnRefreshClick?.Invoke();
        }

        public void AddClick()
        {
            OnAddClick?.Invoke();
        }

        public void DeleteClick()
        {
            OnDeleteClick?.Invoke();
        }

        public void SaveClick()
        {
            OnSaveClick?.Invoke();
        }

        public void ReloadClick()
        {
            OnReloadClick?.Invoke();
        }

        public void ReportClick()
        {
            OnReportClick?.Invoke();
        }

    }
}
