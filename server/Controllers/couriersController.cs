using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class couriersController : ControllerBase
{
    private readonly shopProgramDbContext _context;
    private readonly IMapper _mapper;

    public couriersController(shopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<courierGetDto>>> Getcourier()
    {
        if (_context.courier == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<courierGetDto>(_context.courier).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<courierGetDto>> Getcourier(int id)
    {
        if (_context.courier == null)
        {
            return NotFound();
        }
        var courier = await _context.courier.FindAsync(id);

        if (courier == null)
        {
            return NotFound();
        }

        return _mapper.Map<courierGetDto>(courier);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Putcourier(int id, courierPostDto courier)
    {
        if (_context.courier == null)
        {
            return NotFound();
        }
        var courierToModify = await _context.courier.FindAsync(id);
        if (courierToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(courier, courierToModify);



        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost]
    public async Task<ActionResult<courierGetDto>> Postcourier(courierPostDto courier)
    {
        if (_context.courier == null)
        {
            return Problem("Entity set 'shopProgramDbContext.courier'  is null.");
        }
        var mapperCourier = _mapper.Map<courier>(courier);
        _context.courier.Add(mapperCourier);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Getcourier", new { id = mapperCourier.Id }, _mapper.Map<courierGetDto>(mapperCourier));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletecourier(int id)
    {
        if (_context.courier == null)
        {
            return NotFound();
        }
        var courier = await _context.courier.FindAsync(id);
        if (courier == null)
        {
            return NotFound();
        }

        _context.courier.Remove(courier);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}

