using eCommerce.Web.Models;
using eCommerce.Web.Services.IServices;
using eCommerce.Web.Ultils;

namespace eCommerce.Web.Services
{
    public class ProductService : IProductService
    {

        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";


        public ProductService(HttpClient client)
        {
                _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }


        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);

            if (response.IsSuccessStatusCode) return await response.ReadContentAs<ProductModel>();

            else
                throw new Exception($"Something went wrong whem calling API. \nERROR: {response.StatusCode}");
        }


        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }


        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            if(response.IsSuccessStatusCode) return await response.ReadContentAs<bool>();

            else
                throw new Exception($"Something went wrong whem calling API. \nERROR: {response.StatusCode}");
        }
    }
}
