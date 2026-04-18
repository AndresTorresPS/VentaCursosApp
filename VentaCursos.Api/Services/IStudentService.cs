using VentaCursos.Api.Models;

namespace VentaCursos.Api.Services;

public interface IStudentService
{
    // Métodos CRUD
    Student Create(string name, string email);
    Student? GetById(string id);
    IEnumerable<Student> GetAll();
    Student Update(string id, string name, string email);
    bool Delete(string id);

    // Lógica de conexión con Course (Negocio)
    // Estos métodos corresponden a buyCourse y viewMyCourses del diagrama.
    void BuyCourse(string studentId, string courseId);
    void EnrollInCourse(string studentId, string courseId);
    IEnumerable<Course> ViewMyCourses(string studentId);
}