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
        bool addButtonVisible;
        bool addButtonEnabled;
        bool deleteButtonVisible;
        bool deleteButtonEnabled;
        bool saveButtonVisible;
        bool saveButtonEnabled;
        bool reloadButtonVisible;
        bool reloadButtonEnabled;
        bool reportButtonVisible;
        bool reportButtonEnabled;

        public ReportDefinition Report { get; set; }
        public bool Loading { get { return loading; } set { loading = value; Refresh(); } }
        public bool AddButtonVisible { get { return addButtonVisible; } set { addButtonVisible = value; } }
        public bool AddButtonEnabled { get { return addButtonEnabled; } set { addButtonEnabled = value; } }
        public bool DeleteButtonVisible { get { return deleteButtonVisible; } set { deleteButtonVisible = value; } }
        public bool DeleteButtonEnabled { get { return deleteButtonEnabled; } set { deleteButtonEnabled = value; } }
        public bool SaveButtonVisible { get { return saveButtonVisible; } set { saveButtonVisible = value; } }
        public bool SaveButtonEnabled { get { return saveButtonEnabled; } set { saveButtonEnabled = value; } }
        public bool ReloadButtonVisible { get { return reloadButtonVisible; } set { reloadButtonVisible = value; } }
        public bool ReloadButtonEnabled { get { return reloadButtonEnabled; } set { reloadButtonEnabled = value; } }
        public bool ReportButtonVisible { get { return reportButtonVisible; } set { reportButtonVisible = value; } }
        public bool ReportButtonEnabled { get { return reportButtonEnabled; } set { reportButtonEnabled = value; } }


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
