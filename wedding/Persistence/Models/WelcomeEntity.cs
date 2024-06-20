using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.API.Persistence.Models;

[Table("welcome", Schema = "wedding")]
public sealed class WelcomeEntity
{
    public Guid Id { get; set; }
    public required string Key { get; set; }
    public required string Title { get; set; }
    public string? Text { get; set; } = string.Empty;
}