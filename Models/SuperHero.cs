namespace Learn_Asp.Net_6.Models;

public class SuperHero
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string Place { get; set; } = string.Empty;

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}