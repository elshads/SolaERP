
namespace SolaERP.Shared.Model
{
    public class Setting : BaseModel
    {
        public int MaxFileSize { get; set; } = 1024 * 1024 * 10;
        public int MaxFileSizeMb => MaxFileSize / 1024 / 1024;
        public List<string> AllowedFileExtensions { get; set; }
        public int MaxImageSize { get; set; } = 1024 * 1024 * 10;
        public int MaxImageSizeMb => MaxImageSize / 1024 / 1024;
        public List<string> AllowedImageExtensions { get; set; } = new() { "*" };
        public int MaxNumberOfFiles { get; set; }
        public int BaseCurrencyId { get; set; }
        public string DefaultTheme { get; set; } = "light";
    }
}
