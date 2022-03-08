namespace SolaERP.Client.Data
{
    public class GridPageSize
    {
        public GridPageSize()
        {
            GridPageSizeList = new List<GridPageSize>() {
            new GridPageSize {Caption="10", Size=10},
            new GridPageSize {Caption="20", Size=20},
            new GridPageSize {Caption="50", Size=50},
            new GridPageSize {Caption="100", Size=100},
            new GridPageSize {Caption="1000", Size=1000}};
        }

        public GridPageSize(int maxCount)
        {
            GridPageSizeList = new List<GridPageSize>() {
            new GridPageSize {Caption = $"All ({maxCount})", Size = maxCount},
            new GridPageSize {Caption="10", Size=10},
            new GridPageSize {Caption="20", Size=20},
            new GridPageSize {Caption="50", Size=50},
            new GridPageSize {Caption="100", Size=100},
            new GridPageSize {Caption="1000", Size=1000}};
        }

        public string Caption { get; private set; }
        public int Size { get; private set; }

        public List<GridPageSize> GridPageSizeList { get; private set; }
    }
}
