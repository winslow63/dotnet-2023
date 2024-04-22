using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Dto;
using shopOnline;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ShopProgramDbContext _context;
    private readonly IMapper _mapper;

    public ClientsController(ShopProgramDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientGetDto>>> Getclient()
    {
        if (_context.Client == null)
        {
            return NotFound();
        }
        return await _mapper.ProjectTo<ClientGetDto>(_context.Client).ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ClientGetDto>> Getclient(int id)
    {
        if (_context.Client == null)
        {
            return NotFound();
        }
        var client = await _context.Client.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return _mapper.Map<ClientGetDto>(client);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Putclient(int id, ClientPostDto client)
    {
        if (_context.Client == null)
        {
            return NotFound();
        }
        var clientToModify = await _context.Client.FindAsync(id);
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
    public async Task<ActionResult<ClientGetDto>> Postclient(ClientPostDto client)
    {
        if (_context.Client == null)
        {
            return Problem("Entity set 'shopProgramDbContext.client'  is null.");
        }
        var mapperClient = _mapper.Map<Client>(client);
        _context.Client.Add(mapperClient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Getclient", new { id = mapperClient.Id }, _mapper.Map<ClientGetDto>(mapperClient));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Deleteclient(int id)
    {
        if (_context.Client == null)
        {
            return NotFound();
        }
        var client = await _context.Client.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Client.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}

