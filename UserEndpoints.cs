using Wolverine.Http;
using WolverineFanout.Commands;
using WolverineFanout.Events;

namespace WolverineFanout;

public record RegisterUserResponse(Guid UserId, string Message);

public static class UserEndpoints
{
    [WolverinePost("/users")]
    public static (RegisterUserResponse, UserRegisteredEvent) RegisterUser(RegisterUserCommand command)
    {
        var userId = Guid.NewGuid();
        var response = new RegisterUserResponse(userId, "User registered successfully");
        var userEvent = new UserRegisteredEvent(userId, command.Email, command.FirstName, command.LastName, DateTime.UtcNow);
        
        return (response, userEvent);
    }
}