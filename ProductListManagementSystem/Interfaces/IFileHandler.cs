namespace ProductListManagementSystem.Interfaces
{
    public interface IFileHandler
    {
        List<Product> CreateFirstTimeList();
        List<Product> Load();
        List<Product> Open();
        void Save(List<Product> products);
    }
}