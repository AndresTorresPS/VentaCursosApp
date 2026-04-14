namespace VentaCursos.Api.Models;

public class Course
{
    public string Id { get; set; } = "000000";
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public string Author { get; set; } = string.Empty;
}