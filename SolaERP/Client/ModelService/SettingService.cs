namespace SolaERP.Client.ModelService
{
    internal class SettingService : BaseService<Setting>
    {
        public Setting Setting { get; set; } = new();
    }
}
