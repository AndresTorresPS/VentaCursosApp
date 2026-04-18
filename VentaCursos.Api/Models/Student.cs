namespace VentaCursos.Api.Models;

public class Student
{
    public string Id { get; set; } = "000000";
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Relación derivada: Lista de cursos que el estudiante ha "comprado" o en los que está inscrito.
    // List<> para representar la multiplicidad "*" de la relación entre Student y Course.
    public List<Course> PurchasedCourses { get; set; } = new List<Course>();
    public List<Course> EnrolledCourses { get; set; } = new List<Course>();
}