public class PasswordVO
{
    const string PATTERN = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}";

    public string Password { get; private set; }

    public PasswordVO()
    { }

    public PasswordVO(string password)
    {
        Password = password;
    }

    public virtual bool ConfirmPassword(string confirmPassword)
    {
        return AssertionConcern.IsSatisfiedBy
        (
            AssertionConcern.AssertNotNull(confirmPassword, string.Format(Language.InvalidF, Language.Password)),
            AssertionConcern.AssertAreEquals(Password, confirmPassword, Language.PasswordDoNotMatch)
        );
    }

    public virtual void Encrypt()
    {
        Password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
        MD5 md5 = MD5.Create();
        StringBuilder sbString = new StringBuilder();
        byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(Password));

        for (int i = 0; i < data.Length; i++)
            sbString.Append(data[i].ToString("x2"));

        Password = sbString.ToString();
    }

    public virtual bool IsValid()
    {
        return AssertionConcern.IsSatisfiedBy
        (
            AssertionConcern.AssertNotNull(Password, string.Format(Language.RequiredM, Language.Password)),
            AssertionConcern.AssertLength(Password, 6, 20, string.Format(Language.Length, Language.Password, 6, 20)),
            AssertionConcern.AssertMatches(PATTERN, Password, string.Format(Language.InvalidM, Language.Password))
        );
    }
}
