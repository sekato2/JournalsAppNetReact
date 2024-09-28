namespace Journals.Domain.Entities;

public class Journal
{
    public int Id { get; set; }

    public int OwnerId { get; set; } = default!;

    public string DocumentB64 { get; set; } = default!;

    public bool Status { get; set; }
}
