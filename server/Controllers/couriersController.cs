using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouriersController : ControllerBase
{
    private readonly ShopProgramDbContext _context;
    private readonly IMapper _mapper;

    public CouriersController(ShopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourierGetDto>>> Getcourier()
    {
        if (_context.Courier == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<CourierGetDto>(_context.Courier).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CourierGetDto>> Getcourier(int id)
    {
        if (_context.Courier == null)
        {
            return NotFound();
        }
        var courier = await _context.Courier.FindAsync(id);

        if (courier == null)
        {
            return NotFound();
        }

        return _mapper.Map<CourierGetDto>(courier);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Putcourier(int id, CourierPostDto courier)
    {
        if (_context.Courier == null)
        {
            return NotFound();
        }
        var courierToModify = await _context.Courier.FindAsync(id);
        if (courierToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(courier, courierToModify);



        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost]
    public async Task<ActionResult<CourierGetDto>> Postcourier(CourierPostDto courier)
    {
        if (_context.Courier == null)
        {
            return Problem("Entity set 'shopProgramDbContext.courier'  is null.");
        }
        var mapperCourier = _mapper.Map<Courier>(courier);
        _context.Courier.Add(mapperCourier);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Getcourier", new { id = mapperCourier.Id }, _mapper.Map<CourierGetDto>(mapperCourier));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletecourier(int id)
    {
        if (_context.Courier == null)
        {
            return NotFound();
        }
        var courier = await _context.Courier.FindAsync(id);
        if (courier == null)
        {
            return NotFound();
        }

        _context.Courier.Remove(courier);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}

