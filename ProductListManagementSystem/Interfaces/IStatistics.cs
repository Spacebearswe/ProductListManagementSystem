//using ProductListManagementSystem.Application;
namespace ProductListManagementSystem.Interfaces
{
    public interface IStatistics
    {
        string GetHighestNumber(List<Product> products);
        string GetLowestNumber(List<Product> products);
        string GetTotalPrice(List<Product> products);
    }
}