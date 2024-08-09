using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API.Controllers;

[Controller]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly MongoDBService _mongoDBService;

    public PlaylistController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Playlist playlist)
    {
        await _mongoDBService.CreateAsync(playlist);
        // return Ok();
        return CreatedAtAction(nameof(Get), new { id = playlist.Id }, playlist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] string movieId)
    {
        await _mongoDBService.UpdateAsync(id, movieId);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongoDBService.DeleteAsync(id);
        return Ok();
    }
}