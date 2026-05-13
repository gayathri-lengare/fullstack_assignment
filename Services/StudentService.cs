using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories;

namespace StudentManagementAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Get All Students
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        // Get Student By Id
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        // Add Student
        public async Task<Student> AddStudentAsync(Student student)
        {
            student.CreatedDate = DateTime.Now;

            await _studentRepository.AddAsync(student);

            return student;
        }

        // Update Student
        public async Task<Student> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await _studentRepository.GetByIdAsync(id);

            if (existingStudent == null)
            {
                return null;
            }

            if (!string.IsNullOrEmpty(student.Name))
            {
                existingStudent.Name = student.Name;
            }

            if (!string.IsNullOrEmpty(student.Email))
            {
                existingStudent.Email = student.Email;
            }

            if (student.Age != 0)
            {
                existingStudent.Age = student.Age;
            }

            if (!string.IsNullOrEmpty(student.Course))
            {
                existingStudent.Course = student.Course;
            }

            await _studentRepository.UpdateAsync(existingStudent);

            return existingStudent;
        }

        // Delete Student
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student == null)
            {
                return false;
            }

            await _studentRepository.DeleteAsync(student);

            return true;
        }
    }
}