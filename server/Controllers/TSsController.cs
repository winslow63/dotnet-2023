using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TSsController : ControllerBase
{
    private readonly ShopProgramDbContext _context;
    private readonly IMapper _mapper;

    public TSsController(ShopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<TSGetDto>>> GetTS()
    {
        if (_context.TS == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<TSGetDto>(_context.TS).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TSGetDto>> GetTS(int id)
    {
        if (_context.TS == null)
        {
            return NotFound();
        }
        var tS = await _context.TS.FindAsync(id);

        if (tS == null)
        {
            return NotFound();
        }

        return _mapper.Map<TSGetDto>(tS);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutTS(int id, TSPostDto tS)
    {
        if (_context.TS == null)
        {
            return NotFound();
        }
        var tsoModify = await _context.TS.FindAsync(id);
        if (tsoModify == null)
        {
            return NotFound();
        }
        _mapper.Map(tS, tsoModify);

        //_context.Entry(shop).State = EntityState.Modified;


        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<TSGetDto>> PostTS(TSPostDto tS)
    {
        if (_context.TS == null)
        {
            return Problem("Entity set 'shopProgramDbContext.TS'  is null.");
        }
        var mapperTS = _mapper.Map<TS>(tS);
        _context.TS.Add(mapperTS);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTS", new { id = mapperTS.Id }, _mapper.Map<TSGetDto>(mapperTS));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTS(int id)
    {
        if (_context.TS == null)
        {
            return NotFound();
        }
        var tS = await _context.TS.FindAsync(id);
        if (tS == null)
        {
            return NotFound();
        }

        _context.TS.Remove(tS);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}

