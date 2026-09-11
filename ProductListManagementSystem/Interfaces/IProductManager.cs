namespace ProductListManagementSystem.Interfaces
{
    public interface IProductManager
    {
        string? Category { get; set; }
        string? Name { get; set; }
        decimal Price { get; set; }

        void AddProduct();
        void ListProducts();
        void LoadProducts();
        void RemoveProduct();
        void SaveProducts();
        void SearchProduct();
        string SetProductCategory();
        string SetProductName();
        decimal SetProductPrice();
        void ShowStatistics();
        void UpdateProduct();
    }
}