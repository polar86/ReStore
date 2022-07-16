using System.Collections.Generic;
using System.Threading.Tasks;

using API.Data;
using API.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
  public class ProductsController : BaseController
  {
    private readonly StoreDbContext _context;
    public ProductsController(StoreDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    [SwaggerOperation(Summary = "List all Products", Description = "Get List of All Products", OperationId = "GetProducts", Tags = new[] { "Get" })]
    [SwaggerResponse(200, "Success get list of all producdts", typeof(List<Product>))]
    public async Task<IActionResult> GetProductsAsync()
    {
      return Ok(await _context.Products.ToListAsync());
    }
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get product by its id", Description = "Get single product by id", OperationId = "GetProduct", Tags = new[] { "Get" })]
    [SwaggerResponse(200, "Success get list of all producdts", typeof(Product))]

    public async Task<IActionResult> GetProductAsync(int id)
    {
      return Ok(await _context.Products.FindAsync(id));
    }
  }
}