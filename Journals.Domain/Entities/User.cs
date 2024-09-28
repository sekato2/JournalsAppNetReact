namespace Journals.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Pass { get; set; } = default!;

    public bool Status { get; set; }
}
