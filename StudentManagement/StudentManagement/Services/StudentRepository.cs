using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models;
using SharedLibrary.Repository;
using StudentManagement.Data;

namespace StudentManagement.Services
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext _context;

		public StudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Student> AddStudentAsync(Student student)
		{
			if (student == null) return null;

			var newStudent = _context.Students.Add(student).Entity;

			await _context.SaveChangesAsync();

			return newStudent;
		}

		public async Task<Student> DeleteStudentAsync(int studentId)
		{
			var deleteStudent = await _context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();

			if (deleteStudent == null) return null;

			_context.Students.Remove(deleteStudent);
			await _context.SaveChangesAsync();

			return deleteStudent;
		}

		public async Task<List<Student>> GetAllStudentsAsync()
		{
			var students = await _context.Students.ToListAsync();

			return students;


		}

		public async Task<Student> GetStudentByIdAsync(int studentId)
		{
			var student = await _context.Students.Where(x => x.Id == studentId).SingleOrDefaultAsync();
			if (student == null) return null;

			return student;
		}

		public async Task<Student> UpdateStudentAsync(Student student)
		{
			if (student == null) return null;

			var updateStudent = _context.Students.Update(student).Entity;

			await _context.SaveChangesAsync();

			return updateStudent;
		}
	}
}
