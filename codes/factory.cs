public class UserBuilder : IUserBuilder
{
    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Password { get; private set; }

    public IUserBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public IUserBuilder WithEmail(string email)
    {
        Email = email;
        return this;
    }

    public IUserBuilder WithPassword(string password)
    {
        Password = password;
        return this;
    }

    public UserModel Build()
    {
        return new UserModel(Name, Email, Password);
    }

    public void Dispose()
    {
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }
}
