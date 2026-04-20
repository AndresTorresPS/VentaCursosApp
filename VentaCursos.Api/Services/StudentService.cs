using System.Security.Cryptography;
using VentaCursos.Api.Models;

namespace VentaCursos.Api.Services;

public class StudentService : IStudentService
{
    private readonly ICourseService _courseService;
    private static readonly List<Student> _students = new();

    public StudentService(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public Student Create(string name, string email)
    {
        var student = new Student
        {
            Id = GenerateUniqueHexId(),
            Name = name,
            Email = email
        };

        _students.Add(student);
        return student;
    }

    public Student? GetById(string id) => _students.FirstOrDefault(s => s.Id == id);

    public IEnumerable<Student> GetAll() => _students;

    public Student Update(string id, string name, string email)
    {
        var student = GetById(id) ?? throw new KeyNotFoundException($"Student not found: {id}");
        student.Name = name;
        student.Email = email;
        return student;
    }

    public bool Delete(string id)
    {
        var student = GetById(id);
        if (student is null)
        {
            return false;
        }

        return _students.Remove(student);
    }

    public void BuyCourse(string studentId, string courseId)
    {
        var student = GetById(studentId) ?? throw new KeyNotFoundException($"Student not found: {studentId}");
        var course = _courseService.GetById(courseId) ?? throw new KeyNotFoundException($"Course not found: {courseId}");

        if (student.PurchasedCourses.Any(c => c.Id == course.Id))
        {
            return;
        }

        student.PurchasedCourses.Add(course);
    }

    public void EnrollInCourse(string studentId, string courseId)
    {
        var student = GetById(studentId) ?? throw new KeyNotFoundException($"Student not found: {studentId}");
        var course = _courseService.GetById(courseId) ?? throw new KeyNotFoundException($"Course not found: {courseId}");

        if (student.EnrolledCourses.Any(c => c.Id == course.Id))
        {
            return;
        }

        student.EnrolledCourses.Add(course);
    }

    public IEnumerable<Course> ViewMyCourses(string studentId)
    {
        var student = GetById(studentId) ?? throw new KeyNotFoundException($"Student not found: {studentId}");
        return student.PurchasedCourses.Concat(student.EnrolledCourses).GroupBy(c => c.Id).Select(g => g.First());
    }

    private string GenerateUniqueHexId()
    {
        string newId;
        do
        {
            byte[] bytes = new byte[3];
            RandomNumberGenerator.Fill(bytes);
            newId = BitConverter.ToString(bytes).Replace("-", "").ToUpperInvariant();
        }
        while (_students.Any(s => s.Id == newId));

        return newId;
    }
}
