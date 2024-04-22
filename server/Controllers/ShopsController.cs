using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopsController : ControllerBase
{
    private readonly ShopProgramDbContext _context;
    private readonly IMapper _mapper;

    public ShopsController(ShopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShopGetDto>>> Getshop()
    {
        if (_context.Shop == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ShopGetDto>(_context.Shop).ToListAsync();
        //return await _context.shop.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShopGetDto>> GetShop(int id)
    {
        if (_context.Shop == null)
        {
            return NotFound();
        }
        var shop = await _context.Shop.FindAsync(id);

        if (shop == null)
        {
            return NotFound();
        }

        //return shop;
        return _mapper.Map<ShopGetDto>(shop);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutShop(int id, ShopPostDto shop)
    {

        if (_context.Shop == null)
        {
            return NotFound();
        }
        var shopToModify = await _context.Shop.FindAsync(id);
        if (shopToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(shop, shopToModify);

        //_context.Entry(shop).State = EntityState.Modified;


        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<ShopGetDto>> PostShop(ShopPostDto shop)
    {
        if (_context.Shop == null)
        {
            return Problem("Entity set 'shopProgramDbContext.shop'  is null.");
        }
        var mapperShop = _mapper.Map<Shop>(shop);
        _context.Shop.Add(mapperShop);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostShop", new { id = mapperShop.Id }, _mapper.Map<ShopGetDto>(mapperShop));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
        if (_context.Shop == null)
        {
            return NotFound();
        }
        var shop = await _context.Shop.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }

        _context.Shop.Remove(shop);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}

