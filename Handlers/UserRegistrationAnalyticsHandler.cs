using WolverineFanout.Events;

namespace WolverineFanout.Handlers;

public class UserRegistrationAnalyticsHandler
{
    public async Task Handle(UserRegisteredEvent userEvent)
    {
        Console.WriteLine($"[ANALYTICS HANDLER] Recording user registration metrics");
        Console.WriteLine($"  User ID: {userEvent.UserId}");
        Console.WriteLine($"  Email: {userEvent.Email}");
        Console.WriteLine($"  Registration Time: {userEvent.RegisteredAt}");
        
        await Task.Delay(50);
        
        Console.WriteLine($"[ANALYTICS HANDLER] Analytics recorded for user {userEvent.UserId}");
    }
}