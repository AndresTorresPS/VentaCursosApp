using VentaCursos.Api.Models;

namespace VentaCursos.Api.Services;

public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course? GetById(string id);
    void Create(Course course);
}