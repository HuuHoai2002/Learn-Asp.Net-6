using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Learn_Asp.Net_6.Data;
using Learn_Asp.Net_6.Models;

namespace Learn_Asp.Net_6.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SuperHeroController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    public SuperHeroController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {

      var superHeroes = await _context.SuperHeroes.ToListAsync();

      return Ok(superHeroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
      var superHero = await _context.SuperHeroes.FindAsync(id);

      if (superHero == null)
      {
        return NotFound();
      }

      return Ok(superHero);
    }

    [HttpPost("create")]
    public async Task<ActionResult<SuperHero>> Post([FromBody] SuperHero hero)
    {
      _context.SuperHeroes.Add(hero);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
    }

    [HttpPut("update")]
    public async Task<ActionResult<SuperHero>> Put([FromBody] SuperHero hero)
    {
      var superHero = await _context.SuperHeroes.FindAsync(hero.Id);

      if (superHero == null)
      {
        return NotFound();
      }
      superHero.Id = hero.Id;
      superHero.Name = hero.Name;
      superHero.FirstName = hero.FirstName;
      superHero.LastName = hero.LastName;
      superHero.Place = hero.Place;
      superHero.UpdatedAt = DateTime.Now;

      await _context.SaveChangesAsync();

      return Ok(new { message = "Super Hero Updated" });
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<SuperHero>> Delete(int id)
    {
      var superHero = await _context.SuperHeroes.FindAsync(id);

      if (superHero == null)
      {
        return NotFound();
      }

      _context.SuperHeroes.Remove(superHero);
      await _context.SaveChangesAsync();

      return Ok(new { message = "Super Hero deleted successfully!" });
    }
  }
}
