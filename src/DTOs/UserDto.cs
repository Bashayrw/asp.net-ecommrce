public class UserReadDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Role { get; set; }
}

public class UserSignIn
{
    public string Email { get; set; }
    public string Password { get; set; }

}

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string Password { get; set; }
}
