using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetBookstore.Data;
using DotNetBookstore.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotNetBookstore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            // if user is Administrator, return all orders
            if (User.IsInRole("Administrator"))
            {
                return _context.Orders != null ?
                    View(await _context.Orders.ToListAsync()) :
                    Problem("Entity set 'ApplicationDbContext.Orders'  is null.");
            }
            else
            {
                // user is a customer - only fetch their own orders and no one else's
                var orders = await _context.Orders.Where(o => o.CustomerId == User.Identity.Name).ToListAsync();
                return View(orders);
            }
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Books)
                .FirstOrDefaultAsync(m => m.OrderId == id);

            // if user is not Administrator, check they own the selected order
            if (!User.IsInRole("Administrator"))
            {
                if (order.CustomerId != User.Identity.Name)
                {
                    order = null;
                }
            }

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}