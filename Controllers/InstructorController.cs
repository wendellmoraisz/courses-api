using CoursesAPI.Common.Exceptions;
using CoursesAPI.Models;
using CoursesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly IInstructorRepository _repository;
    private readonly IUnityOfWork _unityOfWork;

    public InstructorController(IInstructorRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    [HttpGet("{id}")]
    public ActionResult<Instructor> GetById(int id)
    {
        var instructor = _repository.GetById(id);
        if (instructor is null)
        {
            return NotFound();
        }
        return Ok(instructor);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Instructor>> GetAll()
    {
        var instructors = _repository.GetAll();
        return Ok(instructors);
    }

    [HttpPost]
    public async Task<ActionResult<Instructor>> Create(Instructor instructor)
    {
        _repository.Create(instructor);
        await _unityOfWork.SaveAsync();

        return CreatedAtAction(nameof(GetById), new { id = instructor.Id }, instructor);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Instructor instructor)
    {
        _repository.Update(instructor);
        await _unityOfWork.SaveAsync();

        return Ok(new { message = "Atualizado com sucesso", data = instructor });
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> Delete(int Id)
    {
        try
        {
            _repository.Delete(Id);
            await _unityOfWork.SaveAsync();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return Ok(new { message = "Deletado com sucesso", id = Id });
    }
}
