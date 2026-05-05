using DesignPatterns.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly BankContext _context;

    public ProductController(BankContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 8; // Her sayfada gösterilecek ürün sayısı
        var totalItems = await _context.Products.CountAsync();

        var products = await _context.Products
            .Include(x => x.Category)
            .OrderBy(x => x.ProductId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        return View(products);
    }
}