using VentaCursos.Api.Models;

namespace VentaCursos.Api.Services;

public interface ICourseService
{
    // Métodos CRUD
    Course Create(Course course);
    Course? GetById(string id);
    IEnumerable<Course> GetAll();
    Course Update(string id, Course course);
    bool Delete(string id); 
}