using Microsoft.AspNetCore.Mvc;
using WebAppFrontend.Models;
using WebAppFrontend.Services;

namespace WebAppFrontend.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(string sortColumn = "OrderDate", string sortOrder = "Asc", string searchType = "", string searchValue = "", DateTime? startDate = null, DateTime? endDate = null)
        {
            List<Order> orders = await _orderService.GetOrdersAsync();

            if (startDate.HasValue && endDate.HasValue)
            {
                orders = orders.Where(o => o.OrderDate.Date >= startDate.Value.Date && o.OrderDate.Date <= endDate.Value.Date).ToList();
            }

            if (!string.IsNullOrEmpty(searchType) && !string.IsNullOrEmpty(searchValue))
            {
                switch (searchType)
                {
                    case "OrderDate":
                        if (DateTime.TryParse(searchValue, out var parsedDate))
                        {
                            orders = orders.Where(o => o.OrderDate.Date == parsedDate.Date).ToList();
                        }
                        break;
                    case "Region":
                        orders = orders.Where(o => o.Region.Contains(searchValue)).ToList();
                        break;
                    case "City":
                        orders = orders.Where(o => o.City.Contains(searchValue)).ToList();
                        break;
                    case "Category":
                        orders = orders.Where(o => o.Category.Contains(searchValue)).ToList();
                        break;
                    case "Product":
                        orders = orders.Where(o => o.Product.Contains(searchValue)).ToList();
                        break;
                }
            }



            if (!string.IsNullOrEmpty(sortColumn))
            {
                switch (sortColumn)
                {
                    case "OrderDate":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.OrderDate).ToList() : orders.OrderByDescending(o => o.OrderDate).ToList();
                        break;
                    case "Region":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.Region).ToList() : orders.OrderByDescending(o => o.Region).ToList();
                        break;
                    case "City":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.City).ToList() : orders.OrderByDescending(o => o.City).ToList();
                        break;
                    case "Category":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.Category).ToList() : orders.OrderByDescending(o => o.Category).ToList();
                        break;
                    case "Product":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.Product).ToList() : orders.OrderByDescending(o => o.Product).ToList();
                        break;
                    case "Quantity":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.Quantity).ToList() : orders.OrderByDescending(o => o.Quantity).ToList();
                        break;
                    case "UnitPrice":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.UnitPrice).ToList() : orders.OrderByDescending(o => o.UnitPrice).ToList();
                        break;
                    case "TotalPrice":
                        orders = sortOrder == "Asc" ? orders.OrderBy(o => o.TotalPrice).ToList() : orders.OrderByDescending(o => o.TotalPrice).ToList();
                        break;
                    default:
                        orders = orders.OrderBy(o => o.Id).ToList();
                        break;
                }
            }

            sortOrder = sortOrder == "Asc" ? "Desc" : "Asc";

            ViewData["SortColumn"] = sortColumn;
            ViewData["SortOrder"] = sortOrder;

            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            order.TotalPrice = order.Quantity * order.UnitPrice;
            await _orderService.CreateOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                order.TotalPrice = order.Quantity * order.UnitPrice;
                await _orderService.UpdateOrderAsync(order.Id, order);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            int nonNullableId = id ?? 0;
            if (nonNullableId == 0)
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderAsync(nonNullableId);
            if (order == null)
            {
                return NotFound();
            }
            await _orderService.DeleteOrderAsync(nonNullableId);
            return RedirectToAction(nameof(Index));
        }
    }
}
