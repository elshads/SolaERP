namespace SolaERP.Client.Model
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public bool Disabled { get; set; }
        public bool Separator { get; set; }
        public List<MenuItem> Items { get; set; }
        public int ReportId { get; set; }
    }
}
