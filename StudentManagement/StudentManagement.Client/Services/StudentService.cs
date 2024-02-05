using SharedLibrary.Models;
using SharedLibrary.Repository;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services;

public class StudentService : IStudentRepository
{
	private readonly HttpClient _httpClient;

	public StudentService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<Student> AddStudentAsync(Student student)
	{
		var newStudent = await _httpClient.PostAsJsonAsync("api/Student/Add-Student", student);

		var response = await newStudent.Content.ReadFromJsonAsync<Student>();

		return response;
	}

	public Task<Student> DeleteStudentAsync(int studentId)
	{
		throw new NotImplementedException();
	}

	public async Task<List<Student>> GetAllStudentsAsync()
	{
		var students = await _httpClient.GetAsync("api/Student/All-Students");
		var response = await students.Content.ReadFromJsonAsync<List<Student>>();
		return response;
	}

	public async Task<Student> GetStudentByIdAsync(int studentId)
	{
		var student = await _httpClient.GetAsync($"api/Student/Single-Student/{studentId}");
		var response = await student.Content.ReadFromJsonAsync<Student>();
		return response;
	}

	public async Task<Student> UpdateStudentAsync(Student student)
	{
		var updateStudent = await _httpClient.PostAsJsonAsync("api/Student/Update-Student", student);
		var response = await updateStudent.Content.ReadFromJsonAsync<Student>();
		return response;
	}
}
