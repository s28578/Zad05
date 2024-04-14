using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/visits")]
[ApiController]
public class VisitsController : ControllerBase
{
    private static readonly List<Visit> _visits= new()
    {
        new Visit {AnimalId = 1, Date = "10.02.99", Description = "Everything ok.", Price = 10},
        new Visit {AnimalId = 1, Date = "23.02.99", Description = "Everything mostly ok.", Price = 8},
        new Visit {AnimalId = 2, Date = "10.07.20", Description = "Everything bad.", Price = 1},
    }; 
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisitsOfAnimal(int id)
    {
        

        var visits = _visits.FindAll(vis => vis.AnimalId == id);
        if (visits == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        
        return Ok(visits);
    }
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
}