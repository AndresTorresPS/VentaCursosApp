using VentaCursos.Api.Models;
using VentaCursos.Api.Services;
using Xunit;

namespace VentaCursos.Tests;

public class CourseServiceTests
{
    [Fact]
    public void Create_ShouldAssignHexId_WhenCourseIsAdded()
    {
        // Arrange (Preparar)
        var service = new CourseService();
        var testCourse = new Course { Title = "Curso sobre Test Unitarios", Price = 10, Author = "Tester Anónimo" };

        // Act (Actuar)
        service.Create(testCourse);

        // Assert (Afirmar)
        Assert.NotNull(testCourse.Id);
        Assert.Equal(6, testCourse.Id.Length); // Verificamos que tenga 6 caracteres hex
    }

    [Fact]
    public void GetAll_ShouldReturnInitialCourses()
    {
        // Arrange
        var service = new CourseService();

        // Act
        var testCourses = service.GetAll();

        // Assert
        Assert.NotEmpty(testCourses);
        Assert.Contains(testCourses, c => c.Title == "C#");
    }
}