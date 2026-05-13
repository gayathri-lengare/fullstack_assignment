using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get All Students
        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Student.ToListAsync();
        }

        // Get Student By Id
        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        // Add Student
        public async Task AddAsync(Student student)
        {
            await _context.Student.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        // Update Student
        public async Task UpdateAsync(Student student)
        {
            _context.Student.Update(student);
            await _context.SaveChangesAsync();
        }

        // Delete Student
        public async Task DeleteAsync(Student student)
        {
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}