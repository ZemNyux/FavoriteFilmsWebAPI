using FavoriteFilmsMVC.Models;
using FavoriteFilmsMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteFilmsMVC.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMoviesService _moviesService;

    public MoviesController(IMoviesService moviesService)
    {
        _moviesService = moviesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _moviesService.GetAllAsync();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _moviesService.GetByIdAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] Movie movie, IFormFile? poster)
    {
        var createdMovie = await _moviesService.CreateAsync(movie, poster);
        return CreatedAtAction(nameof(GetById), new { id = createdMovie.Id }, createdMovie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] Movie movie, IFormFile? poster)
    {
        var result = await _moviesService.UpdateAsync(id, movie, poster);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _moviesService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}