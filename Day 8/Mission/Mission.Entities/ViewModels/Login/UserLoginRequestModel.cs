namespace Mission.Entities.ViewModels.Login
{
    public class UserLoginRequestModel
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}
