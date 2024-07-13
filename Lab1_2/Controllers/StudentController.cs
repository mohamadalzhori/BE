using System.Dynamic;
using Lab_1.Models;
using Lab_1.Repo;
using Microsoft.AspNetCore.Mvc;
using Lab_1.Common.Filters;

namespace Lab_1.Controllers;

[ApiController]
[Route("Student")]
public class StudentController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    private readonly IStudentRepo _studentRepo;
    private readonly ILogger<StudentController> _logger;

    public List<Student> Students { get; set; }

    public StudentController(IWebHostEnvironment env, IStudentRepo studentRepo, ILogger<StudentController> logger)
    {
        _env = env;
        _studentRepo = studentRepo;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public List<Student> GetAll()
    {
        _logger.LogInformation("Getting All Students");
        return _studentRepo.GetAll();
    }

    //[ServiceFilter(typeof(LoggingActionFilter))]
    [TypeFilter(typeof(LoggingActionFilter))]
    [HttpGet("Get")]
    public IActionResult Get(int id)
    {
        var student = _studentRepo.Get(id);
          
        if(student is null)
        {
            return NotFound();
        }
         
        return Ok(student);
    }

    [HttpGet("GetByName")]
    public IActionResult GetByName(string substring)
    {
        var students = _studentRepo.GetByName(substring);

        if(students.Count == 0)
        {
            return NotFound();
        }

        return Ok(students);
    }

    [HttpPost("SetName")]
    public IActionResult SetName(int id, string name)
    {
        try
        {
            _studentRepo.SetName(id, name);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message); 
        }

        return Ok();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            _studentRepo.Delete(id);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

        return Ok();
    }

}