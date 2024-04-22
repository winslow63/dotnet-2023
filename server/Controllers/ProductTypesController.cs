using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTypesController : ControllerBase
{
    private readonly ShopProgramDbContext _context;
    private readonly IMapper _mapper;

    public ProductTypesController(ShopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductType>>> GetProductType()
    {
        if (_context.ProductType == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ProductType>(_context.ProductType).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductType>> GetProductType(int id)
    {
        if (_context.ProductType == null)
        {
            return NotFound();
        }
        var productType = await _context.ProductType.FindAsync(id);

        if (productType == null)
        {
            return NotFound();
        }

        return _mapper.Map<ProductType>(productType);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductType(int id, ProductType productType)
    {
        if (_context.ProductType == null)
        {
            return NotFound();
        }
        var productTypeToModify = await _context.ProductType.FindAsync(id);
        if (productTypeToModify == null)
        {
            return NotFound();
        }

        _mapper.Map(productType, productTypeToModify);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
    {
        if (_context.ProductType == null)
        {
            return Problem("Entity set 'shopProgramDbContext.ProductType'  is null.");
        }
        _context.ProductType.Add(productType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProductType", new { id = productType.Id }, productType);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductType(int id)
    {
        if (_context.ProductType == null)
        {
            return NotFound();
        }
        var productType = await _context.ProductType.FindAsync(id);
        if (productType == null)
        {
            return NotFound();
        }

        _context.ProductType.Remove(productType);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

