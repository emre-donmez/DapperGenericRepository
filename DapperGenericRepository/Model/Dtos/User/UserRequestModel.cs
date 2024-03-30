namespace DapperGenericRepository.Model.Dtos.User
{
    public class UserRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}