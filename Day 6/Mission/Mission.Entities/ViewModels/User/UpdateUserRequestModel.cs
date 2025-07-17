namespace Mission.Entities.ViewModels.User
{
    public class UpdateUserRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }

        public bool RemoveImage { get; set; }
    }
}
