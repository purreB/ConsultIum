namespace Contracts
{
  public class UserDto
  {
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}