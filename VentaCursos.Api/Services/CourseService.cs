using System.Security.Cryptography;

using VentaCursos.Api.Models;

namespace VentaCursos.Api.Services;

public class CourseService : ICourseService
{
    // Simulamos una base de datos con una lista estática
    private static readonly List<Course> _courses = new()
    {
        new Course { Id = "543fa2", Title = "C#", Price = 20, Author = "Juan Banuelos" },
        new Course { Id = "543fa3", Title = "GitHub", Price = 15, Author = "Jaime Torres" }
    };

    public IEnumerable<Course> GetAll() => _courses;

    public Course? GetById(string id) => _courses.FirstOrDefault(c => c.Id == id);

    public Course Create(Course course) 
    {
        course.Id = GenerateUniqueHexId();
        _courses.Add(course);
        return course;
    }

    public Course Update(string id, Course course)
    {
        var existing = GetById(id) ?? throw new KeyNotFoundException($"Course not found: {id}");
        existing.Title = course.Title;
        existing.Description = course.Description;
        existing.Price = course.Price;
        existing.Author = course.Author;
        return existing;
    }

    public bool Delete(string id)
    {
        var course = GetById(id);
        if (course is null)
        {
            return false;
        }

        return _courses.Remove(course);
    }

    // Método auxiliar para generar un ID hexadecimal único de 6 caracteres (como un color)
    private string GenerateUniqueHexId()
    {
        string newId;
        do
        {
            // Genera 3 bytes aleatorios (para 6 caracteres hex)
            byte[] bytes = new byte[3];
            RandomNumberGenerator.Fill(bytes);
            
            // Convierte a string hexadecimal en mayúsculas
            newId = BitConverter.ToString(bytes).Replace("-", "").ToUpperInvariant();
        }
        while (_courses.Any(c => c.Id == newId));  // Asegura unicidad
        
        return newId;
    }
}
