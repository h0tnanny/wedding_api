using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding.API.Persistence.Models;

[Table("guest_form", Schema = "wedding")]
public sealed class GuestForm
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public HelpSelector[]? HelpSelectors { get; set; }
    public string? Preferences { get; set; }
}