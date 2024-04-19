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
    private readonly shopProgramDbContext _context;
    private readonly IMapper _mapper;

    public ShopsController(shopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<shopGetDto>>> Getshop()
    {
        if (_context.shop == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<shopGetDto>(_context.shop).ToListAsync();
        //return await _context.shop.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<shopGetDto>> GetShop(int id)
    {
        if (_context.shop == null)
        {
            return NotFound();
        }
        var shop = await _context.shop.FindAsync(id);

        if (shop == null)
        {
            return NotFound();
        }

        //return shop;
        return _mapper.Map<shopGetDto>(shop);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutShop(int id, shopPostDto shop)
    {

        if (_context.shop == null)
        {
            return NotFound();
        }
        var shopToModify = await _context.shop.FindAsync(id);
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
    public async Task<ActionResult<shopGetDto>> PostShop(shopPostDto shop)
    {
        if (_context.shop == null)
        {
            return Problem("Entity set 'shopProgramDbContext.shop'  is null.");
        }
        var mapperShop = _mapper.Map<Shop>(shop);
        _context.shop.Add(mapperShop);

        await _context.SaveChangesAsync();

        return CreatedAtAction("PostShop", new { id = mapperShop.Id }, _mapper.Map<shopGetDto>(mapperShop));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShop(int id)
    {
        if (_context.shop == null)
        {
            return NotFound();
        }
        var shop = await _context.shop.FindAsync(id);
        if (shop == null)
        {
            return NotFound();
        }

        _context.shop.Remove(shop);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}

