using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;
using SharedLibrary.Repository;

namespace StudentManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
	private readonly IStudentRepository _studentRepository;

	public StudentController(IStudentRepository studentRepository)
	{
		_studentRepository = studentRepository;
	}

	[HttpGet("All-Students")]
	public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
	{
		var students = await _studentRepository.GetAllStudentsAsync();

		return Ok(students);
	}

	[HttpGet("Single-Student/{id}")]
	public async Task<ActionResult<Student>> GetSingleStudentAsync(int id)
	{
		var student = await _studentRepository.GetStudentByIdAsync(id);
		return Ok(student);
	}

	[HttpPost("Add-Student")]
	public async Task<ActionResult<Student>> AddStudentAsync(Student student)
	{
		var newStudent = await _studentRepository.AddStudentAsync(student);

		return Ok(newStudent);
	}

	[HttpDelete("Delete-Student/{id}")]
	public async Task<ActionResult<Student>> DeleteStudentAsync(int id)
	{
		var student = await _studentRepository.DeleteStudentAsync(id);

		return Ok(student);
	}

	[HttpPost("Update-Student")]
	public async Task<ActionResult<Student>> UpdateStudentAsync(Student student)
	{
		var updateStudent = await _studentRepository.UpdateStudentAsync(student);	
		return Ok(updateStudent);
	}


}






