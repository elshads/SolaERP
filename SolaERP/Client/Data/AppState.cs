namespace SolaERP.Client.Data
{
    public class AppState
    {
        public event Action OnRefreshClick;

        public void Refresh()
        {
            OnRefreshClick?.Invoke();
        }
    }
}
