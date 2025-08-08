namespace WolverineFanout.Commands;

public record RegisterUserCommand(string Email, string FirstName, string LastName);