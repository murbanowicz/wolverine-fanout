using WolverineFanout.Events;

namespace WolverineFanout.Handlers;

public class UserRegistrationEmailHandler
{
    public async Task Handle(UserRegisteredEvent userEvent)
    {
        Console.WriteLine($"[EMAIL HANDLER] Sending welcome email to {userEvent.Email}");
        Console.WriteLine($"  User: {userEvent.FirstName} {userEvent.LastName}");
        Console.WriteLine($"  Registered at: {userEvent.RegisteredAt}");
        
        await Task.Delay(100);
        
        Console.WriteLine($"[EMAIL HANDLER] Welcome email sent successfully to {userEvent.Email}");
    }
}