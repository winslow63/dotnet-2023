using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class clientsController : ControllerBase
{
    private readonly shopProgramDbContext _context;
    private readonly IMapper _mapper;

    public clientsController(shopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<clientGetDto>>> Getclient()
    {
        if (_context.client == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<clientGetDto>(_context.client).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<clientGetDto>> Getclient(int id)
    {
        if (_context.client == null)
        {
            return NotFound();
        }
        var client = await _context.client.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return _mapper.Map<clientGetDto>(client);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Putclient(int id, clientPostDto client)
    {
        if (_context.client == null)
        {
            return NotFound();
        }
        var clientToModify = await _context.client.FindAsync(id);
        if (clientToModify == null)
        {
            return NotFound();
        }
        _mapper.Map(client, clientToModify);

        //_context.Entry(shop).State = EntityState.Modified;


        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<ActionResult<clientGetDto>> Postclient(clientPostDto client)
    {
        if (_context.client == null)
        {
            return Problem("Entity set 'shopProgramDbContext.client'  is null.");
        }
        var mapperClient = _mapper.Map<client>(client);
        _context.client.Add(mapperClient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Getclient", new { id = mapperClient.Id }, _mapper.Map<clientGetDto>(mapperClient));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Deleteclient(int id)
    {
        if (_context.client == null)
        {
            return NotFound();
        }
        var client = await _context.client.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.client.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}

