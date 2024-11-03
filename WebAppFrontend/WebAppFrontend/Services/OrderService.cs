using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAppFrontend.Models;

namespace WebAppFrontend.Services // กำหนด namespace ที่เหมาะสม
{
    public class OrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("https://localhost:5001/api/order");
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"https://localhost:5001/api/order/{id}");
        }

        public async Task CreateOrderAsync(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5001/api/order", order);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:5001/api/order/{id}", order);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:5001/api/order/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
