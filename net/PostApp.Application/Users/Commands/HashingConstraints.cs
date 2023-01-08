namespace PostApp.Application.Users.Commands.VerifyPasswordHash;

public class HashingConstraints
{
    public const int Iterations = 100000;
    public const int HashLength = 20;
    public const int SaltLength = 16;
}