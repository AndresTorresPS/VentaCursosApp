namespace VentaCursos.Api.Models;

public class Course
{
    public string Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Author { get; set; } = string.Empty;
}