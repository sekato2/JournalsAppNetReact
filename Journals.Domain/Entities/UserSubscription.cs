namespace Journals.Domain.Entities;

public class UserSubscription
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime Created { get; set; }

    public UserSubscription FromEntity(User user)
    {
        UserSubscription userSubscription = new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Created = DateTime.Now,
        };
        return userSubscription;
    }
}
