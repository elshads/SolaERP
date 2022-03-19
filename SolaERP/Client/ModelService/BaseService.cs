namespace SolaERP.Client.ModelService
{
    internal class BaseService<T> where T : BaseModel, new()
    {
        internal T GetInstanceClone(T originalItem)
        {
            T newItem = new();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(newItem, property.GetValue(originalItem));
            }
            return newItem;
        }
    }
}
