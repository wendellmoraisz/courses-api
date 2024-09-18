using CoursesAPI.Common.Exceptions;
using CoursesAPI.Models;
using CoursesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _repository;
    private readonly IUnityOfWork _unityOfWork;

    public StudentController(IStudentRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _repository.GetById(id);
        if (student is null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        var students = _repository.GetAll();
        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student student)
    {
        _repository.Create(student);
        await _unityOfWork.SaveAsync();

        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut]
    public async Task<ActionResult> Update(Student student)
    {
        _repository.Update(student);
        await _unityOfWork.SaveAsync();

        return Ok(new { message = "Atualizado com sucesso", data = student });
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
