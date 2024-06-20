namespace Wedding.API.Models.Input;

public sealed class GuestFormCreateModel
{
    public required string FullName { get; set; }
    public int[]? HelpSelector { get; set; }
    public string? Preferences { get; set; }
}