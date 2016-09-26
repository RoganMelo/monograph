public class UserService : IUserService
{
    private readonly IUserBuilder builder;
    private readonly IUserRepository repository;
    private readonly IRoleRepository roleRepository;

    public UserService(IUserBuilder builder, IUserRepository repository, IRoleRepository roleRepository)
    {
        this.builder = builder;
        this.repository = repository;
        this.roleRepository = roleRepository;
    }

    public async Task<IEnumerable<UserModel>> GetAllAsync()
    {
        IList<UserModel> users = new List<UserModel>();

        foreach (var user in await repository.GetAllAsync())
            users.Add(new UserModel(user.Name, user.EmailVO.Email, null));

        return users;
    }

    public async Task<string> GetNameAsync(string email)
    {
        return (await repository.GetByEmailAsync(email)).Name;
    }

    public async Task<IEnumerable<string>> GetRolesAsync(string email)
    {
        IList<string> roles = new List<string>();

        foreach (var role in (await repository.GetByEmailAsync(email)).Roles)
            roles.Add(role.RoleGroup.ToString());

        return roles;
    }

    public async Task<UserModel> LoginAsync(string email, string password)
    {
        var user = await repository.GetByEmailAsync(email);

        var passwordVO = new PasswordVO(password);
        passwordVO.Encrypt();

        if (user == null || user.PasswordVO.Password != passwordVO.Password)
            return null;

        return user;
    }

    public async Task RegisterAsync(string name, string email, string password, string confirmPassword)
    {
        if (await repository.GetByEmailAsync(email) != null)
            DomainEvent.Raise(new DomainNotification("DuplicateEmail", string.Format(Language.Duplicate, Language.Email)));
        else
        {
            var user = builder.WithName(name)
                .WithEmail(email)
                .WithPassword(password)
                .Build();

            if (user.IsValid() && user.ConfirmPassword(confirmPassword))
            {
                user.EncryptPassword();
                user.AddRole(await roleRepository.GetByNameAsync("UserRole"));
                user.AddRole(await roleRepository.GetByNameAsync("AdminRole"));

                await repository.CreateAsync(user);
            }
        }
    }

    public void Dispose()
    {
        builder.Dispose();
        repository.Dispose();
        roleRepository.Dispose();
    }
}
