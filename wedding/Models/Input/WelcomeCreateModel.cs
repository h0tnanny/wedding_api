namespace Wedding.API.Models.Input;

public sealed class WelcomeCreateModel
{
    public required string Key { get; set; }
    public required string Title { get; set; }
    public string? Text { get; set; }
}